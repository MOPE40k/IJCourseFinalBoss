using System;
using System.Collections;

namespace Runtime.Utils.DataManagement
{
    public interface ISaveLoadService
    {
        IEnumerator Load<TData>(Action<TData> onLoad) where TData : ISaveData;
        IEnumerator Save<TData>(TData data) where TData : ISaveData;
        IEnumerator Exists<TData>(Action<bool> onExists) where TData : ISaveData;
        IEnumerator Remove<TData>() where TData : ISaveData;
    }
}