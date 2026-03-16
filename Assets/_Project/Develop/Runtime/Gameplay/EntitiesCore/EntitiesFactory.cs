using UnityEngine;
using Infrastructure.DI;
using Runtime.Utils.Reactive;
using Runtime.Utils;
using Runtime.Gameplay.EntitiesCore.Mono;
using Runtime.Utils.Conditions;
using Runtime.Gameplay.Features.Movement;
using Runtime.Gameplay.Features.ApplyDamage;
using Runtime.Gameplay.Features.Sensors;
using Runtime.Gameplay.Features.ContactTakeDamage;
using Runtime.Gameplay.Features.LifeCycle;
using Runtime.Gameplay.Features.Attack;
using Runtime.Gameplay.Features.Attack.Shoot;
using Runtime.Gameplay.Features.Movement.InstantMove;
using IJCourseFinalBoss.Assets._Project.Develop.Runtime.Gameplay.Features.Stats;
using Runtime.Gameplay.Features.Stats;
using Runtime.Gameplay.Features.Attack.AreaAttack;

namespace Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        // Consts
        private const string PathToHeroPrefab = "Entities/Hero";
        private const string PathToGhostPrefab = "Entities/Ghost";
        private const string PathToInstantMoveEnemyPrefab = "Entities/InstantMoveEnemy";
        private const string PathToProjectilePrefab = "Entities/Projectile";
        private const string CharactersLayerMask = "Characters";

        // References
        private readonly DIContainer _container = null;
        private readonly EntitiesLifeContext _entitiesLifeContext = null;
        private readonly CollidersRegistryService _collidersRegistryService = null;
        private readonly MonoEntitiesFactory _monoEntitiesFactory = null;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
        }

        public Entity CreateHeroEntity(Vector3 position)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToHeroPrefab);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10f))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(900f))
                .AddMaxHealth(new ReactiveVariable<float>(70f))
                .AddCurrentHealth(new ReactiveVariable<float>(entity.MaxHealth.Value))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTimer(new ReactiveVariable<float>(2f))
                .AddDeathProcessCurrentTimer()
                .AddTakeDamageEvent()
                .AddTakeDamageRequest()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(3f))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVariable<float>(1f))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVariable<float>(50f))
                .AddAttackCanceledEvent()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(2f))
                .AddAttackCooldownCurrentTime()
                .AddInAttackCooldown();

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0f));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.IsMoving.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));

            ICompositeCondition mustCanceledAttack = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.IsMoving.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanStartAttack(canStartAttack)
                .AddMustCanceledAttack(mustCanceledAttack);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new AttackCancelSystem())
                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(this))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));


            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateGhostEntity(Vector3 position)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToGhostPrefab);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10f))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(900f))
                .AddMaxHealth(new ReactiveVariable<float>(100f))
                .AddCurrentHealth(new ReactiveVariable<float>(entity.MaxHealth.Value))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTimer(new ReactiveVariable<float>(2f))
                .AddDeathProcessCurrentTimer()
                .AddTakeDamageEvent()
                .AddTakeDamageRequest()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer(CharactersLayerMask))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(50f));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0f));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntityFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateInstantMoveEntity(Vector3 position)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToInstantMoveEnemyPrefab);

            entity
                .AddInInstantMoveProcess()
                .AddStartInstantMoveRequest()
                .AddStartInstantMoveEvent()
                .AddStartPositionBeforeInstantMove(new ReactiveVariable<Vector3>(entity.Rigidbody.position))
                .AddEndPositionForInstantMove()
                .AddRadiusForInstantMove(new ReactiveVariable<float>(5f))
                .AddEndInstantMoveEvent()
                .AddMaxStamina(new ReactiveVariable<float>(50f))
                .AddCurrentStamina(new ReactiveVariable<float>(entity.MaxStamina.Value))
                .AddStaminaCostForInstantMove(new ReactiveVariable<float>(15f))
                .AddRecoveryStaminaStep(new ReactiveVariable<float>(entity.MaxStamina.Value * 0.1f))
                .AddRecoveryStaminaInitialTime(new ReactiveVariable<float>(2f))
                .AddRecoveryStaminaCurrentTime()
                .AddRecoveryStaminaTimerCycleIsOver()
                .AddMaxHealth(new ReactiveVariable<float>(100f))
                .AddCurrentHealth(new ReactiveVariable<float>(entity.MaxHealth.Value))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTimer(new ReactiveVariable<float>(2f))
                .AddDeathProcessCurrentTimer()
                .AddTakeDamageEvent()
                .AddTakeDamageRequest()
                .AddAreaAttackRadius(new ReactiveVariable<float>(10f))
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer(CharactersLayerMask))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddAreaContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddAreaContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddAreaAttackDamage(new ReactiveVariable<float>(5f))
                .AddBodyContactDamage(new ReactiveVariable<float>(50f));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InInstantMoveProcess.Value == false))
                .Add(new FuncCondition(() => entity.CurrentStamina.Value >= entity.StaminaCostForInstantMove.Value));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0f));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canStaminaRecovery = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.CurrentStamina.Value < entity.MaxStamina.Value));

            entity
                .AddCanMove(canMove)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanStaminaRecovery(canStaminaRecovery);

            entity
                .AddSystem(new StartInstantMoveSystem())
                .AddSystem(new EndInstantMoveSystem())
                .AddSystem(new RecoveryStaminaSystem())
                .AddSystem(new RecoveryStaminaTimerSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new AreaContactsDetectingSystem())
                .AddSystem(new BodyContactsEntityFilterSystem(_collidersRegistryService))
                .AddSystem(new AreaContactsEntityFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new AreaDealDamageOnContactSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateProjectileEntity(Vector3 position, Vector3 direction, float damage)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToProjectilePrefab);

            entity
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(10f))
                .AddIsMoving()
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVariable<float>(9999f))
                .AddIsDead()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer(CharactersLayerMask))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(damage))
                .AddDeathMask(1 << LayerMask.NameToLayer(CharactersLayerMask))
                .AddIsTouchDeathMask();

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntityFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmptyEntity()
            => new Entity();
    }
}