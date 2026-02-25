using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Utils.CoroutinesManagement;

namespace Runtime.Ui.Core
{
    public abstract class PopupPresenterBase : IPresenter
    {
        // Delegates
        public event Action<PopupPresenterBase> CloseRequest = null;

        // References
        private ICoroutinePerformer _coroutinePerformer = null;

        // Runtime
        private Coroutine _process = null;

        protected PopupPresenterBase(ICoroutinePerformer coroutinePerformer)
            => _coroutinePerformer = coroutinePerformer;

        // Runtime
        protected abstract PopupViewBase PopupView { get; }

        public virtual void Init()
        { }

        public virtual void Dispose()
        {
            KillProcess();

            PopupView.CloseRequest -= OnCloseRequest;
        }

        public void Show()
        {
            KillProcess();

            _coroutinePerformer.StartPerform(ProcessShow());
        }

        public void Hide(Action callback = null)
        {
            KillProcess();

            _coroutinePerformer.StartPerform(ProcessHide(callback));
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

        private IEnumerator ProcessShow()
        {
            OnPreShow();

            yield return PopupView.Show().WaitForCompletion();

            OnPostShow();
        }

        private IEnumerator ProcessHide(Action callback)
        {
            OnPreHide();

            yield return PopupView.Hide().WaitForCompletion();

            OnPostHide();

            callback?.Invoke();
        }

        private void KillProcess()
        {
            if (_process != null)
                _coroutinePerformer.StopPerform(_process);
        }
    }
}