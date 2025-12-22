using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class PipesRebuilder : RebuilderBase
    {
        private readonly Transform _rebuildPoint;
        private readonly int _minY;
        private readonly int _maxY;
        
        public PipesRebuilder(Transform rebuildPoint, int minY, int maxY)
        {
            _rebuildPoint = rebuildPoint;
            _minY = minY;
            _maxY = maxY;
        }
        
        public override void Rebuild(IRebuildable rebuildable)
        {
            float randomY = Random.Range(_minY, _maxY);
            Vector3 spawnPos = _rebuildPoint.position;

            rebuildable.Rebuild(new Vector3(spawnPos.x, randomY, spawnPos.z));
        }
    }
}