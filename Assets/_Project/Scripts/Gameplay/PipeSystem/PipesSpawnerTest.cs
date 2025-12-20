using _Project.Scripts.Plugins;
using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesSpawnerTest : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private float _secondsBetweenSpawn = 2;
        [SerializeField] private int _capacity;

        private RandomPipesSpawner _randomPipesSpawner;
        private MainObjectPool<Pipes> _pool;
        private Camera _camera;
        private float _elapsedTime;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _camera = Camera.main;
            _randomPipesSpawner = new RandomPipesSpawner(_container);
            _pool = new MainObjectPool<Pipes>(_capacity,_randomPipesSpawner.Create);
        }
        
        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBetweenSpawn)
            {
                if (_pool.TryGetObjectFromPool(out Pipes pipes))
                {
                    _elapsedTime = 0;
                    pipes.gameObject.SetActive(true);
                }
            }
        }
    }
}