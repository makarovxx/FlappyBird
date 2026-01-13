using _Project.Scripts.Core;
using _Project.Scripts.Gameplay.Score;
using _Project.Scripts.Gameplay.TimeController;
using _Project.Scripts.UI;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public sealed class InstallerCoreGame : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMainUI();
            BindScoreCounter();
            BindTimeController();
        }

        private void BindMainUI()
        {
            Container.Bind<ApplicationExiter>().AsSingle();
            
            Container.BindInterfacesTo<StartPanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<PausePanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<GameplayPanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<GameOverPanel>().FromComponentInHierarchy().AsSingle();
        }

        private void BindScoreCounter()
        {
            Container.BindInterfacesTo<ScoreView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle();
        }
        
        private void BindTimeController()
        {
            Container.BindInterfacesAndSelfTo<TimeController>().AsSingle();
        }
    }
}