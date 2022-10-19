using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class LootAction<TEntity> where TEntity : ILogicEntity
    {
        public abstract void GetLoot(ref TEntity entity, in LootContext context, List<LootValue> results);
    }
}
