using _Project.Scripts.Gameplay.PipeSystem;
using _Project.Scripts.Plugins.Factory;
using _Project.Scripts.Plugins.ObjectPool;
using BirdComponents;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Pipes pipesPrefab;           // Перетащи префаб Pipes сюда в инспекторе
        [SerializeField] private Transform pipesContainer;    // Опционально: контейнер для труб (можно null)
        [SerializeField] private Camera mainCamera;           // Перетащи главную камеру

        [SerializeField] private int maxPipesCount = 10;      // Сколько труб в пуле (настрой по вкусу)
        // [SerializeField] private Pipes _pipesPrefab;
        // [SerializeField] private Transform _pipesContainer;
        // [SerializeField] private PipesController _pipesController;
        //
        // [SerializeField] private int _poolSize = 5;
        public Bird BirdComponent;
        public BirdMover Mover;

        public override void InstallBindings()
        {
            BindBirdAndMover();
            // BindCamera();
            // BindPipesFactoryAndPool();
        }

        private void BindBirdAndMover()
        {
            Container.Bind<Bird>()
                .FromComponentInHierarchy(BirdComponent)
                .AsSingle();

            Container.Bind<BirdMover>()
                .FromComponentInHierarchy(Mover)
                .AsSingle();

            // 1. Биндим префаб Pipes
            Container.Bind<Pipes>().FromInstance(pipesPrefab).AsSingle();

            // 2. Биндим интерфейс фабрики
            Container.Bind<ICreator<Pipes>>()
                .To<PipesFactory>()
                .AsSingle();

            // 3. Биндим пул через FromMethod — здесь Resolve работает!
            Container.Bind<MainObjectPool<Pipes>>()
                .FromMethod(ctx =>
                {
                    var factory = ctx.Container.Resolve<ICreator<Pipes>>();
                    return new MainObjectPool<Pipes>(factory, maxPipesCount, pipesContainer);
                })
                .AsSingle();

            // 4. Биндим камеру
            Container.Bind<Camera>().FromInstance(mainCamera).AsSingle();
        }
    }
}