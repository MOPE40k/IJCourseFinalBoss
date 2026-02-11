using System;

namespace Infrastructure.DI
{
    public class Registration
    {
        // Delegates
        private readonly Func<DIContainer, object> _creator = null;

        // References
        private object _cachedInstance = null;

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
    }
}