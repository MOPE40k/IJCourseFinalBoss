using System;
using System.Collections.Generic;
using Runtime.Gameplay.Infrastucture;

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

        public IRegistrationOptions RegisterAsSingle<T>(Func<DIContainer, T> creator)
        {
            if (IsAlreadyRegister<T>())
                throw new InvalidOperationException($"{typeof(T)} already register!");

            Registration registration = new Registration(container => creator.Invoke(container));

            _container.Add(typeof(T), registration);

            return registration;
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

        public void Init()
        {
            foreach (Registration registration in _container.Values)
            {
                if (registration.IsNonLazy)
                    registration.CreateInstanceFrom(this);

                registration.OnInit();
            }
        }

        public void Dispose()
        {
            foreach (Registration registration in _container.Values)
                registration.OnDispose();
        }
    }
}