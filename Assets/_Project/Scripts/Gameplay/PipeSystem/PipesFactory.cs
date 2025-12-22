using _Project.Scripts.Plugins.Factory;
using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesFactory : ICreator<Pipes>
    {
        private readonly Pipes _prefab;

        public PipesFactory(Pipes prefab) => _prefab = prefab;

        public Pipes Create() => Object.Instantiate(_prefab);
    }
}