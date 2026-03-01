using UnityEngine;
using Infrastructure.DI;
using Runtime.Utils.Reactive;
using Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures;
using Runtime.Gameplay.EntitiesCore.Mono;

namespace Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        // Consts
        private const string PathToRigidbodyTestEntity = "Entities/RigidbodyTestEntity";
        private const string PathToCharacterControllerTestEntity = "Entities/CharacterControllerTestEntity";
        private const string PathToTransformTestEntity = "Entities/TransformTestEntity";

        // References
        private readonly DIContainer _container = null;
        private readonly EntitiesLifeContext _entitiesLifeContext = null;
        private readonly MonoEntitiesFactory _monoEntitiesFactory = null;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
        }

        public Entity CreateTestEntity(Vector3 position)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToRigidbodyTestEntity);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVeriable<float>(10f));

            entity
                .AddSystem(new RigidbodyMovementSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }
        public Entity CreateRigidbodyMoveEntity(Vector3 position)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToRigidbodyTestEntity);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVeriable<float>(10f))
                .AddRotateSpeed(new ReactiveVeriable<float>(900f));

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }
        public Entity CreateCharacterControllerMoveEntity(Vector3 position)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToCharacterControllerTestEntity);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVeriable<float>(10f))
                .AddRotateSpeed(new ReactiveVeriable<float>(900f));

            entity
                .AddSystem(new CharacterControllerMovementSystem())
                .AddSystem(new TransformRotationSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateTransformMoveEntity(Vector3 position)
        {
            Entity entity = CreateEmptyEntity();

            _monoEntitiesFactory.Create(entity, position, PathToTransformTestEntity);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVeriable<float>(10f))
                .AddRotateSpeed(new ReactiveVeriable<float>(900f));

            entity
                .AddSystem(new TransformMovementSystem())
                .AddSystem(new TransformRotationSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmptyEntity()
            => new Entity();
    }
}