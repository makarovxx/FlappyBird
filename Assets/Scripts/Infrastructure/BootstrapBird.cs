using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapBird : MonoInstaller
    {
        public Transform StartPoint;
        public GameObject BirdPrefab;
        public override void InstallBindings()
        {
            BirdMover birdMover =  Container.InstantiatePrefabForComponent<BirdMover>(BirdPrefab, StartPoint.position, Quaternion.identity,null);
            
            Container.
                Bind<BirdMover>().
                FromInstance(birdMover)
                .AsSingle();
        }
    }
}