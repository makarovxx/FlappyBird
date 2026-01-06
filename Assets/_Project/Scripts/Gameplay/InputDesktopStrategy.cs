using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public sealed class InputDesktopStrategy : IInputStrategy
    {
        private readonly KeyCode _keyInput;

        public InputDesktopStrategy(KeyCode keyInput)
        {
            _keyInput = keyInput;
        }

        bool IInputStrategy.HandleInput()
        {
            return Input.GetKeyDown(_keyInput);
        }
    }
}