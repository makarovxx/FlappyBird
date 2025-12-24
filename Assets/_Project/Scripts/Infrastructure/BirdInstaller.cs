using _Project.Scripts.Gameplay.BirdComponents;
using _Project.Scripts.Gameplay.Physics;
using _Project.Scripts.Gameplay.TimeController;
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

            // BindBirdTracker();
            BindCollisionHandler();
            BindBirdController();
            BindBird();

            Container.DeclareSignal<GamePauseSignal>();
            Container.DeclareSignal<GameResumeSignal>();
            Container.DeclareSignal<GameRestartSignal>();
            Container.DeclareSignal<GameStartSignal>();
            Container.DeclareSignal<GameOverSignal>();
            Container.DeclareSignal<ScoreChangedSignal>();
            
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeController>().AsSingle();
        }

        private void BindCollisionHandler()
        {
            Container.Bind<BirdCollisionHandler>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindBird()
        {
            Container.Bind<Bird>().FromComponentInHierarchy().AsSingle();
            // Container.BindInterfacesAndSelfTo<Bird>().AsSingle();
        }

        private void BindBirdController()
        {
            Container.Bind<IRigidBodyMovable>()
                .To<Movement>()
                .AsSingle()
                .WithArguments(_config.OriginalTransform,_config.Body,_config.Rigidbody, _config.Velocity);

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
                    _config.Body,
                    _config.MinRotation,
                    _config.MaxRotation
                );

            Container.BindInterfacesAndSelfTo<BirdController>().AsCached();
        }
    }
}