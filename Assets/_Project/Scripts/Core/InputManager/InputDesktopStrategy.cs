using UnityEngine;

namespace _Project.Scripts.Core.InputManager
{
    public class InputDesktopStrategy : IInputStrategy
    {
        private readonly KeyCode _keyInput;

        public InputDesktopStrategy(KeyCode keyInput)
        {
            _keyInput = keyInput;
        }

        public bool HandleInput() => UnityEngine.Input.GetKeyDown(_keyInput);
    }
}