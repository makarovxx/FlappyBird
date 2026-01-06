namespace _Project.Scripts.Gameplay
{
    public sealed class InputManager 
    {
        private readonly InputDetector _detector;

        public InputManager(InputDetector detector)
        {
            _detector = detector;
        }
    
        public bool HandleInput()
        {
            return _detector.Current.HandleInput();
        }
    }
}