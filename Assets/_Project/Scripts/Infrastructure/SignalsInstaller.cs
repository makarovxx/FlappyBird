using _Project.Scripts.Signals;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public sealed class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallSignalBus();
        }

        private void InstallSignalBus()
        {
            
            Container.DeclareSignal<GamePauseSignal>();
            Container.DeclareSignal<GameResumeSignal>();
            Container.DeclareSignal<GameRestartSignal>();
            Container.DeclareSignal<GameStartSignal>();
            Container.DeclareSignal<GameOverSignal>();
            Container.DeclareSignal<ScoreChangedSignal>();
            
            SignalBusInstaller.Install(Container);

        }
    }
}