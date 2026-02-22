using System.Collections;
using UnityEngine;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Utils.SceneManagement;
using Runtime.Utils.ConfigsManagement;
using Utils.InputManagement;
using Runtime.Utils.Stats;
using Runtime.Meta.Features.Stats;
using Runtime.Meta.Features.Wallet;
using Runtime.Ui.MainMenu;
using Runtime.Utils.DataManagement;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.CoroutinesManagement;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        // Test
        private WalletService _walletService;
        private PlayerDataProvider _playerDataProvider;
        private ICoroutinePerformer _coroutinePerformer;

        public void Test()
        {
            _walletService = _container.Resolve<WalletService>();
            _playerDataProvider = _container.Resolve<PlayerDataProvider>();
            _coroutinePerformer = _container.Resolve<ICoroutinePerformer>();
        }

        // References
        private DIContainer _container = null;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(container);
        }

        public override IEnumerator Init()
        {
            Test();

            yield break;
        }

        public override void Run()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(InputKeys.DigitsModeKey))
                _container.Resolve<GamemodeConfigProvider>().DigitsModeLoad();

            if (Input.GetKeyDown(InputKeys.LettersModeKey))
                _container.Resolve<GamemodeConfigProvider>().LettersModeLoad();

            if (Input.GetKeyDown(InputKeys.InfoKey))
                _container.Resolve<StatsShowService>().ShowStats();

            if (Input.GetKeyDown(InputKeys.ResetKey))
                _container.Resolve<ResetStatsService>().ResetStats();


            if (Input.GetKeyDown(KeyCode.Alpha0))
                _walletService.Add(CurrencyTypes.Gold, 10);

            if (Input.GetKeyDown(KeyCode.Alpha9))
                _walletService.Spend(CurrencyTypes.Gold, 10);

            if (Input.GetKeyDown(KeyCode.Alpha7))
                _walletService.Add(CurrencyTypes.Diamond, 10);

            if (Input.GetKeyDown(KeyCode.Alpha8))
                _walletService.Spend(CurrencyTypes.Diamond, 10);

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("SAVE");
                _coroutinePerformer.StartPerform(_playerDataProvider.Save());
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("LOAD");
                _coroutinePerformer.StartPerform(_playerDataProvider.Load());
            }
        }
    }
}