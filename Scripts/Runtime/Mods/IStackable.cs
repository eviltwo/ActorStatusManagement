namespace ActorStatusManagement
{
    public interface IStackable
    {
        int StackCount { get; }

        void SetStackCount(int stackCount);

        string GetValueText(int stackCount, string key);
    }
}
