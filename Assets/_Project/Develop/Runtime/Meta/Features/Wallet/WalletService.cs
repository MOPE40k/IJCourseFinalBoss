using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.DataManagement;
using Utils.Reactive;

namespace Runtime.Meta.Features.Wallet
{
    public class WalletService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        // Runtime
        private readonly Dictionary<CurrencyTypes, ReactiveVeriable<int>> _currencies = null;

        public WalletService(
            Dictionary<CurrencyTypes, ReactiveVeriable<int>> currencies,
            PlayerDataProvider playerDataProvider)
        {
            _currencies = new Dictionary<CurrencyTypes, ReactiveVeriable<int>>(currencies);

            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }

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

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<CurrencyTypes, int> currency in data.WalletData)
                if (_currencies.ContainsKey(currency.Key))
                    _currencies[currency.Key].Value = currency.Value;
                else
                    _currencies.Add(currency.Key, new ReactiveVeriable<int>(currency.Value));
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<CurrencyTypes, ReactiveVeriable<int>> currency in _currencies)
                if (data.WalletData.ContainsKey(currency.Key))
                    data.WalletData[currency.Key] = currency.Value.Value;
                else
                    data.WalletData.Add(currency.Key, currency.Value.Value);
        }
    }
}