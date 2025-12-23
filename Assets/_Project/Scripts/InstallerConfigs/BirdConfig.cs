using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.InstallerConfigs
{
    [Serializable]
    public sealed class BirdConfig
    {
        public Vector2 Velocity;
        public Rigidbody2D Rigidbody;
        public Transform Transform;
        
        public float JumpForce;
        public Vector2 JumpDirection;
        public ForceMode2D ForceMode;

        public float RotationSpeed;
        public Quaternion MaxRotation;
        public Quaternion MinRotation;

        public KeyCode JumpKey;
    }
}