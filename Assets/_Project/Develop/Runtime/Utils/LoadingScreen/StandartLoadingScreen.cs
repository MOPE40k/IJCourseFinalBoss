using System;
using UnityEngine;

namespace Utils.LoadingScreen
{
    public class StandartLoadingScreen : MonoBehaviour, ILoadingScreen
    {
        // Runtime
        public bool IsShow => gameObject.activeSelf;

        private void Awake()
        {
            Hide();

            DontDestroyOnLoad(this);
        }

        public void Show()
            => gameObject.SetActive(true);

        public void Hide()
            => gameObject.SetActive(false);

    }
}