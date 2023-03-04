using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class LootAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        public abstract void GetLoot(ref TEntity entity, ref TWorld world, in LootContext context, List<LootValue> results);
    }
}
