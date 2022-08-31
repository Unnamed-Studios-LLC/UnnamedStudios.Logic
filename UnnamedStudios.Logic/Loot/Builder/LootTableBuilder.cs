using UnnamedStudios.Logic.Abstract.Builder;
using UnnamedStudios.Logic.Loot.Actions;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableBuilder
    {
        private readonly LogicBuilder<LootTable> _builder = new LogicBuilder<LootTable>();
        private readonly Type _classContext;

        public LootTableBuilder(Type classContext)
        {
            _classContext = classContext;
        }

        public LootTableBuilder Init(ushort type, params LootAction[] actions)
        {
            _builder.Add(new LootTable(type, _classContext, actions));
            return this;
        }

        internal IEnumerable<LootTable> GetLootTables()
        {
            return _builder.GetLogic();
        }
    }
}
