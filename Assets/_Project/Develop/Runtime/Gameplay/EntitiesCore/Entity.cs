using System;
using System.Collections.Generic;
using Runtime.Gameplay.EntitiesCore.Systems;

namespace Runtime.Gameplay.EntitiesCore
{
    public partial class Entity : IDisposable
    {
        // Runtime
        private readonly Dictionary<Type, IEntityComponent> _components = new();

        private readonly List<IEntitySystem> _systems = new();
        private readonly List<IInitializableSystem> _initializables = new();
        private readonly List<IUpdatableSystem> _updatables = new();
        private readonly List<IFixedUpdatableSystem> _fixedUpdatables = new();
        private readonly List<IDisposableSystem> _disposables = new();

        public bool IsInit { get; private set; } = false;

        public void Init()
        {
            foreach (IInitializableSystem initializable in _initializables)
                initializable.OnInit(this);

            IsInit = true;
        }

        public void UpdateTick(float deltaTime)
        {
            if (IsInit == false)
                return;

            foreach (IUpdatableSystem updatable in _updatables)
                updatable.OnUpdateTick(deltaTime);
        }

        public void FixedUpdateTick(float fixedDeltaTime)
        {
            if (IsInit == false)
                return;

            foreach (IFixedUpdatableSystem fixedUpdatable in _fixedUpdatables)
                fixedUpdatable.OnFixedUpdateTick(fixedDeltaTime);
        }

        public void Dispose()
        {
            foreach (IDisposableSystem disposable in _disposables)
                disposable.OnDispose();

            IsInit = false;
        }

        public bool HasComponent<TComponent>() where TComponent : class, IEntityComponent
            => _components.ContainsKey(typeof(TComponent));

        public Entity AddComponent<TComponent>(TComponent component) where TComponent : class, IEntityComponent
        {
            _components.Add(typeof(TComponent), component);

            return this;
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : class, IEntityComponent
        {
            if (_components.TryGetValue(typeof(TComponent), out IEntityComponent foundedComponent))
            {
                component = (TComponent)foundedComponent;

                return true;
            }

            component = null;

            return false;
        }

        public TComponent GetComponent<TComponent>() where TComponent : class, IEntityComponent
        {
            if (TryGetComponent(out TComponent entityComponent) == false)
                throw new ArgumentException($"Entity {typeof(TComponent)} not found!");

            return entityComponent;
        }

        public Entity AddSystem(IEntitySystem system)
        {
            if (_systems.Contains(system))
                throw new ArgumentException(system.GetType().ToString());

            _systems.Add(system);

            if (system is IInitializableSystem initializable)
            {
                _initializables.Add(initializable);

                if (IsInit)
                    initializable.OnInit(this);
            }

            if (system is IUpdatableSystem updatable)
                _updatables.Add(updatable);

            if (system is IFixedUpdatableSystem fixedUpdatable)
                _fixedUpdatables.Add(fixedUpdatable);

            if (system is IDisposableSystem disposable)
                _disposables.Add(disposable);

            return this;
        }
    }
}