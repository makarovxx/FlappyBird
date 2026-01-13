using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    public sealed class BirdTracker : MonoBehaviour
    {
        private const float OffsetX = -1;
        private Bird _birdMover;

        [Inject]
        public void Construct(Bird bird) => _birdMover = bird;

        private void Update() => transform.position = new Vector3(_birdMover.transform.position.x - OffsetX, transform.position.y, transform.position.z);
    }
}