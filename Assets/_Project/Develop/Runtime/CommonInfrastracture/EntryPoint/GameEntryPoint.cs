using System.Collections;
using Infrastructure.DI;
using UnityEngine;
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

            loadingScreen.Show();

            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();

            yield return new WaitForSeconds(0.25f); // TEMP LOADING SCREEN DEMO

            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}