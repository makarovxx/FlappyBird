using System;
using _Project.Scripts.Core;
using _Project.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    public sealed class GameOverPanel : Panel, IInitializable, IDisposable
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
    
        private SignalBus _signalBus;
        private ApplicationExiter _exiter;
    
        [Inject]
        public void Construct(SignalBus signalBus, ApplicationExiter exiter)
        {
            _signalBus = signalBus;
            _exiter = exiter;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GameOverSignal>(Show);
            _signalBus.Subscribe<GameRestartSignal>(Hide);
        
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<GameOverSignal>(Show);
            _signalBus.TryUnsubscribe<GameRestartSignal>(Hide);
        
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }
    
        private void OnRestartButtonClicked() => _signalBus.Fire<GameRestartSignal>();
        private void OnExitButtonClicked() => _exiter.Exit();
    }
}