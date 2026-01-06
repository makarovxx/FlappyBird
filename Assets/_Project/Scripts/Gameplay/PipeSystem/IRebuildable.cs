using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public interface IRebuildable
    {
        void Rebuild(Vector3 newPosition);
    }
}