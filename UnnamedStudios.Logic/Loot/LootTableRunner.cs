using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableRunner<TKey, TEntity, TWorld> where TWorld : ILogicWorld
    {
        private readonly LootTable<TKey, TEntity, TWorld> _lootTable;

        internal LootTableRunner(LootTable<TKey, TEntity, TWorld> lootTable)
        {
            _lootTable = lootTable;
        }

        public void GetLoot(ref TEntity entity, ref TWorld world, in LootContext context, List<LootValue> results)
        {
            _lootTable.GetLoot(ref entity, ref world, in context, results);
        }
    }
}
