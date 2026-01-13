using UnityEngine;

namespace _Project.Scripts.Physics
{
    public class Movement: MovementBase, IRigidBodyMovable
    {
        private readonly Vector2 _velocity;
        private readonly Rigidbody2D _rb;

        public Movement(Transform originalPosition, Transform body, Vector2 velocity, Rigidbody2D rb) : base(originalPosition, body)
        {
            _velocity = velocity;
            _rb = rb;
        }

        public new void ResetPosition() => base.ResetPosition();

        public void ApplyMoveSpeed() => _rb.velocity = _velocity;

        public new void Stop() => _rb.velocity = Vector2.zero;
    }
}