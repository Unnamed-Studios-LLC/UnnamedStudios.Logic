namespace UnnamedStudios.Logic.Entity
{
    public delegate void MinionDelegate<TEntity>(ref TEntity minion) where TEntity : ILogicEntity;

    public interface ILogicWorld<TEntity> where TEntity : ILogicEntity
    {
        TEntity GetMinion(ref TEntity leader, int index, out bool found);
        void LoopMinions(ref TEntity leader, MinionDelegate<TEntity> func);
    }
}
