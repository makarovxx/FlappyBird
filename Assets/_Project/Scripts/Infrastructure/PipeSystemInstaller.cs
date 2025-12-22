using _Project.Scripts.Gameplay.PipeSystem;
using _Project.Scripts.InstallerConfigs;
using _Project.Scripts.Plugins.Factory;
using _Project.Scripts.Plugins.ObjectPool;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public sealed class PipeSystemInstaller : MonoInstaller
    {
        [SerializeField, Space] private PipesFactoryConfig pipePipesFactoryConfig;
        [SerializeField, Space] private ObjectPoolConfig _objectPoolConfig;
        [SerializeField, Space] private PipesRebuilderConfig _pipesRebuilderConfig;

        public override void InstallBindings()
        {
            BindPipesPrefab();
            BindFactoryAndObjectPool();
            BindRebuilder();
            BindCamera();
        }
        
        private void BindPipesPrefab()
        {
            Container.Bind<Pipes>().FromInstance(pipePipesFactoryConfig.Prefab).AsSingle();
        }

        private void BindFactoryAndObjectPool()
        {
            Container.Bind<ICreator<Pipes>>()
                .To<PipesFactory>()
                .AsSingle();
            
            Container.Bind<IPool<Pipes>>().To<PipesObjectPool>()
                .FromMethod(context =>
                {
                    var factory = context.Container.Resolve<ICreator<Pipes>>();
                    return new PipesObjectPool(factory, _objectPoolConfig.MaxInstances, _objectPoolConfig.Container);
                })
                .AsSingle();
        }
        
        private void BindRebuilder()
        {
            Container.Bind<IRebuilder>()
                .To<PipesRebuilder>()
                .AsSingle()
                .WithArguments(_pipesRebuilderConfig.RebuildPoint,_pipesRebuilderConfig.MinYPosition,_pipesRebuilderConfig.MaxYPosition);
        }
        
        private void BindCamera()
        {
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
        }

    }
}