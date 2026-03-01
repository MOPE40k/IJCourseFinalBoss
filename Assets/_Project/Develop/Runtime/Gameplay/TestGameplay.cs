using Infrastructure.DI;
using Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Transform _rigidbodySpawnPosition = null;
        [SerializeField] private Transform _characterControllerSpawnPosition = null;
        [SerializeField] private Transform _transformSpawnPosition = null;

        // References
        private DIContainer _container = null;
        private EntitiesFactory _entitiesFactory = null;

        // Runtime
        private Entity _rigidbodyMoveEntity = null;
        private Entity _characterControllerMoveEntity = null;
        private Entity _transformMoveEntity = null;

        private bool _isRunning = false;

        private Vector3 _inputDirection = Vector3.zero;

        public void Init(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();

            _rigidbodyMoveEntity = _entitiesFactory.CreateRigidbodyMoveEntity(_rigidbodySpawnPosition.position);
            _characterControllerMoveEntity = _entitiesFactory.CreateCharacterControllerMoveEntity(_characterControllerSpawnPosition.position);
            _transformMoveEntity = _entitiesFactory.CreateTransformMoveEntity(_transformSpawnPosition.position);
        }

        public void Run()
            => _isRunning = true;

        private void Update()
        {
            if (_isRunning == false)
                return;

            _inputDirection = new(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            _rigidbodyMoveEntity.MoveDirection.Value = _inputDirection;
            _characterControllerMoveEntity.MoveDirection.Value = _inputDirection;
            _transformMoveEntity.MoveDirection.Value = _inputDirection;
        }
    }
}