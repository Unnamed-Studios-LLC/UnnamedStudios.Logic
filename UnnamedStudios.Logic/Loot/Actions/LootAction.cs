using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class LootAction<TEntity, TWorld, TContext>
        where TWorld : ILogicWorld
    {
        public abstract void GetLoot(ref TEntity entity, ref TWorld world, in TContext context, List<LootValue> results);
    }
}
