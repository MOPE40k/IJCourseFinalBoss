using System.Collections;
using Infrastructure.DI;
using Runtime.Utils.SceneManagement;
using UnityEngine;

namespace Infrastracture
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null);

        public abstract IEnumerator Init();

        public abstract void Run();
    }
}