using System;
using _Project.Scripts.Signals;
using Zenject;

namespace _Project.Scripts.Gameplay.Score
{
    public sealed class ScoreCounter : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        
        public int Score { get; private set; }
        public event Action<int> OnScoreChanged;

        public ScoreCounter(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ScoreChangedSignal>(IncreaseScore);
            _signalBus.Subscribe<GameRestartSignal>(Reset);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ScoreChangedSignal>(IncreaseScore);
            _signalBus.Unsubscribe<GameRestartSignal>(Reset);
        }

        private void IncreaseScore()
        {
            Score++;
            OnScoreChanged?.Invoke(Score);
        }

        private void Reset()
        {
            Score = 0;
            OnScoreChanged?.Invoke(Score);
        }
    }
}