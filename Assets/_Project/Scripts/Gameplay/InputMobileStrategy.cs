using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public class InputMobileStrategy : IInputStrategy
    {
        bool IInputStrategy.HandleInput()
        {
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }
}