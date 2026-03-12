using System;

namespace Runtime.Utils.Reactive
{
    public class Subscriber : IDisposable
    {
        // Delegates
        private Action _action = null;
        private Action<Subscriber> _onDispose = null;

        public Subscriber(Action action, Action<Subscriber> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Invoke()
            => _action?.Invoke();

        public void Dispose()
            => _onDispose?.Invoke(this);
    }

    public class Subscriber<T> : IDisposable
    {
        // Delegates
        private Action<T> _action = null;
        private Action<Subscriber<T>> _onDispose = null;

        public Subscriber(Action<T> action, Action<Subscriber<T>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Invoke(T arg1)
            => _action?.Invoke(arg1);

        public void Dispose()
            => _onDispose?.Invoke(this);
    }

    public class Subscriber<T, K> : IDisposable
    {
        // Delegates
        private Action<T, K> _action = null;
        private Action<Subscriber<T, K>> _onDispose = null;

        public Subscriber(Action<T, K> action, Action<Subscriber<T, K>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Invoke(T arg1, K arg2)
            => _action?.Invoke(arg1, arg2);

        public void Dispose()
            => _onDispose?.Invoke(this);
    }
}