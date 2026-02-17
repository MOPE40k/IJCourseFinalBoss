using System;
using System.Collections;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Utils.SceneManagement;
using UnityEngine;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayBootstrap : SceneBootstrap
    {
        // References
        private DIContainer _container = null;
        GameplayCycle _gameplayCycle = null;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match {typeof(GameplayInputArgs)} type!");

            GameplayContextRegistrations.Process(container, gameplayInputArgs);
        }

        public override IEnumerator Init()
        {
            _gameplayCycle = _container.Resolve<GameplayCycle>();

            yield break;
        }

        public override void Run()
            => _gameplayCycle.Run();

        private void Update()
            => _gameplayCycle?.UpdateTick(Time.deltaTime);
    }
}