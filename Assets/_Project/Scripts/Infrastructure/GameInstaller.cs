using BirdComponents;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public Bird BirdComponent;
        public BirdMover Mover;

        public override void InstallBindings()
        {
            BindBirdAndMover();
        }

        private void BindBirdAndMover()
        {
            Container.Bind<Bird>().FromComponentInHierarchy(BirdComponent).AsSingle();
            Container.Bind<BirdMover>().FromComponentInHierarchy(Mover).AsSingle();
        }
    }
}