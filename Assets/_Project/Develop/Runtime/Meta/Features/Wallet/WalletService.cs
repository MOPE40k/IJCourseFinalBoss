using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using Utils.Reactive;

namespace Runtime.Meta.Features.Wallet
{
    public class WalletService : IService
    {
        private readonly Dictionary<CurrencyTypes, ReactiveVeriable<int>> _currencies = null;

        public WalletService()
            => _currencies = new Dictionary<CurrencyTypes, ReactiveVeriable<int>>();

        public WalletService(Dictionary<CurrencyTypes, ReactiveVeriable<int>> currencies)
            => _currencies = new Dictionary<CurrencyTypes, ReactiveVeriable<int>>(currencies);

        public CurrencyTypes[] AvailableCurrencies => _currencies.Keys.ToArray();

        public IReadOnlyVeriable<int> GetCurrency(CurrencyTypes type)
            => _currencies[type];

        public bool Enough(CurrencyTypes type, int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            return _currencies[type].Value >= amount;
        }

        public void Add(CurrencyTypes type, int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _currencies[type].Value += amount;
        }

        public void Spend(CurrencyTypes type, int amount)
        {
            if (Enough(type, amount) == false)
                throw new InvalidOperationException($"Not enough {type}");

            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _currencies[type].Value -= amount;
        }
    }
}