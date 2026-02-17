using System;

namespace Utils.Reactive
{
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

        public void Dispose()
            => _onDispose?.Invoke(this);

        public void Invoke(T arg1, K arg2)
            => _action?.Invoke(arg1, arg2);
    }
}