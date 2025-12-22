namespace _Project.Scripts.Plugins.ObjectPool
{
    public interface IPool<T>
    {
        abstract T GetObject();
        abstract void PushObject(T obj);
        abstract bool TryGetObject(out T obj);
    }
}