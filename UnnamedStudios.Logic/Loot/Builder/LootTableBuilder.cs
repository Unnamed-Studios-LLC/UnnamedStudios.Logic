using UnnamedStudios.Logic.Abstract.Builder;
using UnnamedStudios.Logic.Loot.Actions;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableBuilder<TEntity> where TEntity : ILogicEntity
    {
        private readonly LogicBuilder<LootTable<TEntity>> _builder = new LogicBuilder<LootTable<TEntity>>();
        private readonly Type _classContext;

        public LootTableBuilder(Type classContext)
        {
            _classContext = classContext;
        }

        public LootTableBuilder<TEntity> Init(ushort type, params LootAction<TEntity>[] actions)
        {
            _builder.Add(new LootTable<TEntity>(type, _classContext, actions));
            return this;
        }

        internal IEnumerable<LootTable<TEntity>> GetLootTables()
        {
            return _builder.GetLogic();
        }
    }
}
