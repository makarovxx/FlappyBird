using System;
using _Project.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPanel : MonoBehaviour, IInitializable, IDisposable
{
    private SignalBus _signalBus;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _startButton;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    void IInitializable.Initialize()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
    }

    void IDisposable.Dispose()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClicked);
    }

    private void Show()
    {
        _panel.SetActive(true);
    }

    private void Hide()
    {
        _panel.SetActive(false);
    }

    private void OnStartButtonClicked()
    {
        _signalBus.Fire<GameStartSignal>();
        Hide();
    }
}