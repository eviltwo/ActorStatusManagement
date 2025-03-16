namespace ActorStatusManagement
{
    public abstract class StackableStatusModifier : StatusModifier, IStackable
    {
        public int StackCount { get; private set; }

        public StackableStatusModifier(Status status) : base(status)
        {
        }

        public virtual void SetStackCount(int stackCount)
        {
            StackCount = stackCount;
        }

        public abstract string GetValueText(int stackCount, string key);
    }
}
