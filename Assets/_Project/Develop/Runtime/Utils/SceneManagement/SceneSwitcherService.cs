using System;
using System.Collections;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Utils.SceneManagement;
using UnityEngine;
using Utils.LoadingScreen;

namespace Utils.SceneManagement
{
    public class SceneSwitcherService
    {
        // References
        private readonly SceneLoaderService _sceneLoaderService = null;
        private readonly ILoadingScreen _loadingScreen = null;
        private readonly DIContainer _projectContainer = null;

        public SceneSwitcherService(
            SceneLoaderService sceneLoaderService,
            ILoadingScreen loadingScreen,
            DIContainer projectContainer)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreen = loadingScreen;
            _projectContainer = projectContainer;
        }

        public IEnumerator ProcessSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _loadingScreen.Show();

            yield return _sceneLoaderService.LoadAsync(Scenes.Empty);
            yield return _sceneLoaderService.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = GameObject.FindAnyObjectByType<SceneBootstrap>();

            if (sceneBootstrap == null)
                throw new NullReferenceException($"{nameof(sceneBootstrap)} not found!");

            DIContainer sceneContainer = new(_projectContainer);

            sceneBootstrap.ProcessRegistrations(sceneContainer, sceneArgs);

            sceneContainer.Init();

            yield return sceneBootstrap.Init();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}