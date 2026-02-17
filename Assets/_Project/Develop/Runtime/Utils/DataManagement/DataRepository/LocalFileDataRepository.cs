using System;
using System.Collections;
using System.IO;

namespace Runtime.Utils.DataManagement.DataRepository
{
    public class LocalFileDataRepository : IDataRepository
    {
        // Consts
        private readonly string _folderPath = string.Empty;
        private readonly string _saveFileExtension = string.Empty;
        private const string FileNameSeparator = ".";

        public LocalFileDataRepository(string folderPath, string saveFileExtension)
        {
            _folderPath = folderPath;
            _saveFileExtension = saveFileExtension;
        }

        public IEnumerator Read(string key, Action<string> onRead)
        {
            string text = File.ReadAllText(FullPathFor(key));

            onRead?.Invoke(text);

            yield break;
        }

        public IEnumerator Write(string key, string serializedData)
        {
            File.WriteAllText(FullPathFor(key), serializedData);

            yield break;
        }

        public IEnumerator Remove(string key)
        {
            File.Delete(FullPathFor(key));

            yield break;
        }

        public IEnumerator Exists(string key, Action<bool> onExistsResult)
        {
            bool result = File.Exists(FullPathFor(key));

            onExistsResult?.Invoke(result);

            yield break;
        }

        private string FullPathFor(string key)
            => Path.Combine(_folderPath, key) + FileNameSeparator + _saveFileExtension;
    }
}