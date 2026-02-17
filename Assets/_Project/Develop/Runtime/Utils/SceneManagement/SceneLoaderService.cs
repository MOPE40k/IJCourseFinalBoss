using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils.SceneManagement
{
    public class SceneLoaderService
    {
        public IEnumerator LoadAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            AsyncOperation wait = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            yield return new WaitWhile(() => wait.isDone == false);
        }

        public IEnumerator UnloadAsync(string sceneName)
        {
            AsyncOperation wait = SceneManager.UnloadSceneAsync(sceneName);

            yield return new WaitUntil(() => wait.isDone == false);
        }
    }
}