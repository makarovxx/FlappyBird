using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Plugins.Factory;
using UnityEngine;

namespace _Project.Scripts.Plugins.ObjectPool
{
    public class MainObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        private readonly int _maxInstances;
        private readonly ICreator<T> _creator;
        public List<T> PooledObjects { get; }

        public MainObjectPool(ICreator<T> creator, int maxInstances, Transform container)
        {
            _creator = creator;
            _maxInstances = maxInstances;
            PooledObjects = new List<T>();

            AllocatePool(container);
        }

        private void AllocatePool(Transform container = null)
        {
            for (int i = 0; i < _maxInstances; i++)
            {
                T obj = _creator.Create();
                if(container) obj.transform.SetParent(container);
                
                PushObject(obj);
                PooledObjects.Add(obj);
            }
        }
        
        public void PushObjectsByCondition(Func<T, bool> condition)
        {
            for (int i = 0; i < PooledObjects.Count; i++)
            {
                T obj = PooledObjects[i];

                if (!obj.gameObject.activeSelf)
                    continue;

                if (condition(obj))
                    PushObject(obj);
            }
        }
        
        public T GetObject()
        {
            T obj = PooledObjects.FirstOrDefault(item => item.gameObject.activeSelf == false);
            if (obj)
            {
                obj.OnTakenFromPool();
                obj.gameObject.SetActive(true);
            }
            
            return obj;
        }

        private void PushObject(T obj) => obj.gameObject.SetActive(false);
    }
}