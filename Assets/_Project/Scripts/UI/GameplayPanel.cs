using System;
using _Project.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    public sealed class GameplayPanel : Panel, IInitializable, IDisposable
    {
        [SerializeField] private Button _pauseButton;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        void IInitializable.Initialize()
        {
            _signalBus.Subscribe<GameStartSignal>(Show);
            _signalBus.Subscribe<GamePauseSignal>(Hide);
            _signalBus.Subscribe<GameResumeSignal>(Show);
            _signalBus.Subscribe<GameRestartSignal>(Show);
            _signalBus.Subscribe<GameOverSignal>(Hide);
            
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }

        void IDisposable.Dispose()
        {
            _signalBus.TryUnsubscribe<GameStartSignal>(Show);
            _signalBus.TryUnsubscribe<GamePauseSignal>(Hide);
            _signalBus.TryUnsubscribe<GameResumeSignal>(Show);
            _signalBus.TryUnsubscribe<GameRestartSignal>(Hide);
            _signalBus.TryUnsubscribe<GameOverSignal>(Hide);
            
            _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
        }

        private void OnPauseButtonClicked() => _signalBus.Fire<GamePauseSignal>();
    }
}