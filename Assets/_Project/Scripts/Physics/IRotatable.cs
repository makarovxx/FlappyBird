namespace _Project.Scripts.Physics
{
    public interface IRotatable
    {
        void RotateInstant();
        void RotateSmoothly(float deltaTime);
        void ResetRotation();
    }
}