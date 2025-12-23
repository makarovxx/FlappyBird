using _Project.Scripts.Gameplay.BirdComponents;
using _Project.Scripts.Signals;
using Zenject;

namespace Infrastructure
{
    public sealed class GameInstaller : MonoInstaller
    {
        public BirdMover Mover;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            BindBirdAndMover();

            Container.DeclareSignal<ScoreChangedSignal>();
            Container.DeclareSignal<DiedBirdSignal>();
            Container.Bind<ScoreCounter>().AsSingle();
        }

        private void BindBirdAndMover()
        {
            Container.Bind<Bird>().AsSingle();

            Container.Bind<BirdMover>()
                .FromComponentInHierarchy(Mover)
                .AsSingle();
            
            Container.Bind<BirdCollisionHandler>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}