using UnityEngine;

namespace _Project.Scripts.Core.Input
{
    public class InputMobileStrategy : IInputStrategy
    {
        bool IInputStrategy.HandleInput()
        {
            return UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }
}