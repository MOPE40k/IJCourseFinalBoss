using System.Collections;
using UnityEngine;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Utils.SceneManagement;
using Runtime.Utils.ConfigsManagement;
using Utils.InputManagement;
using Runtime.Utils.Stats;
using Runtime.Meta.Features.Stats;

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
        }
    }
}