using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils.ConfigsManagement
{
    public interface IConfigsLoader
    {
        IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded);
    }
}