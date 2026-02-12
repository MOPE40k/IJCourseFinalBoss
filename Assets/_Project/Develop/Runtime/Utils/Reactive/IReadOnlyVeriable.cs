using System;

namespace Utils.Reactive
{
    public interface IReadOnlyVeriable<T>
    {
        T Value { get; }

        IDisposable Subscribe(Action<T, T> action);
    }
}