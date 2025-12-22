using System;
using UnityEngine;

namespace _Project.Scripts.InstallerConfigs
{
    [Serializable]
    public sealed class PipesRebuilderConfig
    {
        public int MinYPosition;
        public int MaxYPosition;
        public Transform RebuildPoint;
    }
}