using UnityEngine;

namespace _Project.Scripts.Physics
{
    public abstract class MovementBase
    {
        private readonly Transform _originalPosition;
        private readonly Transform _body;

        protected MovementBase(Transform originalPosition, Transform body)
        {
            _originalPosition = originalPosition;
            _body = body;
        }

        protected void ResetPosition()
        {
            _body.position = _originalPosition.position;
        }

        protected virtual void Stop()
        {
            _body.position = Vector3.zero;
        }
    }
}