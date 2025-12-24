namespace _Project.Scripts.Gameplay.Physics
{
    public interface IRotatable : IRotatableInstant, IRotatableSmoothly
    {
        void ResetRotation();
    }
}