using System;
using System.Collections;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.SceneManagement;
using UnityEngine;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayBootstrap : SceneBootstrap
    {
        [Header("Test:")]
        [SerializeField] private TestGameplay _testGameplay = null; // TEMP
        private EntitiesLifeContext _entitiesLifeContext = null;

        // References
        private DIContainer _container = null;
        //private GameplayCycle _gameplayCycle = null;

        public override void ProcessRegistrations(
            DIContainer container,
            IInputSceneArgs sceneArgs)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match {typeof(GameplayInputArgs)} type!");

            GameplayContextRegistrations.Process(container, gameplayInputArgs);
        }

        public override IEnumerator Init()
        {
            _testGameplay.Init(_container); // TEMP

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();

            //_gameplayCycle = _container.Resolve<GameplayCycle>();

            yield break;
        }

        public override void Run()
        {
            _testGameplay.Run(); // TEMP

            //_gameplayCycle.Run();
        }

        private void Update()
        {
            _entitiesLifeContext?.UpdateTick(Time.deltaTime);

            //_gameplayCycle?.UpdateTick(Time.deltaTime);
        }

        private void FixedUpdate()
            => _entitiesLifeContext?.FixedUpdateTick(Time.fixedDeltaTime);
    }
}