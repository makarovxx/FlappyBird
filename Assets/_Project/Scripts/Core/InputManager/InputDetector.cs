using System.Collections.Generic;
using Zenject;

namespace _Project.Scripts.Core.InputManager
{
    public sealed class InputDetector : ITickable
    {
        private readonly IReadOnlyList<IInputStrategy> _strategies;
        public bool HasInput { get; private set; }

        public InputDetector(IEnumerable<IInputStrategy> strategies)
        {
            _strategies = new List<IInputStrategy>(strategies);
        }

        public void Tick()
        {
            HasInput = false;
            
            foreach (var strategy in _strategies)
            {
                if (!strategy.HandleInput())
                    continue;
                
                HasInput = true;
                return;
            }
        }
    }
}