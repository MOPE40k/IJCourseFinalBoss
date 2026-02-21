using System.Collections;
using Infrastructure.DI;
using Runtime.Utils.DataManagement.DataProviders;
using UnityEngine;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.LoadingScreen;
using Utils.SceneManagement;

namespace Infrastracture.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            SetupAppSettings();

            DIContainer projectContainer = new();

            ProjectContextRegistrations.Process(projectContainer);

            projectContainer.Init();

            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(Init(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;

            Application.targetFrameRate = 60;
        }

        private IEnumerator Init(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();

            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();

            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            loadingScreen.Show();

            bool isPlayerDataSaveExists = false;

            yield return playerDataProvider.Exists(result => isPlayerDataSaveExists = result);

            if (isPlayerDataSaveExists)
                yield return playerDataProvider.Load();
            else
                playerDataProvider.Reset();

            yield return new WaitForSeconds(0.25f); // TEMP LOADING SCREEN DEMO

            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}