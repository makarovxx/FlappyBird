using _Project.Scripts.Plugins.Factory;
using _Project.Scripts.Plugins.ObjectPool;
using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesObjectPool : ObjectPool<Pipes>
    {
        public PipesObjectPool(ICreator<Pipes> creator, int maxInstances, Transform container) : base(creator, maxInstances, container)
        {
        }
    }
}