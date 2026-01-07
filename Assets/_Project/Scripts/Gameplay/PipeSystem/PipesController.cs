using System;
using _Project.Scripts.Plugins.ObjectPool;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesController : MonoBehaviour,ITickable, IInitializable, IDisposable
    {
        private IPool<Pipes> _pool;
        private IRebuilder _rebuilder;
        private Camera _camera;
        private float _elapsedTime;
        private readonly float _secondsBetweenActivate = 2;
        private readonly Vector3 _offsetDisable = new(0, 0.5f);
        
        private SignalBus _signalBus;

        [Inject]
        public void Construct(IPool<Pipes> pool, IRebuilder rebuilder, Camera camera, SignalBus signalBus)
        {
            _pool = pool;
            _camera = camera;
            _rebuilder = rebuilder;
            _signalBus = signalBus;
        }
        
        void IInitializable.Initialize()
        {
            _signalBus.Subscribe<GameRestartSignal>(ResetPool);
        }

        void IDisposable.Dispose()
        {
            _signalBus.Unsubscribe<GameRestartSignal>(ResetPool);
        }
        
        void ITickable.Tick()
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

        private void ResetPool()
        {
            _pool.PushAllObjects();
            _elapsedTime = 0;
        }
    }
}