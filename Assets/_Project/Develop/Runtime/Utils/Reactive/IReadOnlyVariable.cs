using System;

namespace Runtime.Utils.Reactive
{
    public interface IReadOnlyVariable<T>
    {
        // Runtime
        T Value { get; }

        IDisposable Subscribe(Action<T, T> action);
    }
}