using UnityEngine;

namespace _Project.Scripts.Gameplay.Physics
{
    public class Movement: IRigidBodyMovable
    {
        private readonly Vector2 _velocity;
        private readonly Rigidbody2D _rb;

        public Movement(Rigidbody2D rb, Vector2 velocity)
        {
            _rb = rb;
            _velocity = velocity;
        }

        public void ApplyMoveSpeed() => _rb.velocity = _velocity;

        public void Stop() => _rb.velocity = Vector2.zero;
    }
}