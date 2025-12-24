using _Project.Scripts.Gameplay.BirdComponents;
using _Project.Scripts.Gameplay.Physics;
using _Project.Scripts.InstallerConfigs;
using _Project.Scripts.Signals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class BirdInstaller : MonoInstaller
    {
        [SerializeField] private BirdConfig _config;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            BindBirdAndMover();
            BindBirdController();
            
            Container.DeclareSignal<ScoreChangedSignal>();
            Container.DeclareSignal<GameOverSignal>();
            Container.Bind<ScoreCounter>().AsSingle();
        }

        private void BindBirdAndMover()
        {
            Container.Bind<Bird>().AsSingle();

            Container.Bind<BirdCollisionHandler>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindBirdController()
        {
            Container.Bind<IRigidBodyMovable>()
                .To<Movement>()
                .AsSingle()
                .WithArguments(_config.Rigidbody, _config.Velocity);

            Container.Bind<IForceImplementable>()
                .To<ForceHandler>()
                .AsSingle()
                .WithArguments(_config.Rigidbody,
                    _config.JumpForce,
                    _config.JumpDirection,
                    _config.ForceMode
                );

            Container.Bind<IRotatable>()
                .To<ClampedRotationHandler>()
                .AsSingle()
                .WithArguments(
                    _config.RotationSpeed,
                    _config.Transform,
                    _config.MinRotation,
                    _config.MaxRotation
                );

            Container.Bind<BirdController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}