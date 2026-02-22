using System;
using System.Collections.Generic;
using Runtime.Ui.Core.TestPopup;
using Runtime.Ui.LevelMenuPopup;
using UnityEngine;

namespace Runtime.Ui.Core
{
    public abstract class PopupService : IDisposable
    {
        // References
        protected readonly ViewsFactory _viewsFactory = null;
        private readonly ProjectPresentersFactory _projectPresentersFactory = null;

        // Runtime
        private readonly Dictionary<PopupPresenterBase, PopupInfo> _presenterToInfo = new();

        public PopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory)
        {
            _viewsFactory = viewsFactory;
            _projectPresentersFactory = projectPresentersFactory;
        }

        protected abstract Transform PopupLayer { get; }

        public TestPopupPresenter OpenTestPopup(Action closedCallback = null)
        {
            TestPopupView view = _viewsFactory.Create<TestPopupView>(ViewIds.TestPopup, PopupLayer);

            TestPopupPresenter popup = _projectPresentersFactory.CreateTestPopupPresenter(view);

            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }

        public LevelsPopupMenuPresenter OpenLevelPopup()
        {
            LevelsMenuPopupView view = _viewsFactory.Create<LevelsMenuPopupView>(ViewIds.LevelsMenuPopup, PopupLayer);

            LevelsPopupMenuPresenter presenter = _projectPresentersFactory.CreateLevelsPopupMenuPresenter(view);

            OnPopupCreated(presenter, view);

            return presenter;
        }

        public void OnClosePopup(PopupPresenterBase presenter)
        {
            presenter.CloseRequest -= OnClosePopup;

            presenter.Hide(() =>
            {
                _presenterToInfo[presenter].ClosedCallback?.Invoke();

                DisposeFor(presenter);

                _presenterToInfo.Remove(presenter);
            });
        }

        public void Dispose()
        {
            foreach (PopupPresenterBase presenter in _presenterToInfo.Keys)
            {
                presenter.CloseRequest -= OnClosePopup;

                DisposeFor(presenter);
            }

            _presenterToInfo.Clear();
        }

        protected void OnPopupCreated(
            PopupPresenterBase presenter,
            PopupViewBase view,
            Action closedCallback = null)
        {
            _presenterToInfo.Add(presenter, new PopupInfo(view, closedCallback));

            presenter.Init();

            presenter.Show();

            presenter.CloseRequest += OnClosePopup;
        }

        private void DisposeFor(PopupPresenterBase presenter)
        {
            presenter.Dispose();

            _viewsFactory.Release(_presenterToInfo[presenter].View);
        }

        private class PopupInfo
        {
            public PopupInfo(PopupViewBase view, Action closedCallback)
            {
                View = view;
                ClosedCallback = closedCallback;
            }

            public PopupViewBase View { get; } = null;
            public Action ClosedCallback { get; } = null;
        }
    }
}