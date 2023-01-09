namespace Assets._Scripts.Structures.Interfaces
{
    public interface IEventRaiser
    {
        public abstract void RaiseEvent<T>(T Enum) where T : struct; 
    }
}
