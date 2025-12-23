using System;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    public class Bird : IInitializable, IDisposable
    {
        private BirdMover _birdMover;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus, BirdMover birdMover)
        {
            _signalBus = signalBus;
            _birdMover = birdMover;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<DiedBirdSignal>(BirdDied);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<DiedBirdSignal>(BirdDied);
        }

        private void BirdDied()
        {
            Debug.Log("Died");
        }
    }
}
