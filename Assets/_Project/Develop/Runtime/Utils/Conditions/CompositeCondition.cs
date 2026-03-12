using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Utils.Conditions
{
    public class CompositeCondition : ICompositeCondition
    {
        private Func<bool, bool, bool> _standardLogicOperation = null;

        public CompositeCondition(Func<bool, bool, bool> standartLogicOperation)
            => _standardLogicOperation = standartLogicOperation;

        public CompositeCondition() : this(LogicOperations.And)
        { }

        private List<ICondition> _conditions = new();

        public ICompositeCondition Add(ICondition condition)
        {
            _conditions.Add(condition);

            return this;
        }

        public ICompositeCondition Remove(ICondition condition)
        {
            _conditions.Remove(condition);

            return this;
        }

        public bool Evaluate()
        {
            if (_conditions.Count == 0)
                return false;

            bool result = _conditions[0].Evaluate();

            for (int i = 1; i < _conditions.Count; i++)
            {
                ICondition condition = _conditions[i];

                result = _standardLogicOperation.Invoke(result, condition.Evaluate());
            }

            return result;
        }
    }
}