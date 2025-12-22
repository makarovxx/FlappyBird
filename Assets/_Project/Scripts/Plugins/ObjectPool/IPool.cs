using System;

namespace _Project.Scripts.Plugins.ObjectPool
{
    public interface IPool<T>
    {
        T GetObject();
        void PushObject(T obj);

        void PushObjectsByCondition(Func<T, bool> condition);
    }
}