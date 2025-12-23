using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.BirdComponents
{
    public class BirdTracker : MonoBehaviour
    {
        [SerializeField] private float _offsetX;
        private BirdMover _birdMover;

        [Inject]
        public void Construct(BirdMover birdMover) => _birdMover = birdMover;

        private void Update() => transform.position = new Vector3(_birdMover.transform.position.x - _offsetX, transform.position.y, transform.position.z);
    }
}