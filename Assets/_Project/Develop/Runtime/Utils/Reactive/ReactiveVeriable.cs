using System;
using System.Collections.Generic;

namespace Utils.Reactive
{
    public class ReactiveVeriable<T> : IReadOnlyVeriable<T> where T : IEquatable<T>
    {
        // References
        private readonly List<Subscriber<T, T>> _subscribers = new();
        private readonly List<Subscriber<T, T>> _toAdd = new();
        private readonly List<Subscriber<T, T>> _toRemove = new();

        // Runtime
        private T _value = default(T);

        public ReactiveVeriable()
            => Value = default(T);

        public ReactiveVeriable(T value)
            => Value = value;

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                _value = value;

                if (_value.Equals(oldValue) == false)
                    Invoke(oldValue, _value);
            }
        }

        public IDisposable Subscribe(Action<T, T> action)
        {
            Subscriber<T, T> subscriber = new Subscriber<T, T>(action, Remove);

            _toAdd.Add(subscriber);

            return subscriber;
        }

        private void Remove(Subscriber<T, T> subscriber)
            => _toRemove.Add(subscriber);

        private void Invoke(T oldValue, T value)
        {
            if (_toAdd.Count > 0)
            {
                _subscribers.AddRange(_toAdd);

                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (Subscriber<T, T> subscriber in _toRemove)
                    _subscribers.Remove(subscriber);

                _toRemove.Clear();
            }

            foreach (Subscriber<T, T> subscriber in _subscribers)
                subscriber.Invoke(oldValue, value);
        }
    }
}