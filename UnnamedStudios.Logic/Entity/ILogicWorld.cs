namespace UnnamedStudios.Logic
{
    public interface ILogicWorld
    {
        float Random01();
        int RandomRange(int minInclusive, int maxExclusive);
    }

    public static class ILogicWorldExtensions
    {
        public static T RandomOf<T, TWorld>(this T[] group, ref TWorld world)
            where TWorld : ILogicWorld
        {
            if (group == null || group.Length == 0) return default;
            return group[world.RandomRange(0, group.Length)];
        }
    }
    /*
    public interface ILogicWorld<TEntity> where TEntity : ILogicEntity
    {
        TEntity GetMinion(ref TEntity leader, int index, out bool found);
        TEntity GetLeader(ref TEntity minion, out bool found);
        void LoopMinions(ref TEntity leader, EntityAction<TEntity> func);
    }

    public static class ILogicWorldExtensions
    {
        public static void LoopMinions<TEntity, TWorld>(this TWorld world, ref TEntity leader, EntityWorldAction<TEntity, TWorld> func)
            where TEntity : ILogicEntity
            where TWorld : ILogicWorld<TEntity>
        {
            world.LoopMinions(ref leader, (ref TEntity entity) => func(ref entity, ref world));
        }
    }
    */
}
