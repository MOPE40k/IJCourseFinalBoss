using System.Collections.Generic;
using Runtime.Meta.Features.Wallet;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;

namespace Runtime.Ui.Wallet
{
    public class WalletPresenter : IPresenter
    {
        // References
        private readonly WalletService _walletService = null;
        private readonly ProjectPresentersFactory _presentersFactory = null;
        private readonly ViewsFactory _viewsFactory = null;
        private readonly IconTextListView _view = null;

        // Runtime
        private readonly List<CurrencyPresenter> _currencyPresenters = new();

        public WalletPresenter(
            WalletService walletService,
            ProjectPresentersFactory presentersFactory,
            ViewsFactory viewsFactory,
            IconTextListView view)
        {
            _walletService = walletService;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Init()
        {
            foreach (CurrencyTypes currencyType in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewIds.CurrencyView);

                _view.Add(currencyView);

                CurrencyPresenter currencyPresenter = _presentersFactory.CreateCurrencyPresenter(
                    _walletService.GetCurrency(currencyType),
                    currencyType,
                    currencyView
                );

                currencyPresenter.Init();

                _currencyPresenters.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CurrencyPresenter currencyPresenter in _currencyPresenters)
            {
                _view.Remove(currencyPresenter.View);

                _viewsFactory.Release(currencyPresenter.View);

                currencyPresenter.Dispose();
            }

            _currencyPresenters.Clear();
        }
    }
}