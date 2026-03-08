using Infrastructure.DI;
using Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        // References
        private DIContainer _container = null;
        private EntitiesFactory _entitiesFactory = null;

        // Runtime
        private Entity _heroEntity = null;
        private Entity _instantMoveEntity = null;

        private bool _isRunning = false;

        private Vector3 _inputDirection = Vector3.zero;

        public void Init(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();

            _heroEntity = _entitiesFactory.CreateHeroEntity(Vector3.zero);

            _instantMoveEntity = _entitiesFactory.CreateInstantMoveEntity(
                new Vector3(Random.Range(1f, 5f), 0f, Random.Range(1f, 5f)));
        }

        public void Run()
            => _isRunning = true;

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _instantMoveEntity.StartInstantMoveRequest.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.R))
                _heroEntity.StartAttackRequest.Invoke();

            _inputDirection = new(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            _heroEntity.MoveDirection.Value = _inputDirection;
            _heroEntity.RotationDirection.Value = _inputDirection;
        }
    }
}