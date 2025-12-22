using System;

namespace _Project.Scripts.Plugins.ObjectPool
{
    public interface IPool<T>
    {
        bool TryGetObject(out T obj);
        void PushObject(T obj);

        void PushObjectsByCondition(Func<T, bool> condition);
    }
}