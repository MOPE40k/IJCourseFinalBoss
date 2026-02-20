using Infrastructure.DI;
using Runtime.Configs.Meta.Wallet;
using Runtime.Meta.Features.Wallet;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using Runtime.Ui.Core.TestPopup;
using Runtime.Ui.Wallet;
using Utils.ConfigsManagement;
using Utils.Reactive;

namespace Runtime.Ui
{
    public class ProjectPresentersFactory
    {
        // References
        public readonly DIContainer _container = null;

        public ProjectPresentersFactory(DIContainer container)
            => _container = container;

        public CurrencyPresenter CreateCurrencyPresenter(
            IReadOnlyVeriable<int> currency,
            CurrencyTypes currencyType,
            IconTextView view)
        {
            return new CurrencyPresenter(
                currency,
                currencyType,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(),
                view);
        }

        public WalletPresenter CreateWalletPresenter(IconTextListView view)
            => new WalletPresenter(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);

        public TestPopupPresenter CreateTestPopupPresenter(TestPopupView view)
            => new TestPopupPresenter(view);
    }
}