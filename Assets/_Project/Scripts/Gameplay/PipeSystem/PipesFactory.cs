using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public abstract class PipesFactory : IPipesFactory
    {
        public abstract Pipes Create(Transform container);
    }

    public class LowerPipesFactory : PipesFactory
    {
        private const int MaxSpawnPositionY = -1;
        private const int MinSpawnPositionY = -2;

        public override Pipes Create(Transform container)
        {
            var prefab = Resources.Load<GameObject>(Pipes.PathPrefab);
            var go = Object.Instantiate(prefab, container);
            if (!prefab.TryGetComponent(out Pipes component))
                component = prefab.AddComponent<Pipes>();

            component.Init(MaxSpawnPositionY, MinSpawnPositionY);
            return component;
        }
    }

    public class UpperPipesFactory : PipesFactory
    {
        private const int MaxSpawnPositionY = 2;
        private const int MinSpawnPositionY = 1;

        public override Pipes Create(Transform container)
        {
            var prefab = Resources.Load<GameObject>(Pipes.PathPrefab);
            var go = Object.Instantiate(prefab, container);
            if (!prefab.TryGetComponent(out Pipes component))
                component = prefab.AddComponent<Pipes>();

            component.Init(MaxSpawnPositionY, MinSpawnPositionY);
            return component;
        }
    }

    public class CentralPipesFactory : PipesFactory
    {
        private const int MaxSpawnPositionY = 1;
        private const int MinSpawnPositionY = -1;

        public override Pipes Create(Transform container)
        {
            var prefab = Resources.Load<GameObject>(Pipes.PathPrefab);
            var go = Object.Instantiate(prefab, container);
            if (!prefab.TryGetComponent(out Pipes component))
                component = prefab.AddComponent<Pipes>();

            component.Init(MaxSpawnPositionY, MinSpawnPositionY);
            return component;
        }
    }

    public class RandomPipesSpawner
    {
        private readonly IPipesFactory[] _pipesFactories;
        private readonly Transform _container;
        public RandomPipesSpawner(Transform container)
        {
            IPipesFactory lowerPipesFactory = new LowerPipesFactory();
            IPipesFactory centralPipesFactory = new CentralPipesFactory();
            IPipesFactory upperPipesFactory = new UpperPipesFactory();
            _pipesFactories = new[] { lowerPipesFactory, centralPipesFactory, upperPipesFactory };

            _container = container;
        }

        public Pipes Create() => _pipesFactories[GetRandomIndex()].Create(_container);
        private int GetRandomIndex() => Random.Range(0, _pipesFactories.Length);
    }
}