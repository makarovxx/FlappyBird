namespace _Project.Scripts.Plugins.Factory
{
    public interface ICreator<T>
    {
        public T Create();
    }
}