using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Entity
{
    public interface ILogicWorld<TEntity> where TEntity : ILogicEntity
    {
        ref TEntity GetClosestPlayer(ref TEntity entity, float scanRadius, out bool found);
        ref TEntity GetClosestVisiblePlayer(ref TEntity entity, float scanRadius, out bool found);
        ref TEntity GetLeader(ref TEntity minion, out bool found);
        ref TEntity GetMinion(ref TEntity leader, int index, out bool found);

        ref TEntity Spawn(ushort type, Vec2 coordinates, bool isMinion, out bool success);
    }
}
