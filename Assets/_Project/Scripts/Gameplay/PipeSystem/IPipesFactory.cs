using UnityEngine;

namespace _Project.Scripts.Gameplay.PipeSystem
{
    public interface IPipesFactory
    {
        Pipes Create(Transform container);
    }
}