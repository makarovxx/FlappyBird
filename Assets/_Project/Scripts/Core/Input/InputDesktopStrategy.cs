using UnityEngine;

namespace _Project.Scripts.Core.Input
{
    public class InputDesktopStrategy : IInputStrategy
    {
        private readonly KeyCode _keyInput;

        public InputDesktopStrategy(KeyCode keyInput)
        {
            _keyInput = keyInput;
        }

        bool IInputStrategy.HandleInput()
        {
            return UnityEngine.Input.GetKeyDown(_keyInput);
        }
    }
}