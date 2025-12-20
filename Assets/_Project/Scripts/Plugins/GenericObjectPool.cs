// using System;
// using System.Collections.Generic;
// using Object = UnityEngine.Object;
//
// namespace _Project.Scripts.Plugins
// {
//     public class GenericObjectPool<T> : IPool<T> where T : Object, IPoolable<T>
//     {
//         public Stack<T> PooledObjects { get; }
//         private readonly int _capacity;
//
//         private Action<T> OnPullObject;
//         private Action<T> OnPushObject;
//         public int PooledCount => PooledObjects.Count;
//
//         public GenericObjectPool(int capacity)
//         {
//             _capacity = capacity;
//             PooledObjects = new(_capacity);
//         }
//
//         public GenericObjectPool(int capacity, Action<T> onPullObject, Action<T> onPushObject)
//         {
//             _capacity = capacity;
//             PooledObjects = new(_capacity);
//             OnPullObject = onPullObject;
//             OnPushObject = onPushObject;
//         }
//
//         public T Pull()
//         {
//             T t;
//             if (PooledCount > 0)
//                 t = PooledObjects.Pop();
//             else
//                 throw new Exception("Pool is empty");
//
//
//             // t.gameObject.SetActive(true); //ensure the object is on
//             t.Init(Push);
//
//             //allow default behavior and turning object back on
//             OnPullObject?.Invoke(t);
//
//             return t;
//         }
//
//         public void Push(T t)
//         {
//             PooledObjects.Push(t);
//
//             //create default behavior to turn off objects
//             OnPushObject?.Invoke(t);
//
//             // t.gameObject.SetActive(false);
//         }
//     }
// }