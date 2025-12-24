using System;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    public class Bird : MonoBehaviour, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        
        public Bird(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GameOverSignal>(BirdDied);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<GameOverSignal>(BirdDied);
        }

        private void BirdDied()
        {
            Debug.Log("Died");
        }
    }
}
