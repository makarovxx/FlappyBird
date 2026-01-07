using System;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    public class ScoreCounter : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private int _score;

        public ScoreCounter(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        void IInitializable.Initialize()
        {
            _signalBus.Subscribe<ScoreChangedSignal>(IncreaseScore);
        }

        void IDisposable.Dispose()
        {
            _signalBus.Unsubscribe<ScoreChangedSignal>(IncreaseScore);
        }

        private void IncreaseScore()
        {
            Debug.Log($"Score: {_score}");
            _score++;
        }

        private void ResetScore() => _score = 0;
    }
}