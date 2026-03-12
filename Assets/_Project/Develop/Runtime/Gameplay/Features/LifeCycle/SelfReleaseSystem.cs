using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;

namespace Runtime.Gameplay.Features.LifeCycle
{
    public class SelfReleaseSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private readonly EntitiesLifeContext _entitiesLifeContext = null;
        private Entity _entity = null;
        private ICompositeCondition _mustSelfRelease = null;

        public SelfReleaseSystem(EntitiesLifeContext entitiesLifeContext)
            => _entitiesLifeContext = entitiesLifeContext;

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _mustSelfRelease = entity.MustSelfRelease;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_mustSelfRelease.Evaluate())
                _entitiesLifeContext.Release(_entity);
        }
    }
}