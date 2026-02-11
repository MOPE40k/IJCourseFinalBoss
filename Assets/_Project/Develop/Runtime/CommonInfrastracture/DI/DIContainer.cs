using System;
using System.Collections.Generic;
using Utils;

namespace Infrastructure.DI
{
    public class DIContainer
    {
        // References
        private readonly Dictionary<Type, Registration> _container = new();
        private readonly DIContainer _parent = null;

        // Runtime
        private readonly List<Type> _requests = new();

        public DIContainer(DIContainer parent = null)
            => _parent = parent;

        public DIContainer RegisterAsSingle<T>(Func<DIContainer, T> creator) where T : IService
        {
            if (IsAlreadyRegister<T>())
                throw new InvalidOperationException($"{typeof(T)} already register!");

            Registration registration = new Registration(container => creator.Invoke(container));

            _container.Add(typeof(T), registration);

            return this;
        }

        public bool IsAlreadyRegister<T>()
        {
            if (_container.ContainsKey(typeof(T)))
                return true;

            if (_parent != null)
                return _parent.IsAlreadyRegister<T>();

            return false;
        }

        public T Resolve<T>()
        {
            if (_requests.Contains(typeof(T)))
                throw new InvalidOperationException($"Cycle resolve of {typeof(T)}!");

            _requests.Add(typeof(T));

            try
            {
                if (_container.TryGetValue(typeof(T), out Registration registration))
                    return (T)registration.CreateInstanceFrom(this);

                if (_parent is not null)
                    return _parent.Resolve<T>();
            }
            finally
            {
                _requests.Remove(typeof(T));
            }

            throw new InvalidOperationException($"Registration for {typeof(T)} not exists");
        }
    }
}