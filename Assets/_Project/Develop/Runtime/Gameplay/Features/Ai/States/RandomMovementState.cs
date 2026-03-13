using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class RandomMovementState : State, IUpdatableState
    {
        // References
        private readonly ReactiveVariable<Vector3> _movementDirection = null;
        private readonly ReactiveVariable<Vector3> _rotationDirection = null;

        // Settings
        private readonly float _cooldownBetweenDirectionGeneration = 0f;

        // Runtime
        private float _time = 0f;

        public RandomMovementState(Entity entity, float cooldownBetweenDirectionGeneration)
        {
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

            _cooldownBetweenDirectionGeneration = cooldownBetweenDirectionGeneration;
        }

        public override void Enter()
        {
            base.Enter();

            Vector3 randomDirection = new Vector3(Random.Range(0f, 1f), 0f, Random.Range(0f, 1f)).normalized;

            _movementDirection.Value = randomDirection;
            _rotationDirection.Value = randomDirection;

            ResetTime();
        }

        public override void Exit()
        {
            base.Exit();

            _movementDirection.Value = Vector3.zero;
        }

        public void UpdateTick(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= _cooldownBetweenDirectionGeneration)
            {
                GenerateNewDirection();

                ResetTime();
            }
        }

        private void GenerateNewDirection()
        {
            Vector3 inverseDirection = -_movementDirection.Value.normalized;

            Quaternion randomTurn = Quaternion.Euler(Random.Range(0f, 30f), 0f, Random.Range(0f, 30f));

            Vector3 newDirection = randomTurn * inverseDirection;

            _movementDirection.Value = newDirection;
            _rotationDirection.Value = newDirection;
        }

        private void ResetTime()
            => _time = 0f;
    }
}