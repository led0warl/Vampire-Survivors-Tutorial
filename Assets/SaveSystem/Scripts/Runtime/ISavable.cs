namespace SaveSystem.Runtime
{
    public interface ISavable
    {
        object data { get; }
        void Load(object data);
    }
}