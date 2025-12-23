using UnityEngine;

namespace _Project.Scripts.Gameplay.Physics
{
    public class ClampedRotationHandler : Rotation, IRotatable
    {
        private readonly Transform _transform;
        private readonly Quaternion _minRotation;
        private readonly Quaternion _maxRotation;

        public ClampedRotationHandler(float speed, Transform transform, Quaternion minRotation, Quaternion maxRotation) : base(speed)
        {
            _transform = transform;
            _minRotation = minRotation;
            _maxRotation = maxRotation;
        }
        public void RotateInstant() => _transform.rotation = _maxRotation;

        public void RotateSmoothly(float deltaTime)
        {
            _transform.rotation = Quaternion.Lerp(_transform.rotation, _minRotation, Speed * deltaTime);
        }
    }
}