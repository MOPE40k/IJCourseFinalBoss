using System.Collections.Generic;
using System.Linq;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.Features.ApplyDamage;
using Runtime.Utils.Conditions;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class NearestDamageableTargetSelector : ITargetSelector
    {
        // References
        private readonly Entity _source = null;
        private readonly Transform _sourceTransform = null;

        public NearestDamageableTargetSelector(Entity source)
        {
            _source = source;
            _sourceTransform = _source.Transform;
        }

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

            Entity closestTarget = selectedTargets.First();
            float minDistance = GetDistanceTo(closestTarget);

            foreach (Entity target in selectedTargets)
            {
                float distance = GetDistanceTo(target);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTarget = target;
                }
            }

            return closestTarget;
        }

        private float GetDistanceTo(Entity target)
            => (_sourceTransform.position - target.Transform.position).magnitude;
    }
}