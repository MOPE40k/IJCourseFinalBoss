using Runtime.Utils.DataManagement;

namespace Utils.DataManagement.KeyStorage
{
    public interface IDataKeysStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }
}