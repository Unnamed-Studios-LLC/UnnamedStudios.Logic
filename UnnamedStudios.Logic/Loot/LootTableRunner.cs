using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableRunner<TKey, TEntity, TWorld, TContext> where TWorld : ILogicWorld
    {
        private readonly LootTable<TKey, TEntity, TWorld, TContext> _lootTable;

        internal LootTableRunner(LootTable<TKey, TEntity, TWorld, TContext> lootTable)
        {
            _lootTable = lootTable;
        }

        public void GetLoot(ref TEntity entity, ref TWorld world, in TContext context, List<LootValue> results)
        {
            _lootTable.GetLoot(ref entity, ref world, in context, results);
        }
    }
}
