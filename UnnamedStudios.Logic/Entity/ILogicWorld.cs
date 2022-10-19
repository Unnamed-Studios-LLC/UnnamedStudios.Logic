using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Entity
{
    public interface ILogicWorld<TEntity> where TEntity : ILogicEntity
    {
        TEntity GetMinion(ref TEntity leader, int index, out bool found);
    }
}
