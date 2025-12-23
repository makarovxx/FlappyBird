using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    public class BirdTracker : MonoBehaviour
    {
        private const float OffsetX = -1;
        private BirdController _birdMover;

        [Inject]
        public void Construct(BirdController birdMover) => _birdMover = birdMover;

        private void Update() => transform.position = new Vector3(_birdMover.transform.position.x - OffsetX, transform.position.y, transform.position.z);
    }
}