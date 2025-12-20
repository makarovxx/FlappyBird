using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class Pipes : MonoBehaviour
    {
        private int _maxSpawnPositionY;
        private int _minSpawnPositionY;
        public const string PathPrefab = "Prefabs/Gameplay/Pipes/Pipes";

        public void Init(int minSpawnPositionY, int maxSpawnPositionY)
        {
            float spawnPositionY = Random.Range(maxSpawnPositionY, minSpawnPositionY);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
            transform.position = spawnPoint;
        }
    }
}