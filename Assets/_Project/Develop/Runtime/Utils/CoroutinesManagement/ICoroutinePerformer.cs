using System.Collections;
using UnityEngine;

namespace Utils.CoroutinesManagement
{
    public interface ICoroutinePerformer
    {
        Coroutine StartPerform(IEnumerator coroutine);

        void StopPerform(Coroutine coroutine);
    }
}