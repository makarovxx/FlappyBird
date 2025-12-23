using _Project.Scripts.Gameplay.Physics;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdController : MonoBehaviour
    {
        private IRigidBodyMovable _movement;
        private IForceImplementable _jump;
        private IRotatable _rotation;
        private KeyCode _jumpKey;

        [Inject]
        public void Construct(IRigidBodyMovable movement, IForceImplementable jump, IRotatable rotation)
        {
            _movement = movement;
            _jump = jump;
            _rotation = rotation;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movement.ApplyMoveSpeed();
                _jump.ApplyForce();
                _rotation.RotateInstant();
            }

            _rotation.RotateSmoothly(Time.deltaTime);
        }
    }
}