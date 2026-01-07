using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Configs
{
    [Serializable]
    public sealed class ObjectPoolConfig
    {
        public Transform Container;
        public int MaxInstances;
    }
}