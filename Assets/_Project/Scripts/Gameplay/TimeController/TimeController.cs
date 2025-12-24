using System;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.TimeController
{
    public sealed class TimeController :  IInitializable, IDisposable
    {
        private const int OffTime = 0;
        private const int DefaultTime = 1;
        private readonly SignalBus _signalBus;

        public TimeController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GamePauseSignal>(TimeSetOff);
            _signalBus.Subscribe<GameResumeSignal>(TimeSetDefault);
            _signalBus.Subscribe<GameRestartSignal>(TimeSetDefault);
            _signalBus.Subscribe<GameStartSignal>(TimeSetDefault);
            _signalBus.Subscribe<GameOverSignal>(TimeSetOff);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<GamePauseSignal>(TimeSetOff);
            _signalBus.Unsubscribe<GameResumeSignal>(TimeSetDefault);
            _signalBus.Unsubscribe<GameRestartSignal>(TimeSetDefault);
            _signalBus.Unsubscribe<GameStartSignal>(TimeSetDefault);
            _signalBus.Unsubscribe<GameOverSignal>(TimeSetOff);
        }

        private void TimeSetOff() => Time.timeScale = OffTime;

        private void TimeSetDefault() => Time.timeScale = DefaultTime;
    }
}