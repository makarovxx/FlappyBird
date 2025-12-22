using System;
using UnityEngine;

namespace _Project.Scripts.InstallerConfigs
{
    [Serializable]
    public sealed class ObjectPoolConfig
    {
        public Transform Container;
        public int MaxInstances;
    }
}