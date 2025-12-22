namespace _Project.Scripts.Gameplay.PipeSystem
{
    public abstract class RebuilderBase : IRebuilder
    {
        public abstract void Rebuild(IRebuildable rebuildable);
    }
}