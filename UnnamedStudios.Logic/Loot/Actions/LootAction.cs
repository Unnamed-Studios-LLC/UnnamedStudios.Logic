using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class LootAction
    {
        public abstract IEnumerable<LootValue> GetLoot(ILogicEntity entity, LootContext context);
    }
}
