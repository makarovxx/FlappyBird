namespace _Project.Scripts.Gameplay.Physics
{
    public interface IRigidBodyMovable : IMovable
    {
        void ApplyMoveSpeed();
    }

    public interface IMovable
    {
        void ResetPosition();

        void Stop();
    }
}