using System;
using System.Collections.Generic;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.LifeCycle
{
    public class DisableCollidersOnDeathSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private List<Collider> _colliders = null;
        private ReactiveVariable<bool> _isDead = null;

        // Runtime
        private IDisposable _isDeadChangeDisposable = null;

        public void OnInit(Entity entity)
        {
            _colliders = entity.DisableCollidersOnDeath;
            _isDead = entity.IsDead;

            _isDeadChangeDisposable = _isDead.Subscribe(OnIsDeadChanged);
        }

        public void OnDispose()
            => _isDeadChangeDisposable.Dispose();

        private void OnIsDeadChanged(bool oldValue, bool newValue)
        {
            if (newValue)
                foreach (Collider collider in _colliders)
                    collider.enabled = false;
        }
    }
}