using System;
using System.Collections.Generic;
using Infrastructure.DI;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.Features.Ai.States;
using Runtime.Gameplay.Features.Ai.States.InstantMove;
using Runtime.Gameplay.Features.InputFeature;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using Runtime.Utils.Timer;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai
{
    public class BrainsFactory
    {
        // References
        private readonly DIContainer _container = null;
        private readonly TimerServiceFactory _timerServiceFactory = null;
        private readonly AiBrainsContext _aiBrainsContext = null;
        private readonly IInputService _inputService = null;
        private readonly EntitiesLifeContext _entitiesLifeContext = null;

        public BrainsFactory(DIContainer container)
        {
            _container = container;

            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _aiBrainsContext = _container.Resolve<AiBrainsContext>();
            _inputService = container.Resolve<IInputService>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
        }

        public StateMachineBrain CreateKeyboardControlMainHeroBrain(Entity entity)
        {
            AiStateMachine movementState = CreatePlayerInputStateMachine(entity);
            PlayerInputStartAttackState attackState = new PlayerInputStartAttackState(entity, _inputService);

            ICondition canAttack = entity.CanStartAttack;

            ICompositeCondition fromMovementToAttackState = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() => _inputService.IsFire == true));

            ICompositeCondition fromAttackToMovementState = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AiStateMachine behaviour = new AiStateMachine();

            behaviour
                .AddState(movementState)
                .AddState(attackState);

            behaviour
                .AddTransition(movementState, attackState, fromMovementToAttackState)
                .AddTransition(attackState, movementState, fromAttackToMovementState);

            StateMachineBrain brain = new StateMachineBrain(behaviour);

            _aiBrainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AiStateMachine combatState = CreateAutoAttackStateMachine(entity);
            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            IReadOnlyVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromMovementToCombatStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => currentTarget.Value != null))
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));

            ICompositeCondition fromCombatToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => currentTarget.Value == null))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AiStateMachine behaviour = new AiStateMachine();

            behaviour
                .AddState(movementState)
                .AddState(combatState);

            behaviour
                .AddTransition(movementState, combatState, fromMovementToCombatStateCondition)
                .AddTransition(combatState, movementState, fromCombatToMovementStateCondition);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);

            AiParallelState parallelState = new AiParallelState(new State[]
            {
                findTargetState,
                behaviour
            });

            AiStateMachine rootStateMachine = new AiStateMachine();

            rootStateMachine
                .AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);

            _aiBrainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateInstantMovementToTargetGhostBrain(
            Entity entity,
            ITargetSelector targetSelector,
            IInstantMoveEndPointProvider moveEndPointProvider)
        {
            AiStateMachine movementState = CreateInstantMovementToRandomPointInRadiusStateMachine(entity, moveEndPointProvider);
            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);

            IReadOnlyVariable<Entity> currentTarget = entity.CurrentTarget;

            IReadOnlyVariable<float> currentStamina = entity.CurrentStamina;
            IReadOnlyVariable<float> maxStamina = entity.MaxStamina;

            ICompositeCondition fromMovementToFindStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => currentTarget.Value == null));

            ICompositeCondition fromFindToMovementStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => currentTarget.Value != null))
                .Add(new FuncCondition(() => currentStamina.Value >= maxStamina.Value * 0.4f));

            AiStateMachine stateMachine = new AiStateMachine();

            stateMachine
                .AddState(findTargetState)
                .AddState(movementState);

            stateMachine
                .AddTransition(findTargetState, movementState, fromFindToMovementStateCondition)
                .AddTransition(movementState, findTargetState, fromMovementToFindStateCondition);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _aiBrainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateRandomMovementGhostBrain(Entity entity)
        {
            AiStateMachine stateMachine = CreateRandomMovementStateMachine(entity);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _aiBrainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateInstantMovementToRandomPointGhostBrain(
            Entity entity,
            IInstantMoveEndPointProvider moveEndPointProvider)
        {
            AiStateMachine stateMachine = CreateInstantMovementToRandomPointInRadiusStateMachine(entity, moveEndPointProvider);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _aiBrainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreatePlayerInputBrain(Entity entity)
        {
            AiStateMachine stateMachine = CreatePlayerInputStateMachine(entity);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _aiBrainsContext.SetFor(entity, brain);

            return brain;
        }

        private AiStateMachine CreatePlayerInputStateMachine(Entity entity)
        {
            PlayerInputRotationState rotationState = new PlayerInputRotationState(entity, _inputService);
            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            ICompositeCondition fromMovementToRotationStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));

            ICompositeCondition fromRotationToMovementStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AiStateMachine stateMachine = new AiStateMachine();

            stateMachine
                .AddState(movementState)
                .AddState(rotationState);

            stateMachine
                .AddTransition(movementState, rotationState, fromMovementToRotationStateCondition)
                .AddTransition(rotationState, movementState, fromRotationToMovementStateCondition);

            return stateMachine;
        }

        private AiStateMachine CreateRandomMovementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new();

            RandomMovementState randomMovementState = new RandomMovementState(entity, 0.5f);
            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subscribe(movementTimer.Restart));

            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            ICompositeCondition movementEndedTimeCondition = new CompositeCondition()
                .Add(new FuncCondition(() => movementTimer.IsOver));

            ICompositeCondition idleEndedTimeCondition = new CompositeCondition()
                .Add(new FuncCondition(() => idleTimer.IsOver));

            AiStateMachine stateMachine = new AiStateMachine();

            stateMachine
                .AddState(randomMovementState)
                .AddState(emptyState);

            stateMachine
                .AddTransition(randomMovementState, emptyState, movementEndedTimeCondition)
                .AddTransition(emptyState, randomMovementState, idleEndedTimeCondition);

            return stateMachine;
        }

        private AiStateMachine CreateInstantMovementToRandomPointInRadiusStateMachine(
            Entity entity,
            IInstantMoveEndPointProvider moveEndPointProvider)
        {
            List<IDisposable> disposables = new();

            InstantMoveToRandomPointState moveToRandomPointState
                = new InstantMoveToRandomPointState(entity, moveEndPointProvider);

            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(1f);
            disposables.Add(movementTimer);
            disposables.Add(moveToRandomPointState.Entered.Subscribe(movementTimer.Restart));

            TimerService idleTimer = _timerServiceFactory.Create(1f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            IReadOnlyVariable<float> currentStamina = entity.CurrentStamina;
            IReadOnlyVariable<float> instantMoveStaminaCost = entity.StaminaCostForInstantMove;

            ICompositeCondition movementEndedTimeCondition = new CompositeCondition()
                .Add(new FuncCondition(() => movementTimer.IsOver));

            ICompositeCondition idleEndedTimeCondition = new CompositeCondition()
                .Add(new FuncCondition(() => idleTimer.IsOver))
                .Add(new FuncCondition(() => currentStamina.Value >= instantMoveStaminaCost.Value));

            AiStateMachine stateMachine = new AiStateMachine();

            stateMachine
                .AddState(moveToRandomPointState)
                .AddState(emptyState);

            stateMachine
                .AddTransition(emptyState, moveToRandomPointState, idleEndedTimeCondition)
                .AddTransition(moveToRandomPointState, emptyState, movementEndedTimeCondition);

            return stateMachine;
        }

        private AiStateMachine CreateAutoAttackStateMachine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);
            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;

            Transform transform = entity.Transform;
            IReadOnlyVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromRotateToAttackStateCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target is null)
                        return false;

                    float angleToTarget = Quaternion.Angle(
                        transform.rotation,
                        Quaternion.LookRotation(target.Transform.position - transform.position));

                    return angleToTarget < 1f;
                }));

            IReadOnlyVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICompositeCondition fromAttackToRotateStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => inAttackProcess.Value == false));

            AiStateMachine stateMachine = new AiStateMachine();

            stateMachine
                .AddState(rotateToTargetState)
                .AddState(attackTriggerState);

            stateMachine
                .AddTransition(rotateToTargetState, attackTriggerState, fromRotateToAttackStateCondition)
                .AddTransition(attackTriggerState, rotateToTargetState, fromAttackToRotateStateCondition);

            return stateMachine;
        }
    }
}