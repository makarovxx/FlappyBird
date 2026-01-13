using UnityEngine;

namespace _Project.Scripts.Physics
{
    public class ForceHandler : IForceImplementable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _force;
        private readonly Vector2 _direction;
        private readonly ForceMode2D _forceMode;

        public ForceHandler(Rigidbody2D rigidbody, float force, Vector2 direction, ForceMode2D forceMode)
        {
            _rigidbody = rigidbody;
            _force = force;
            _direction = direction;
            _forceMode = forceMode;
        }

        public void ApplyForce()
        {
            _rigidbody.AddForce(_force * _direction, _forceMode);
        }

        public void RevertForce()
        {
            _rigidbody.AddForce(Vector2.zero);
        }
    }
}