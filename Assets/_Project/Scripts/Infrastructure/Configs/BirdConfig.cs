using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Configs
{
    [Serializable]
    public sealed class BirdConfig
    {
        public Vector2 Velocity;
        public Rigidbody2D Rigidbody;
        public Transform Body;
        public Transform OriginalTransform;
        
        public KeyCode JumpKey;
        public float JumpForce;
        public Vector2 JumpDirection;
        public ForceMode2D ForceMode;

        public float RotationSpeed;
        public Quaternion MaxRotation;
        public Quaternion MinRotation;
    }
}