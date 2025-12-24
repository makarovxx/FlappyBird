using _Project.Scripts.Gameplay.ScoreSystem;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class BirdCollisionHandler : MonoBehaviour
    {
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus) => _signalBus = signalBus;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ITouchable _))
            {
                // Debug.Log("Score Changed");
                _signalBus.Fire(new ScoreChangedSignal());
            }
            else
            {
                // Debug.Log("Died");
                _signalBus.Fire(new GameOverSignal());
            }
        }
    }
}