// using System;
// using _Project.Scripts.Signals;
// using UnityEngine;
// using UnityEngine.UI;
// using Zenject;
//
// namespace _Project.Scripts.UI
// {
//     public class PausePanel : IInitializable, IDisposable
//     {
//         private readonly GameObject _panel;
//         private readonly Button _resumeButton;
//         private readonly Button _exitButton;
//         private readonly SignalBus _signalBus;
//         private bool _canPause;
//
//         public PausePanel(Button exitButton, Button resumeButton, GameObject panel, SignalBus signalBus)
//         {
//             _exitButton = exitButton;
//             _resumeButton = resumeButton;
//             _panel = panel;
//             _signalBus = signalBus;
//         }
//
//         public void Initialize()
//         {
//             _signalBus.Subscribe<GameOverSignal>(() => _canPause = false);
//             _signalBus.Subscribe<GameStartSignal>(() => _canPause = true);
//             _signalBus.Subscribe<GameRestartSignal>(() => _canPause = true);
//         }
//         
//         public void Dispose()
//         {
//             _signalBus.Subscribe<GameOverSignal>();
//         }
//         
//         private void SetCanPause()
//         
//         private void Show()
//         {
//             _panel.SetActive(true);
//         }
//
//         private void Hide()
//         {
//             _panel.SetActive(false);
//         }
//     }
// }