using Infrastructure.DI;
using Utils.CoroutinesManagement;

namespace Runtime.Utils.Timer
{
    public class TimerServiceFactory
    {
        // References
        private readonly DIContainer _container = null;

        public TimerServiceFactory(DIContainer container)
            => _container = container;

        public TimerService Create(float cooldown)
            => new TimerService(_container.Resolve<ICoroutinePerformer>(), cooldown);
    }
}