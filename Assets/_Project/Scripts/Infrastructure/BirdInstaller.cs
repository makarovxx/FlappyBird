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

            Container.DeclareSignal<ScoreChangedSignal>();
            Container.DeclareSignal<DiedBirdSignal>();
            Container.Bind<ScoreCounter>().AsSingle();
        }

        private void BindBirdAndMover()
        {
            Container.Bind<Bird>().AsSingle();

            Container.Bind<BirdCollisionHandler>()
                .FromComponentInHierarchy()
                .AsSingle();
            TestBind();
        }

        private void TestBind()
        {
            // 3. Movement
            Container.Bind<IRigidBodyMovable>()
                .To<Movement>()
                .AsSingle()
                .WithArguments(_config.Rigidbody, _config.Velocity);

            // 4. Jump
            Container.Bind<IForceImplementable>()
                .To<ForceHandler>()
                .AsSingle()
                .WithArguments(_config.Rigidbody,
                    _config.JumpForce,
                    _config.JumpDirection,
                    _config.ForceMode
                );

            // 5. Rotation
            Container.Bind<IRotatable>()
                .To<ClampedRotationHandler>()
                .AsSingle()
                .WithArguments(
                    _config.RotationSpeed,
                    _config.Transform,
                    _config.MinRotation,
                    _config.MaxRotation
                );

            // 6. Controller
            Container.Bind<BirdController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}