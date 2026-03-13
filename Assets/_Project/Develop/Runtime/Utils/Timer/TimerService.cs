using System;
using System.Collections;
using Runtime.Utils.Reactive;
using UnityEngine;
using Utils.CoroutinesManagement;

namespace Runtime.Utils.Timer
{
    public class TimerService : IDisposable
    {
        // References
        private readonly ICoroutinePerformer _coroutinePerformer = null;
        private readonly float _cooldown = 0f;

        // Runtime
        private ReactiveVariable<float> _currentTime = null;
        private ReactiveEvent _cooldownEnded = null;
        private Coroutine _cooldownProcess = null;

        public TimerService(ICoroutinePerformer coroutinePerformer, float cooldown)
        {
            _coroutinePerformer = coroutinePerformer;
            _cooldown = cooldown;

            _cooldownEnded = new ReactiveEvent();
            _currentTime = new ReactiveVariable<float>();
        }

        // Runtime
        public IReadOnlyEvent CooldownEnded => _cooldownEnded;
        public IReadOnlyVariable<float> CurrentTime => _currentTime;
        public bool IsOver => _currentTime.Value <= 0f;

        public void Stop()
        {
            if (_cooldownProcess is not null)
                _coroutinePerformer.StopPerform(_cooldownProcess);
        }

        public void Restart()
        {
            Stop();

            _cooldownProcess = _coroutinePerformer.StartPerform(CooldownProcess());
        }

        public void Dispose()
            => Stop();

        private IEnumerator CooldownProcess()
        {
            _currentTime.Value = _cooldown;

            while (IsOver == false)
            {
                _currentTime.Value -= Time.deltaTime;

                yield return null;
            }

            _cooldownEnded.Invoke();
        }
    }
}