using _Project.Scripts.Plugins.Factory;
using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesFactory : ICreator<Pipes>
    {
        private const int MaxSpawnPositionY = 2;
        private const int MinSpawnPositionY = -2;
        private readonly Pipes _prefab;

        public PipesFactory(Pipes prefab)
        {
            _prefab = prefab;
        }
        
        public Pipes Create()
        {
            var pipes = Object.Instantiate(_prefab);
            pipes.Init(MinSpawnPositionY, MaxSpawnPositionY);
            return pipes;
        }
    }
}