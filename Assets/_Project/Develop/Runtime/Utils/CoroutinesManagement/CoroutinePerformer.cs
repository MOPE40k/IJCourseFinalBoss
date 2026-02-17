using System.Collections;
using UnityEngine;

namespace Utils.CoroutinesManagement
{
    public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
    {
        private void Awake()
            => DontDestroyOnLoad(this);

        public Coroutine StartPerform(IEnumerator coroutine)
            => StartCoroutine(coroutine);

        public void StopPerform(Coroutine coroutine)
            => StopCoroutine(coroutine);
    }
}