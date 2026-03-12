namespace Runtime.Utils.Conditions
{
    public interface ICompositeCondition : ICondition
    {
        ICompositeCondition Add(ICondition condition);
        ICompositeCondition Remove(ICondition condition);
    }
}