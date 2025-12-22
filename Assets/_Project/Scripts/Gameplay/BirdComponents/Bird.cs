using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    [RequireComponent(typeof(BirdMover))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _birdMover;
        private int _score;

        public event Action GameOver;
    
        [Inject]
        private void Construct(BirdMover birdMover) => _birdMover = birdMover;

        public void ResetPlayer()
        {
            _score = 0;
            _birdMover.ResetBird();
        }
    
        public void IncreaseScore() => _score++;
    
        public void Die() => GameOver?.Invoke();
    }
}
