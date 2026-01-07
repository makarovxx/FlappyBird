using UnityEngine;

namespace _Project.Scripts.Physics
{
    public class ClampedRotationHandler : Rotation, IRotatable
    {
        private readonly Transform _transform;
        private readonly Quaternion _minRotation;
        private readonly Quaternion _maxRotation;
        private readonly Quaternion _defaultRotation;

        public ClampedRotationHandler(float speed, Transform transform, Quaternion minRotation, Quaternion maxRotation)
            : base(speed)
        {
            _transform = transform;
            _minRotation = minRotation;
            _maxRotation = maxRotation;
            _defaultRotation = Quaternion.identity;
        }

        void IRotatable.RotateInstant() => _transform.rotation = _maxRotation;

        void IRotatable.RotateSmoothly(float deltaTime)
        {
            _transform.rotation = Quaternion.Lerp(_transform.rotation, _minRotation, Speed * deltaTime);
        }

        void IRotatable.ResetRotation()
        {
            _transform.rotation = _defaultRotation;
        }
    }
}