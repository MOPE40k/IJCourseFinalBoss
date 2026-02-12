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
using Runtime.Meta.Features.Wallet;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        // References
        private DIContainer _container = null;

        private WalletService walletService = null;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(container);
        }

        public override IEnumerator Init()
        {
            walletService = _container.Resolve<WalletService>();
            yield return _container.Resolve<ConfigsProviderService>().LoadAsync();
        }

        public override void Run()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                walletService.Add(CurrencyTypes.Gold, 10);
                Debug.Log($"Золота осталось: {walletService.GetCurrency(CurrencyTypes.Gold).Value}");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (walletService.Enough(CurrencyTypes.Gold, 10))
                {
                    walletService.Spend(CurrencyTypes.Gold, 10);
                    Debug.Log($"Золота осталось: {walletService.GetCurrency(CurrencyTypes.Gold).Value}");
                }
            }

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