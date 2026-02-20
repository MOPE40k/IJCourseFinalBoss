using System;

namespace Runtime.Ui.Core
{
    public abstract class PopupPresenterBase : IPresenter
    {
        // Delegates
        public event Action<PopupPresenterBase> CloseRequest = null;

        // References
        protected abstract PopupViewBase PopupView { get; }

        public virtual void Dispose()
        {
            PopupView.CloseRequest -= OnCloseRequest;
        }

        public virtual void Init()
        {

        }

        public void Show()
        {
            OnPreShow();

            PopupView.Show();

            OnPostShow();
        }

        public void Hide(Action callback = null)
        {
            OnPreHide();

            PopupView.Hide();

            OnPostHide();

            callback?.Invoke();
        }

        protected virtual void OnPreShow()
        {
            PopupView.CloseRequest += OnCloseRequest;
        }

        protected virtual void OnPostShow()
        {

        }

        protected virtual void OnPreHide()
        {
            PopupView.CloseRequest -= OnCloseRequest;
        }

        protected virtual void OnPostHide()
        {

        }

        protected void OnCloseRequest()
            => CloseRequest?.Invoke(this);
    }
}