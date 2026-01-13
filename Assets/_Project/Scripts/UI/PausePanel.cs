using System;
using _Project.Scripts.Core;
using _Project.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    public sealed class PausePanel : Panel, IInitializable, IDisposable
    {
        [SerializeField] private Button _resumeButton;
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
            _signalBus.Subscribe<GamePauseSignal>(Show);
            _signalBus.Subscribe<GameRestartSignal>(Hide);
            _signalBus.Subscribe<GameResumeSignal>(Hide);
            
            _resumeButton.onClick.AddListener(OnResumeButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<GamePauseSignal>(Show);
            _signalBus.TryUnsubscribe<GameRestartSignal>(Hide);
            _signalBus.TryUnsubscribe<GameResumeSignal>(Hide);
            
            _resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }
        
        private void OnResumeButtonClicked() => _signalBus.Fire<GameResumeSignal>();
        private void OnRestartButtonClicked() => _signalBus.Fire<GameRestartSignal>();
        private void OnExitButtonClicked() => _exiter.Exit();
    }
}