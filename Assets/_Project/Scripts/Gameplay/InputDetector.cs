using System.Collections.Generic;
using Zenject;

namespace _Project.Scripts.Gameplay
{
    public sealed class InputDetector : ITickable
    {
        private readonly IReadOnlyList<IInputStrategy> _strategies;
        public IInputStrategy Current { get; private set; }

        public InputDetector(IEnumerable<IInputStrategy> strategies)
        {
            _strategies = new List<IInputStrategy>(strategies);
        }

        void ITickable.Tick()
        {
            foreach (var strategy in _strategies)
            {
                if (!strategy.HandleInput())
                    continue;
                if (Current == strategy)
                    return;

                Current = strategy;
            }
        }
    }
}