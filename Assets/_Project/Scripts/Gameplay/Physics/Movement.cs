using UnityEngine;

namespace _Project.Scripts.Gameplay.Physics
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

    public class Movement: MovementBase, IRigidBodyMovable
    {
        private readonly Vector2 _velocity;
        private readonly Rigidbody2D _rb;

        public Movement(Transform originalPosition, Transform body, Vector2 velocity, Rigidbody2D rb) : base(originalPosition, body)
        {
            _velocity = velocity;
            _rb = rb;
        }

        public new void ResetPosition()
        {
            base.ResetPosition();
        }

        public void ApplyMoveSpeed() => _rb.velocity = _velocity;

        public new void Stop() => _rb.velocity = Vector2.zero;
    }
}