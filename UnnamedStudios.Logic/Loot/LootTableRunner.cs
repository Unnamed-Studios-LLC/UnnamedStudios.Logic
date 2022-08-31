using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableRunner
    {
        private readonly LootTable _lootTable;

        internal LootTableRunner(LootTable lootTable)
        {
            _lootTable = lootTable;
        }

        public IEnumerable<LootValue> GetLoot(ILogicEntity entity, LootContext context)
        {
            return _lootTable.GetLoot(entity, context);
        }
    }
}
