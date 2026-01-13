using System;
using _Project.Scripts.Core;
using _Project.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    public sealed class StartPanel : Panel, IInitializable, IDisposable
    {
        [SerializeField] private Button _startButton;
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
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        public void Dispose()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            _signalBus.Fire<GameStartSignal>();
            Hide();
        }

        private void OnExitButtonClicked() => _exiter.Exit();
    }
}