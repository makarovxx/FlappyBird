using BirdComponents;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    [RequireComponent(typeof(CircleCollider2D), typeof(Bird))]
    public class BirdCollisionHandler : MonoBehaviour
    {
        private Bird _bird;

        [Inject]
        public void Construct(Bird bird)
        {
            _bird = bird;
        }
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if (other.TryGetComponent(out ScoreZone _))
        //         _bird.IncreaseScore();
        //     else
        //         _bird.Die();
        // }
    }
}