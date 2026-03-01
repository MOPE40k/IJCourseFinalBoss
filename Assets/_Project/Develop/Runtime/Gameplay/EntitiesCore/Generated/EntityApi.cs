namespace Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Runtime.Gameplay.Features.MovementFeatures.MoveDirection MoveDirectionC => this.GetComponent<Runtime.Gameplay.Features.MovementFeatures.MoveDirection>();

		public Runtime.Utils.Reactive.ReactiveVeriable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.MovementFeatures.MoveDirection() { Value = new Runtime.Utils.Reactive.ReactiveVeriable<UnityEngine.Vector3>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(Runtime.Utils.Reactive.ReactiveVeriable<UnityEngine.Vector3> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.MovementFeatures.MoveDirection() { Value = value });
		}

		public Runtime.Gameplay.Features.MovementFeatures.MoveSpeed MoveSpeedC => this.GetComponent<Runtime.Gameplay.Features.MovementFeatures.MoveSpeed>();

		public Runtime.Utils.Reactive.ReactiveVeriable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.MovementFeatures.MoveSpeed() { Value = new Runtime.Utils.Reactive.ReactiveVeriable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(Runtime.Utils.Reactive.ReactiveVeriable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.MovementFeatures.MoveSpeed() { Value = value });
		}

		public Runtime.Gameplay.Features.MovementFeatures.RotateSpeed RotateSpeedC => this.GetComponent<Runtime.Gameplay.Features.MovementFeatures.RotateSpeed>();

		public Runtime.Utils.Reactive.ReactiveVeriable<System.Single> RotateSpeed => RotateSpeedC.Value;

		public Runtime.Gameplay.EntitiesCore.Entity AddRotateSpeed()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.MovementFeatures.RotateSpeed() { Value = new Runtime.Utils.Reactive.ReactiveVeriable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRotateSpeed(Runtime.Utils.Reactive.ReactiveVeriable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.MovementFeatures.RotateSpeed() { Value = value });
		}

		public Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => this.GetComponent<Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return this.AddComponent(new Runtime.Gameplay.Common.RigidbodyComponent() { Value = value });
		}

		public Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => this.GetComponent<Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return this.AddComponent(new Runtime.Gameplay.Common.CharacterControllerComponent() { Value = value });
		}

		public Runtime.Gameplay.Common.TransformComponent TransformC => this.GetComponent<Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return this.AddComponent(new Runtime.Gameplay.Common.TransformComponent() { Value = value });
		}

	}
}
