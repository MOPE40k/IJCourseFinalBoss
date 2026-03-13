using System.Collections.Generic;
using System.Linq;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.Features.ApplyDamage;
using Runtime.Utils.Conditions;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class LowHealthTargetSelector : ITargetSelector
    {
        // References
        private readonly Entity _source = null;

        public LowHealthTargetSelector(Entity source)
            => _source = source;

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<TakeDamageRequest>();

                if (target.TryGetCanApplyDamage(out ICompositeCondition canApplyDamage))
                    result = result && canApplyDamage.Evaluate();

                result = result && (target != _source);

                return result;
            });

            if (selectedTargets.Any() == false)
                return null;

            Entity lowHealthTarget = selectedTargets.First();
            float lowHealth = GetHealthTo(lowHealthTarget);

            foreach (Entity target in selectedTargets)
            {
                float currentHealth = GetHealthTo(target);

                if (currentHealth < lowHealth)
                {
                    lowHealth = currentHealth;
                    lowHealthTarget = target;
                }
            }

            return lowHealthTarget;
        }

        private float GetHealthTo(Entity target)
            => target.CurrentHealth.Value;
    }
}