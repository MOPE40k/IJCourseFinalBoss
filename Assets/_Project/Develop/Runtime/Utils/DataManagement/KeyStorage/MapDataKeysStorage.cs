using System;
using System.Collections.Generic;
using Runtime.Utils.DataManagement;

namespace Utils.DataManagement.KeyStorage
{
    public class MapDataKeysStorage : IDataKeysStorage
    {
        private readonly Dictionary<Type, string> Keys = new Dictionary<Type, string>()
        {
            { typeof(PlayerData), nameof(PlayerData) }
        };

        public string GetKeyFor<TData>() where TData : ISaveData
            => Keys[typeof(TData)];
    }
}