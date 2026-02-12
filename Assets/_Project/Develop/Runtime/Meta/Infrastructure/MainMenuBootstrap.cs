using System.Collections;
using UnityEngine;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Utils.SceneManagement;
using Utils.ConfigsManagement;
using Runtime.Utils.ConfigsManagement;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        // References
        private DIContainer _container = null;

        private GamemodeConfigProvider _gamemodeConfigProvider = null;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(container);
        }

        public override IEnumerator Init()
        {
            yield return _container.Resolve<ConfigsProviderService>().LoadAsync();

            _gamemodeConfigProvider = _container.Resolve<GamemodeConfigProvider>();
        }

        public override void Run()
        {

        }

        private void Update()
            => _gamemodeConfigProvider?.UpdateTick(Time.deltaTime);
    }
}