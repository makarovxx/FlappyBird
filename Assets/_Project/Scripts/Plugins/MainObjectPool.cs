using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Plugins
{
    public class MainObjectPool<T>
    {
        private readonly int _capacity;
        public List<T> PooledObjects { get; }
        private Func<T> _factoryMethod;

        public int PooledCount => PooledObjects.Count;

        public MainObjectPool(int capacity, Func<T> func)
        {
            _capacity = capacity;
            _factoryMethod = func;
            PooledObjects = new List<T>();

            for (int i = 0; i < _capacity; i++)
            {
                var obj = _factoryMethod.Invoke();
                if (!obj.Equals(default(T)))
                {
                    PooledObjects.Add(obj);
                }
            }
        }

        public bool TryGetObjectFromPool(out T obj)
        {
            if (PooledCount > 0)
            {
                obj = PullFrom(PooledObjects);
            }
            else
            {
                throw new Exception("Pool is empty");
            }
            return obj != null;
        }

        public void AddBackToPool(T returningObject)
        {
            if (!returningObject.Equals(default(T)) && PooledCount < _capacity &&
                returningObject.GetType() == typeof(T))
            {
                PooledObjects.Add(returningObject);
            }
        }

        private void PushTo(T obj, List<T> store) => store.Add(obj);
        private T PullFrom(List<T> store) => store.First(obj => obj.)
        
        public void DestroyObjectsInPool()
        {
            PooledObjects.Clear();
        }
    }
}