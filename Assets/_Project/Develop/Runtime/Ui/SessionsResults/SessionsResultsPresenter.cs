using System.Collections.Generic;
using Runtime.Meta.Features.Sessions;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;

namespace Runtime.Ui.SessionsResults
{
    public class SessionsResultsPresenter : IPresenter
    {
        // References
        private readonly SessionsResultsCounterService _sessionsResultsCounterService = null;
        private readonly ProjectPresentersFactory _presentersFactory = null;
        private readonly ViewsFactory _viewsFactory = null;
        private readonly IconTextListView _view = null;

        // Runtime
        private readonly List<ResultPresenter> _resultPresenters = new();

        public SessionsResultsPresenter(
            SessionsResultsCounterService sessionsResultsCounterService,
            ProjectPresentersFactory presentersFactory,
            ViewsFactory viewsFactory,
            IconTextListView view)
        {
            _sessionsResultsCounterService = sessionsResultsCounterService;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Init()
        {
            foreach (SessionEndConditionTypes conditionType in _sessionsResultsCounterService.AvailableSessionEndConditions)
            {
                IconTextView resultView = _viewsFactory.Create<IconTextView>(ViewIds.ResultView);

                _view.Add(resultView);

                ResultPresenter resultPresenter = _presentersFactory.CreateResultPresenter(
                    _sessionsResultsCounterService.GetCondition(conditionType),
                    conditionType,
                    resultView
                );

                resultPresenter.Init();

                _resultPresenters.Add(resultPresenter);
            }
        }

        public void Dispose()
        {
            foreach (ResultPresenter presenter in _resultPresenters)
            {
                _view.Remove(presenter.View);

                _viewsFactory.Release(presenter.View);

                presenter.Dispose();
            }

            _resultPresenters.Clear();
        }
    }
}