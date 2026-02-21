using System;
using System.Collections;
using System.Collections.Generic;

namespace Runtime.Utils.DataManagement.DataProviders
{
    public abstract class DataProvider<TData> where TData : ISaveData
    {
        // References
        private readonly ISaveLoadService _saveLoadService = null;

        // Runtime
        public readonly List<IDataReader<TData>> _readers = new();
        public readonly List<IDataWriter<TData>> _writers = new();

        private TData _data = default(TData);

        protected DataProvider(ISaveLoadService saveLoadService)
            => _saveLoadService = saveLoadService;

        public void RegisterReader(IDataReader<TData> reader)
        {
            if (_readers.Contains(reader))
                throw new ArgumentException(nameof(reader));

            _readers.Add(reader);
        }

        public void RegisterWriter(IDataWriter<TData> writer)
        {
            if (_writers.Contains(writer))
                throw new ArgumentException(nameof(writer));

            _writers.Add(writer);
        }

        public IEnumerator Save()
        {
            UpdateDataFrowWriters();

            yield return _saveLoadService.Save(_data);
        }

        public IEnumerator Load()
        {
            yield return _saveLoadService.Load<TData>(loadedData => _data = loadedData);

            SendDataToReaders();
        }

        public IEnumerator Exists(Action<bool> onExists)
        {
            yield return _saveLoadService.Exists<TData>(result => onExists?.Invoke(result));
        }

        public void Reset()
        {
            _data = GetOriginalData();

            SendDataToReaders();
        }

        protected abstract TData GetOriginalData();

        private void SendDataToReaders()
        {
            foreach (IDataReader<TData> reader in _readers)
                reader.ReadFrom(_data);
        }

        private void UpdateDataFrowWriters()
        {
            foreach (IDataWriter<TData> writer in _writers)
                writer.WriteTo(_data);
        }
    }
}