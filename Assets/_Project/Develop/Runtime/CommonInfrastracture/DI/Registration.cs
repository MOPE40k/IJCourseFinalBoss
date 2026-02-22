using System;
using Runtime.CommonInfrastracture.DI;

namespace Infrastructure.DI
{
    public class Registration : IRegistrationOptions
    {
        // Delegates
        private readonly Func<DIContainer, object> _creator = null;

        // References
        private object _cachedInstance = null;

        // Runtime
        public bool IsNonLazy { get; private set; } = false;

        public Registration(Func<DIContainer, object> creator)
            => _creator = creator;

        public object CreateInstanceFrom(DIContainer container)
        {
            if (_cachedInstance != null)
                return _cachedInstance;

            if (_creator == null)
                throw new InvalidOperationException("Not has instance or creator!");

            _cachedInstance = _creator.Invoke(container);

            return _cachedInstance;
        }

        public void OnInit()
        {
            if (_cachedInstance != null)
                if (_cachedInstance is IInitable initable)
                    initable.Init();
        }

        public void OnDispose()
        {
            if (_cachedInstance != null)
                if (_cachedInstance is IDisposable disposable)
                    disposable.Dispose();
        }

        public void NonLazy()
            => IsNonLazy = true;
    }
}