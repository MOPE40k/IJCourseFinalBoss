using System;

namespace Runtime.Utils.Conditions
{
    public class FuncCondition : ICondition
    {
        private readonly Func<bool> _condition = null;

        public FuncCondition(Func<bool> condition)
            => _condition = condition;

        public bool Evaluate()
            => _condition.Invoke();
    }
}