using _Project.Scripts.Plugins.ObjectPool;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesController : MonoBehaviour
    {
        private IPool<Pipes> _pool;
        private IRebuilder _rebuilder;
        private Camera _camera;
        
        [Inject]
        public void Construct(IPool<Pipes> pool, IRebuilder rebuilder, Camera camera)
        {
            _pool = pool;
            _camera = camera;
            _rebuilder = rebuilder;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                TryActivatePipes();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                DisableObjectsAboardScreen();
            }
        }

        private void DisableObjectsAboardScreen()
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f));
            _pool.PushObjectsByCondition(obj => obj.transform.position.x < disablePoint.x);
        }

        
        private void TryActivatePipes()
        {
            var pipes = _pool.GetObject();
            if(pipes)
                _rebuilder.Rebuild(pipes);
        }
    }
}