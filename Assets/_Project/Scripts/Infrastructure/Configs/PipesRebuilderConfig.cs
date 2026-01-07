using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Configs
{
    [Serializable]
    public sealed class PipesRebuilderConfig
    {
        public int MinYPosition;
        public int MaxYPosition;
        public Transform RebuildPoint;
    }
}