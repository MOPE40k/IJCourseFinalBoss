using System;
using System.Collections.Generic;
using Runtime.Utils.StateMachineCore;

namespace Runtime.Gameplay.Features.Ai
{
    public class AiStateMachine : StateMachine<IUpdatableState>
    {
        public AiStateMachine(List<IDisposable> disposables) : base(disposables)
        { }

        public AiStateMachine() : base(new List<IDisposable>())
        { }

        protected override void UpdateLogic(float deltaTime)
        {
            base.UpdateLogic(deltaTime);

            CurrentState?.UpdateTick(deltaTime);
        }
    }
}