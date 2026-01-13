namespace _Project.Scripts.Core.InputManager
{
    public sealed class InputManager 
    {
        private readonly InputDetector _detector;

        public InputManager(InputDetector detector)
        {
            _detector = detector;
        }
    
        public bool HandleInput() => _detector.HasInput;
    }
}