using Infrastructure.DI;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.Features.Ai;
using Runtime.Gameplay.Features.Ai.States;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        // References
        private DIContainer _container = null;
        private EntitiesFactory _entitiesFactory = null;
        private BrainsFactory _brainsFactory = null;

        // Runtime
        private Entity _heroEntity = null;
        private Entity _instantMoveEntity = null;
        private Entity _ghostEntity = null;

        private bool _isRunning = false;
        public void Init(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
        }

        public void Run()
        {
            _heroEntity = _entitiesFactory.CreateHeroEntity(Vector3.zero);
            _brainsFactory.CreateKeyboardControlMainHeroBrain(_heroEntity);

            _ghostEntity = _entitiesFactory.CreateInstantMoveEntity(Vector3.zero + Vector3.left * 5f);

            _instantMoveEntity = _entitiesFactory.CreateInstantMoveEntity(Vector3.zero + Vector3.right * 5f);
            _instantMoveEntity.AddCurrentTarget();

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.R))
                _brainsFactory.CreateInstantMovementToRandomPointInRadiusGhostBrain(_ghostEntity);

            if (Input.GetKeyDown(KeyCode.T))
                _brainsFactory.CreateMovementToTargetGhostBrain(_instantMoveEntity, new LowHealthTargetSelector(_instantMoveEntity));
        }
    }
}