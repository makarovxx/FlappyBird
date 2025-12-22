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
        private float _elapsedTime;
        private readonly float _secondsBetweenActivate = 2;
        private readonly Vector3 _offsetDisable = new(0, 0.5f);

        [Inject]
        public void Construct(IPool<Pipes> pool, IRebuilder rebuilder, Camera camera)
        {
            _pool = pool;
            _camera = camera;
            _rebuilder = rebuilder;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBetweenActivate)
            {
                if (_pool.TryGetObject(out Pipes pipes))
                {
                    _elapsedTime = 0;
                    _rebuilder.Rebuild(pipes);
                    DisableObjectsAboardScreen();
                }
            }
        }

        private void DisableObjectsAboardScreen()
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(_offsetDisable);
            _pool.PushObjectsByCondition(obj => obj.transform.position.x < disablePoint.x);
        }
    }
}