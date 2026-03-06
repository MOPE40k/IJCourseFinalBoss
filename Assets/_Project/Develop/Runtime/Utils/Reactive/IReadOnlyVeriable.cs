using System;

namespace Runtime.Utils.Reactive
{
    public interface IReadOnlyVeriable<T>
    {
        // Runtime
        T Value { get; }

        IDisposable Subscribe(Action<T, T> action);
    }
}