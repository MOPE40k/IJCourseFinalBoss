using System.Collections;
using Infrastracture;
using Infrastructure.DI;
using Runtime.Utils.SceneManagement;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        // References
        private DIContainer _container = null;

        public override void ProcessRegistrations(
            DIContainer container,
            IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(container);
        }

        public override IEnumerator Init()
        {
            yield break;
        }

        public override void Run()
        { }

        private void Update()
        { }
    }
}