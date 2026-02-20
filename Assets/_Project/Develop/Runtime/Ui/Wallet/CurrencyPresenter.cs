using System;
using Runtime.Configs.Meta.Wallet;
using Runtime.Meta.Features.Wallet;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using Utils.Reactive;

namespace Runtime.Ui.Wallet
{
    public class CurrencyPresenter : IPresenter
    {
        // References
        private readonly IReadOnlyVeriable<int> _currency = null;
        private readonly CurrencyTypes _currencyType = CurrencyTypes.Gold;
        private readonly CurrencyIconsConfig _config = null;
        private readonly IconTextView _view = null;

        // Runtime
        public IconTextView View => _view;
        private IDisposable _disposable = null;

        public CurrencyPresenter(
            IReadOnlyVeriable<int> currency,
            CurrencyTypes currencyType,
            CurrencyIconsConfig config,
            IconTextView view)
        {
            _currency = currency;
            _currencyType = currencyType;
            _config = config;
            _view = view;
        }

        public void Init()
        {
            _view.SetIcon(_config.GetSpriteFor(_currencyType));

            UpdateValue(_currency.Value);

            _disposable = _currency.Subscribe(OnValueChanged);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnValueChanged(int oldValue, int newValue)
            => UpdateValue(newValue);

        private void UpdateValue(int newValue)
            => _view.SetText(newValue.ToString());
    }
}