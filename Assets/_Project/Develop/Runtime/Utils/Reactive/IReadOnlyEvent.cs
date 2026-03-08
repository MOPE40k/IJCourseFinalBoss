using System;

namespace Runtime.Utils.Reactive
{
    public interface IReadOnlyEvent
    {
        IDisposable Subscribe(Action action);
    }

    public interface IReadOnlyEvent<T>
    {
        IDisposable Subscribe(Action<T> action);
    }
}