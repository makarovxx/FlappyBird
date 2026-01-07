using _Project.Scripts.GameManage;
using _Project.Scripts.UI;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public sealed class InstallerUI : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ApplicationExiter>().AsSingle();
            
            Container.BindInterfacesTo<StartPanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<PausePanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<GameplayPanel>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<GameOverPanel>().FromComponentInHierarchy().AsSingle();
        }
    }
}