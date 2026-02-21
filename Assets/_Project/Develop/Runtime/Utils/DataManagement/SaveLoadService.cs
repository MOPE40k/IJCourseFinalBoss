using System;
using System.Collections;
using Runtime.Utils.DataManagement.DataRepository;
using Utils.DataManagement.KeyStorage;
using Utils.DataManagement.Serializers;

namespace Runtime.Utils.DataManagement
{
    public class SaveLoadService : ISaveLoadService
    {
        // References
        private readonly IDataKeysStorage _keysStorage = null;
        private readonly IDataSerializer _serializer = null;
        private readonly IDataRepository _repository = null;

        public SaveLoadService(
            IDataKeysStorage keysStorage,
            IDataSerializer serializer,
            IDataRepository repository)
        {
            _keysStorage = keysStorage;
            _serializer = serializer;
            _repository = repository;
        }

        public IEnumerator Exists<TData>(Action<bool> onExists) where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            yield return _repository.Exists(key, result => onExists?.Invoke(result));
        }

        public IEnumerator Load<TData>(Action<TData> onLoad) where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            string serializedData = string.Empty;

            yield return _repository.Read(key, result => serializedData = result);

            TData data = _serializer.Deserialize<TData>(serializedData);

            onLoad.Invoke(data);
        }

        public IEnumerator Remove<TData>() where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            yield return _repository.Remove(key);
        }

        public IEnumerator Save<TData>(TData data) where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            string serializedData = _serializer.Serialize(data);

            yield return _repository.Write(key, serializedData);
        }
    }
}