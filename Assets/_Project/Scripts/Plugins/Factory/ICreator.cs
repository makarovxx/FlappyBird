namespace _Project.Scripts.Plugins.Factory
{
    public interface ICreator<T> where T : ICreatable
    {
        public T Create();
    }
}