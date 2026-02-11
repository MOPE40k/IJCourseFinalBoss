using System.Collections;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Gameplay.Infrastucture;
using Runtime.Utils.SceneManagement;
using Utils.CoroutinesManagement;
using Utils.SceneManagement;
using Runtime.Configs;
using Utils.ConfigsManagement;
using UnityEngine;
using Utils.InputManagement;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        // References
        private DIContainer _container = null;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(container);
        }

        public override IEnumerator Init()
        {
            yield return _container.Resolve<ConfigsProviderService>().LoadAsync();
        }

        public override void Run()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(InputKeys.DigitsModeKey))
                LoadSceneFor(
                    _container.Resolve<ConfigsProviderService>().GetConfig<DigitsSetConfig>());

            if (Input.GetKeyDown(InputKeys.LettersModeKey))
                LoadSceneFor(
                    _container.Resolve<ConfigsProviderService>().GetConfig<LettersSetConfig>());
        }

        private void LoadSceneFor(ISymbolsSetConfig config)
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();

            ICoroutinePerformer coroutinePerformer = _container.Resolve<ICoroutinePerformer>();

            coroutinePerformer.StartPerform(
                sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(config)));
        }
    }
}