using System;
using _Project.Scripts.Core.InputManager;
using _Project.Scripts.Physics;
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
        private readonly InputManager _inputManager;
        private readonly SignalBus _signalBus;
        private bool _isActive;
        
        public BirdController(IRigidBodyMovable movement, IForceImplementable jump, IRotatable rotation, InputManager inputManager, SignalBus signalBus)
        {
            _movement = movement;
            _jump = jump;
            _rotation = rotation;
            _signalBus = signalBus;
            _inputManager = inputManager;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GameStartSignal>(Activate);
            _signalBus.Subscribe<GameRestartSignal>(Reset);
            _signalBus.Subscribe<GameResumeSignal>(Activate);
            _signalBus.Subscribe<GameOverSignal>(Deactivate);
            _signalBus.Subscribe<GamePauseSignal>(Deactivate);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<GameStartSignal>(Activate);
            _signalBus.Unsubscribe<GameRestartSignal>(Reset);
            _signalBus.Unsubscribe<GameResumeSignal>(Activate);
            _signalBus.Unsubscribe<GameOverSignal>(Deactivate);
            _signalBus.Unsubscribe<GamePauseSignal>(Deactivate);
        }

        public void Tick()
        {
            if(!_isActive)
                return;
            
            if (_inputManager.HandleInput())
            {
                _movement.ApplyMoveSpeed();
                _jump.ApplyForce();
                _rotation.RotateInstant();
            }

            _rotation.RotateSmoothly(Time.deltaTime);
        }

        private void Activate()
        {
            _isActive = true;
            _movement.ApplyMoveSpeed();
        }

        private void Deactivate()
        {
            _isActive = false;
            _movement.Stop();
            _jump.RevertForce();
        }
        
        private void Reset()
        {
            _movement.ResetPosition();
            _movement.Stop();
            _rotation.ResetRotation();
            _jump.RevertForce();
            Activate();
        }
    }
}