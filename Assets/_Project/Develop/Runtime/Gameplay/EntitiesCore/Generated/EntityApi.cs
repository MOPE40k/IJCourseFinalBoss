namespace Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Runtime.Gameplay.Features.Stats.MaxStamina MaxStaminaC => this.GetComponent<Runtime.Gameplay.Features.Stats.MaxStamina>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> MaxStamina => MaxStaminaC.Value;

		public bool TryGetMaxStamina (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Stats.MaxStamina component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMaxStamina()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.MaxStamina() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMaxStamina(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.MaxStamina() { Value = value });
		}

		public Runtime.Gameplay.Features.Stats.CurrentStamina CurrentStaminaC => this.GetComponent<Runtime.Gameplay.Features.Stats.CurrentStamina>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> CurrentStamina => CurrentStaminaC.Value;

		public bool TryGetCurrentStamina (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Stats.CurrentStamina component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCurrentStamina()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.CurrentStamina() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCurrentStamina(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.CurrentStamina() { Value = value });
		}

		public Runtime.Gameplay.Features.Stats.RecoveryStaminaStep RecoveryStaminaStepC => this.GetComponent<Runtime.Gameplay.Features.Stats.RecoveryStaminaStep>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> RecoveryStaminaStep => RecoveryStaminaStepC.Value;

		public bool TryGetRecoveryStaminaStep (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Stats.RecoveryStaminaStep component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaStep()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaStep() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaStep(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaStep() { Value = value });
		}

		public Runtime.Gameplay.Features.Stats.RecoveryStaminaInitialTime RecoveryStaminaInitialTimeC => this.GetComponent<Runtime.Gameplay.Features.Stats.RecoveryStaminaInitialTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> RecoveryStaminaInitialTime => RecoveryStaminaInitialTimeC.Value;

		public bool TryGetRecoveryStaminaInitialTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Stats.RecoveryStaminaInitialTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaInitialTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaInitialTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaInitialTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaInitialTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Stats.RecoveryStaminaCurrentTime RecoveryStaminaCurrentTimeC => this.GetComponent<Runtime.Gameplay.Features.Stats.RecoveryStaminaCurrentTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> RecoveryStaminaCurrentTime => RecoveryStaminaCurrentTimeC.Value;

		public bool TryGetRecoveryStaminaCurrentTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Stats.RecoveryStaminaCurrentTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaCurrentTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaCurrentTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaCurrentTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaCurrentTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Stats.CanStaminaRecovery CanStaminaRecoveryC => this.GetComponent<Runtime.Gameplay.Features.Stats.CanStaminaRecovery>();

		public Runtime.Utils.Conditions.ICompositeCondition CanStaminaRecovery => CanStaminaRecoveryC.Value;

		public bool TryGetCanStaminaRecovery (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Stats.CanStaminaRecovery component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCanStaminaRecovery(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.CanStaminaRecovery() { Value = value });
		}

		public Runtime.Gameplay.Features.Stats.RecoveryStaminaTimerCycleIsOver RecoveryStaminaTimerCycleIsOverC => this.GetComponent<Runtime.Gameplay.Features.Stats.RecoveryStaminaTimerCycleIsOver>();

		public Runtime.Utils.Reactive.ReactiveEvent RecoveryStaminaTimerCycleIsOver => RecoveryStaminaTimerCycleIsOverC.Value;

		public bool TryGetRecoveryStaminaTimerCycleIsOver (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Stats.RecoveryStaminaTimerCycleIsOver component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaTimerCycleIsOver()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaTimerCycleIsOver() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRecoveryStaminaTimerCycleIsOver(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Stats.RecoveryStaminaTimerCycleIsOver() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => this.GetComponent<Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.SphereCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider (out UnityEngine.SphereCollider value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.BodyCollider component);

			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.SphereCollider);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.SphereCollider value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.BodyCollider() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => this.GetComponent<Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask (out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.ContactsDetectingMask component);

			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => this.GetComponent<Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public Runtime.Utils.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public bool TryGetContactCollidersBuffer (out Runtime.Utils.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Buffer<UnityEngine.Collider>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(Runtime.Utils.Buffer<UnityEngine.Collider> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.AreaContactCollidersBuffer AreaContactCollidersBufferC => this.GetComponent<Runtime.Gameplay.Features.Sensors.AreaContactCollidersBuffer>();

		public Runtime.Utils.Buffer<UnityEngine.Collider> AreaContactCollidersBuffer => AreaContactCollidersBufferC.Value;

		public bool TryGetAreaContactCollidersBuffer (out Runtime.Utils.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.AreaContactCollidersBuffer component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Buffer<UnityEngine.Collider>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAreaContactCollidersBuffer(Runtime.Utils.Buffer<UnityEngine.Collider> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.AreaContactCollidersBuffer() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => this.GetComponent<Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer (out Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.AreaContactEntitiesBuffer AreaContactEntitiesBufferC => this.GetComponent<Runtime.Gameplay.Features.Sensors.AreaContactEntitiesBuffer>();

		public Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity> AreaContactEntitiesBuffer => AreaContactEntitiesBufferC.Value;

		public bool TryGetAreaContactEntitiesBuffer (out Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.AreaContactEntitiesBuffer component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAreaContactEntitiesBuffer(Runtime.Utils.Buffer<Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.AreaContactEntitiesBuffer() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.DeathMask DeathMaskC => this.GetComponent<Runtime.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask (out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.DeathMask component);

			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.DeathMask() { Value = value });
		}

		public Runtime.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => this.GetComponent<Runtime.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask (out Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Sensors.IsTouchDeathMask component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.MoveDirection MoveDirectionC => this.GetComponent<Runtime.Gameplay.Features.Movement.MoveDirection>();

		public Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection (out Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.MoveDirection component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.MoveDirection() { Value = new Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.MoveDirection() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.MoveSpeed MoveSpeedC => this.GetComponent<Runtime.Gameplay.Features.Movement.MoveSpeed>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.MoveSpeed component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.MoveSpeed() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.MoveSpeed() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.IsMoving IsMovingC => this.GetComponent<Runtime.Gameplay.Features.Movement.IsMoving>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving (out Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.IsMoving component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.IsMoving() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.IsMoving() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.RotationDirection RotationDirectionC => this.GetComponent<Runtime.Gameplay.Features.Movement.RotationDirection>();

		public Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection (out Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.RotationDirection component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.RotationDirection() { Value = new Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.RotationDirection() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.RotationSpeed RotationSpeedC => this.GetComponent<Runtime.Gameplay.Features.Movement.RotationSpeed>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public bool TryGetRotationSpeed (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.RotationSpeed component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.RotationSpeed() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.RotationSpeed() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.CanMove CanMoveC => this.GetComponent<Runtime.Gameplay.Features.Movement.CanMove>();

		public Runtime.Utils.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.CanMove component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCanMove(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.CanMove() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.CanRotate CanRotateC => this.GetComponent<Runtime.Gameplay.Features.Movement.CanRotate>();

		public Runtime.Utils.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.CanRotate component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.CanRotate() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveRequest StartInstantMoveRequestC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveRequest>();

		public Runtime.Utils.Reactive.ReactiveEvent StartInstantMoveRequest => StartInstantMoveRequestC.Value;

		public bool TryGetStartInstantMoveRequest (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveRequest component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartInstantMoveRequest()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveRequest() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartInstantMoveRequest(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveRequest() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveEvent StartInstantMoveEventC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveEvent>();

		public Runtime.Utils.Reactive.ReactiveEvent StartInstantMoveEvent => StartInstantMoveEventC.Value;

		public bool TryGetStartInstantMoveEvent (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveEvent component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartInstantMoveEvent()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveEvent() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartInstantMoveEvent(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.StartInstantMoveEvent() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.EndInstantMoveEvent EndInstantMoveEventC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.EndInstantMoveEvent>();

		public Runtime.Utils.Reactive.ReactiveEvent EndInstantMoveEvent => EndInstantMoveEventC.Value;

		public bool TryGetEndInstantMoveEvent (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.EndInstantMoveEvent component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddEndInstantMoveEvent()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.EndInstantMoveEvent() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddEndInstantMoveEvent(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.EndInstantMoveEvent() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.InInstantMoveProcess InInstantMoveProcessC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.InInstantMoveProcess>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> InInstantMoveProcess => InInstantMoveProcessC.Value;

		public bool TryGetInInstantMoveProcess (out Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.InInstantMoveProcess component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInInstantMoveProcess()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InInstantMoveProcess() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInInstantMoveProcess(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InInstantMoveProcess() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessInitialTime InstantMoveProcessInitialTimeC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessInitialTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> InstantMoveProcessInitialTime => InstantMoveProcessInitialTimeC.Value;

		public bool TryGetInstantMoveProcessInitialTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessInitialTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveProcessInitialTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessInitialTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveProcessInitialTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessInitialTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessCurrentTime InstantMoveProcessCurrentTimeC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessCurrentTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> InstantMoveProcessCurrentTime => InstantMoveProcessCurrentTimeC.Value;

		public bool TryGetInstantMoveProcessCurrentTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessCurrentTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveProcessCurrentTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessCurrentTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveProcessCurrentTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveProcessCurrentTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.StartPosition StartPositionC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.StartPosition>();

		public Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> StartPosition => StartPositionC.Value;

		public bool TryGetStartPosition (out Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.StartPosition component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartPosition()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.StartPosition() { Value = new Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartPosition(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.StartPosition() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveDestinationPosition InstantMoveDestinationPositionC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveDestinationPosition>();

		public Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> InstantMoveDestinationPosition => InstantMoveDestinationPositionC.Value;

		public bool TryGetInstantMoveDestinationPosition (out Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveDestinationPosition component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveDestinationPosition()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveDestinationPosition() { Value = new Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveDestinationPosition(Runtime.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveDestinationPosition() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.MoveRadius MoveRadiusC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.MoveRadius>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> MoveRadius => MoveRadiusC.Value;

		public bool TryGetMoveRadius (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.MoveRadius component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveRadius()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.MoveRadius() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMoveRadius(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.MoveRadius() { Value = value });
		}

		public Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveStaminaCost InstantMoveStaminaCostC => this.GetComponent<Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveStaminaCost>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> InstantMoveStaminaCost => InstantMoveStaminaCostC.Value;

		public bool TryGetInstantMoveStaminaCost (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveStaminaCost component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveStaminaCost()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveStaminaCost() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantMoveStaminaCost(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Movement.InstantMove.InstantMoveStaminaCost() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.CurrentHealth component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.CurrentHealth() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.CurrentHealth() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.MaxHealth component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.MaxHealth() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.MaxHealth() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public bool TryGetIsDead (out Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.IsDead component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.IsDead() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddIsDead(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.IsDead() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.MustDie MustDieC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.MustDie>();

		public Runtime.Utils.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.MustDie component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMustDie(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.MustDie() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public Runtime.Utils.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.MustSelfRelease component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.MustSelfRelease() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTimer DeathProcessInitialTimerC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTimer>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTimer => DeathProcessInitialTimerC.Value;

		public bool TryGetDeathProcessInitialTimer (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTimer component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTimer()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTimer() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTimer(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTimer() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTimer DeathProcessCurrentTimerC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTimer>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTimer => DeathProcessCurrentTimerC.Value;

		public bool TryGetDeathProcessCurrentTimer (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTimer component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTimer()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTimer() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTimer(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTimer() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.InDeathProcess>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public bool TryGetInDeathProcess (out Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.InDeathProcess component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.InDeathProcess() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.InDeathProcess() { Value = value });
		}

		public Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => this.GetComponent<Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath (out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);

			if (result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() { Value = new System.Collections.Generic.List<UnityEngine.Collider>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() { Value = value });
		}

		public Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => this.GetComponent<Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => this.GetComponent<Runtime.Gameplay.Features.Attack.StartAttackRequest>();

		public Runtime.Utils.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.StartAttackRequest component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.StartAttackRequest() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.StartAttackRequest() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => this.GetComponent<Runtime.Gameplay.Features.Attack.StartAttackEvent>();

		public Runtime.Utils.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.StartAttackEvent component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.StartAttackEvent() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.StartAttackEvent() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => this.GetComponent<Runtime.Gameplay.Features.Attack.CanStartAttack>();

		public Runtime.Utils.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.CanStartAttack component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.CanStartAttack() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => this.GetComponent<Runtime.Gameplay.Features.Attack.EndAttackEvent>();

		public Runtime.Utils.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.EndAttackEvent component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.EndAttackEvent() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.EndAttackEvent() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => this.GetComponent<Runtime.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AttackProcessInitialTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => this.GetComponent<Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.InAttackProcess InAttackProcessC => this.GetComponent<Runtime.Gameplay.Features.Attack.InAttackProcess>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetInAttackProcess (out Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.InAttackProcess component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.InAttackProcess() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.InAttackProcess() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => this.GetComponent<Runtime.Gameplay.Features.Attack.AttackDelayTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AttackDelayTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackDelayTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackDelayTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => this.GetComponent<Runtime.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public Runtime.Utils.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AttackDelayEndEvent component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => this.GetComponent<Runtime.Gameplay.Features.Attack.InstantAttackDamage>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.InstantAttackDamage component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.InstantAttackDamage() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.InstantAttackDamage() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.ShootPoint ShootPointC => this.GetComponent<Runtime.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint (out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.ShootPoint component);

			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.ShootPoint() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.MustCanceledAttack MustCanceledAttackC => this.GetComponent<Runtime.Gameplay.Features.Attack.MustCanceledAttack>();

		public Runtime.Utils.Conditions.ICompositeCondition MustCanceledAttack => MustCanceledAttackC.Value;

		public bool TryGetMustCanceledAttack (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.MustCanceledAttack component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddMustCanceledAttack(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.MustCanceledAttack() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AttackCanceledEvent AttackCanceledEventC => this.GetComponent<Runtime.Gameplay.Features.Attack.AttackCanceledEvent>();

		public Runtime.Utils.Reactive.ReactiveEvent AttackCanceledEvent => AttackCanceledEventC.Value;

		public bool TryGetAttackCanceledEvent (out Runtime.Utils.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AttackCanceledEvent component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackCanceledEvent() { Value = new Runtime.Utils.Reactive.ReactiveEvent() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent(Runtime.Utils.Reactive.ReactiveEvent value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackCanceledEvent() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => this.GetComponent<Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => this.GetComponent<Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public bool TryGetAttackCooldownCurrentTime (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => this.GetComponent<Runtime.Gameplay.Features.Attack.InAttackCooldown>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown (out Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.InAttackCooldown component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.InAttackCooldown() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(Runtime.Utils.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.InAttackCooldown() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackRadius AreaAttackRadiusC => this.GetComponent<Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackRadius>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> AreaAttackRadius => AreaAttackRadiusC.Value;

		public bool TryGetAreaAttackRadius (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackRadius component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAreaAttackRadius()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackRadius() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAreaAttackRadius(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackRadius() { Value = value });
		}

		public Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackDamage AreaAttackDamageC => this.GetComponent<Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackDamage>();

		public Runtime.Utils.Reactive.ReactiveVariable<System.Single> AreaAttackDamage => AreaAttackDamageC.Value;

		public bool TryGetAreaAttackDamage (out Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackDamage component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAreaAttackDamage()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackDamage() { Value = new Runtime.Utils.Reactive.ReactiveVariable<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddAreaAttackDamage(Runtime.Utils.Reactive.ReactiveVariable<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Attack.AreaAttack.AreaAttackDamage() { Value = value });
		}

		public Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => this.GetComponent<Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public Runtime.Utils.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest (out Runtime.Utils.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() { Value = new Runtime.Utils.Reactive.ReactiveEvent<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Runtime.Utils.Reactive.ReactiveEvent<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() { Value = value });
		}

		public Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => this.GetComponent<Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public Runtime.Utils.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public bool TryGetTakeDamageEvent (out Runtime.Utils.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveEvent<System.Single>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() { Value = new Runtime.Utils.Reactive.ReactiveEvent<System.Single>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(Runtime.Utils.Reactive.ReactiveEvent<System.Single> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() { Value = value });
		}

		public Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => this.GetComponent<Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public Runtime.Utils.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public bool TryGetCanApplyDamage (out Runtime.Utils.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Conditions.ICompositeCondition);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(Runtime.Utils.Conditions.ICompositeCondition value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage() { Value = value });
		}

		public Runtime.Gameplay.Features.Ai.CurrentTarget CurrentTargetC => this.GetComponent<Runtime.Gameplay.Features.Ai.CurrentTarget>();

		public Runtime.Utils.Reactive.ReactiveVariable<Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget (out Runtime.Utils.Reactive.ReactiveVariable<Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Features.Ai.CurrentTarget component);

			if (result)
				value = component.Value;
			else
				value = default(Runtime.Utils.Reactive.ReactiveVariable<Runtime.Gameplay.EntitiesCore.Entity>);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Ai.CurrentTarget() { Value = new Runtime.Utils.Reactive.ReactiveVariable<Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(Runtime.Utils.Reactive.ReactiveVariable<Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return this.AddComponent(new Runtime.Gameplay.Features.Ai.CurrentTarget() { Value = value });
		}

		public Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => this.GetComponent<Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody (out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Common.RigidbodyComponent component);

			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return this.AddComponent(new Runtime.Gameplay.Common.RigidbodyComponent() { Value = value });
		}

		public Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => this.GetComponent<Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public bool TryGetCharacterController (out UnityEngine.CharacterController value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Common.CharacterControllerComponent component);

			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.CharacterController);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return this.AddComponent(new Runtime.Gameplay.Common.CharacterControllerComponent() { Value = value });
		}

		public Runtime.Gameplay.Common.TransformComponent TransformC => this.GetComponent<Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform (out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Runtime.Gameplay.Common.TransformComponent component);

			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);

			return result;
		}

		public Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return this.AddComponent(new Runtime.Gameplay.Common.TransformComponent() { Value = value });
		}

	}
}
