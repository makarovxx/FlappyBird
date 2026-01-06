using _Project.Scripts.Plugins.Factory;
using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public class Pipes : MonoBehaviour, ICreatable, IRebuildable
    {
        public void Rebuild(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}