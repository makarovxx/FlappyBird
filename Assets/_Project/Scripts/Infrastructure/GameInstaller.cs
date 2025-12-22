using _Project.Scripts.Gameplay.BirdComponents;
using Zenject;

namespace Infrastructure
{
    public sealed class GameInstaller : MonoInstaller
    {
        // [SerializeField] private Pipes pipesPrefab;
        // [SerializeField] private Transform _rebuildPoint;
        // [SerializeField] private Transform pipesContainer;
        // [SerializeField] private Camera mainCamera; 
        //
        // [SerializeField] private int maxPipesCount; 
        public Bird BirdComponent;
        public BirdMover Mover;

        public override void InstallBindings()
        {
            BindBirdAndMover();
        }

        private void BindBirdAndMover()
        {
            Container.Bind<Bird>()
                .FromComponentInHierarchy(BirdComponent)
                .AsSingle();

            Container.Bind<BirdMover>()
                .FromComponentInHierarchy(Mover)
                .AsSingle();
            
            // Container.Bind<Pipes>().FromInstance(pipesPrefab).AsSingle();
            //
            // Container.Bind<ICreator<Pipes>>()
            //     .To<PipesFactory>()
            //     .AsSingle();
            //
            // Container.Bind<IPool<Pipes>>().To<PipesObjectPool>()
            //     .FromMethod(context =>
            //     {
            //         var factory = context.Container.Resolve<ICreator<Pipes>>();
            //         return new PipesObjectPool(factory, maxPipesCount, pipesContainer);
            //     })
            //     .AsSingle();
            //
            // Container.Bind<IRebuilder>()
            //     .To<PipesRebuilder>()
            //     .AsSingle()
            //     .WithArguments(_rebuildPoint);
            //
            // Container.Bind<Camera>().FromInstance(mainCamera).AsSingle();
        }
    }
}