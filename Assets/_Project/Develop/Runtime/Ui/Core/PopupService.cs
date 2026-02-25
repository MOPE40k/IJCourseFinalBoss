using System;
using System.Collections.Generic;
using Runtime.Ui.LevelMenuPopup;
using Runtime.Ui.ResetStatsPopup;
using UnityEngine;

namespace Runtime.Ui.Core
{
    public abstract class PopupService : IDisposable
    {
        // References
        private readonly ProjectPresentersFactory _projectPresentersFactory = null;
        private readonly ViewsFactory _viewsFactory = null;

        // Runtime
        private readonly Dictionary<PopupPresenterBase, PopupInfo> _presenterToInfo = new();

        public PopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory)
        {
            _viewsFactory = viewsFactory;
            _projectPresentersFactory = projectPresentersFactory;
        }

        // Runtime
        protected abstract Transform PopupLayer { get; }

        public LevelsMenuPopupPresenter OpenLevelPopup()
        {
            LevelsMenuPopupView view = _viewsFactory.Create<LevelsMenuPopupView>(ViewIds.LevelsMenuPopup, PopupLayer);

            LevelsMenuPopupPresenter presenter = _projectPresentersFactory.CreateLevelsPopupMenuPresenter(view);

            OnPopupCreated(presenter, view);

            return presenter;
        }

        public ResetStatsPopupPresenter OpenResetMenuPopup()
        {
            ResetStatsPopupView view = _viewsFactory.Create<ResetStatsPopupView>(ViewIds.ResetStatsPopup, PopupLayer);

            ResetStatsPopupPresenter presenter = _projectPresentersFactory.CreateResetStatsPopupPresenter(view);

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