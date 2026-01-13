using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public sealed class PipesRebuilder : RebuilderBase
    {
        private readonly Camera _camera;
        private readonly int _minY;
        private readonly int _maxY;
        private readonly Vector3 _pointAboardRightBorderCamera = new(1.1f,0.5f);
        
        public PipesRebuilder(Camera camera, int minY, int maxY)
        {
            _camera = camera;
            _minY = minY;
            _maxY = maxY;
        }
        
        public override void Rebuild(IRebuildable rebuildable)
        {
            float randomY = Random.Range(_minY, _maxY);
            Vector3 spawnPos = _camera.ViewportToWorldPoint(_pointAboardRightBorderCamera);

            rebuildable.Rebuild(new Vector3(spawnPos.x, randomY, spawnPos.z));
        }
    }
}