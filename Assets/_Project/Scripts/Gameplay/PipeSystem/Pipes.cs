using _Project.Scripts.Plugins.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class Pipes : MonoBehaviour, IPoolable
    {
        private int _minSpawnPositionY;
        private int _maxSpawnPositionY;
        public void Init(int minSpawnPositionY, int maxSpawnPositionY)
        {
            _minSpawnPositionY = minSpawnPositionY;
            _maxSpawnPositionY = maxSpawnPositionY;
            RebuildPipes();
        }

        private void RebuildPipes()
        {
            float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
            transform.position = spawnPoint;
        }

        void IPoolable.OnTakenFromPool() => RebuildPipes();
    }
}