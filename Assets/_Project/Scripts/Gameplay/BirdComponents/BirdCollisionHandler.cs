using _Project.Scripts.Gameplay.Score;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public sealed class BirdCollisionHandler : MonoBehaviour
    {
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus) => _signalBus = signalBus;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ITouchable _))
                _signalBus.Fire<ScoreChangedSignal>();
            else
                _signalBus.Fire<GameOverSignal>();
        }
    }
}