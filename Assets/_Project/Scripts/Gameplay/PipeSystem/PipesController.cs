using System;
using _Project.Scripts.Plugins.ObjectPool;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesController : MonoBehaviour
    {
        private MainObjectPool<Pipes> _pool;
        private Camera _camera;
        
        [Inject]
        public void Construct(MainObjectPool<Pipes> pool, Camera camera)
        {
            _pool = pool;
            _camera = camera;
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
            _pool.GetObject();
        }
    }
}