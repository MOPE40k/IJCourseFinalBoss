using System;
using UnityEngine;

namespace Runtime.Ui.Core
{
    public class PopupViewBase : MonoBehaviour, IShowableView
    {
        // Delegates
        public event Action CloseRequest = null;

        [Header("Settings:")]
        [SerializeField] private CanvasGroup _mainGroup = null;

        private void Awake()
        {
            _mainGroup.alpha = 0f;
        }

        public void OnCloseButtonClicked()
            => CloseRequest?.Invoke();

        public void Show()
        {
            OnPreShow();

            // animations
            _mainGroup.alpha = 1f;

            OnPostShow();
        }

        public void Hide()
        {
            OnPreHide();

            // Animations
            _mainGroup.alpha = 0f;

            OnPostHide();
        }

        protected virtual void OnPostShow()
        { }

        protected virtual void OnPreShow()
        { }

        protected virtual void OnPreHide()
        { }

        protected virtual void OnPostHide()
        { }
    }
}