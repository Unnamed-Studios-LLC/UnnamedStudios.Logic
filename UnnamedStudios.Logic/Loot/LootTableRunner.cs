using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableRunner<TEntity> where TEntity : ILogicEntity
    {
        private readonly LootTable<TEntity> _lootTable;

        internal LootTableRunner(LootTable<TEntity> lootTable)
        {
            _lootTable = lootTable;
        }

        public void GetLoot(ref TEntity entity, in LootContext context, List<LootValue> results)
        {
            _lootTable.GetLoot(ref entity, in context, results);
        }
    }
}
