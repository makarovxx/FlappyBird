using System;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.TimeController
{
    public sealed class TimeController : IInitializable, IDisposable
    {
        private enum TimeState
        {
            Off = 0,
            Default = 1,
        }
        
        private readonly SignalBus _signalBus;

        public TimeController(SignalBus signalBus)
        {
            _signalBus = signalBus;
            TimeSetOff();
        }

        void IInitializable.Initialize()
        {
            _signalBus.Subscribe<GamePauseSignal>(TimeSetOff);
            _signalBus.Subscribe<GameResumeSignal>(TimeSetDefault);
            _signalBus.Subscribe<GameRestartSignal>(TimeSetDefault);
            _signalBus.Subscribe<GameStartSignal>(TimeSetDefault);
            _signalBus.Subscribe<GameOverSignal>(TimeSetOff);
        }

        void IDisposable.Dispose()
        {
            _signalBus.Unsubscribe<GamePauseSignal>(TimeSetOff);
            _signalBus.Unsubscribe<GameResumeSignal>(TimeSetDefault);
            _signalBus.Unsubscribe<GameRestartSignal>(TimeSetDefault);
            _signalBus.Unsubscribe<GameStartSignal>(TimeSetDefault);
            _signalBus.Unsubscribe<GameOverSignal>(TimeSetOff);
        }

        private void TimeSetOff() => SetTime(TimeState.Off);

        private void TimeSetDefault() => SetTime(TimeState.Default);

        private void SetTime(TimeState state) => Time.timeScale = (int)state;
    }
}