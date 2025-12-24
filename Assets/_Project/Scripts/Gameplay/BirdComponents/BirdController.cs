using System;
using _Project.Scripts.Gameplay.Physics;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    public sealed class BirdController : ITickable, IInitializable, IDisposable
    {
        private readonly IRigidBodyMovable _movement;
        private readonly IForceImplementable _jump;
        private readonly IRotatable _rotation;
        private readonly SignalBus _signalBus;
        
        public BirdController(IRigidBodyMovable movement, IForceImplementable jump, IRotatable rotation, SignalBus signalBus)
        {
            _movement = movement;
            _jump = jump;
            _rotation = rotation;
            _signalBus = signalBus;
        }
        
        void IInitializable.Initialize() => _signalBus.Subscribe<GameRestartSignal>(Reset);

        void IDisposable.Dispose() => _signalBus.Unsubscribe<GameRestartSignal>(Reset);

        void ITickable.Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movement.ApplyMoveSpeed();
                _jump.ApplyForce();
                _rotation.RotateInstant();
            }

            _rotation.RotateSmoothly(Time.deltaTime);
        }
        
        private void Reset()
        {
            _movement.Stop();
            _rotation.ResetRotation();
            _jump.RevertForce();
        }
    }
}