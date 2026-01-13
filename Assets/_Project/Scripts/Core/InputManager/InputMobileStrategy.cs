using UnityEngine;

namespace _Project.Scripts.Core.InputManager
{
    public class InputMobileStrategy : IInputStrategy
    {
        public bool HandleInput()
        {
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }
}