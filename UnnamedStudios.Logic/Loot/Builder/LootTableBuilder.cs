using UnnamedStudios.Logic.Abstract.Builder;
using UnnamedStudios.Logic.Loot.Actions;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableBuilder<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly LogicBuilder<TKey, LootTable<TKey, TEntity, TWorld>> _builder = new LogicBuilder<TKey, LootTable<TKey, TEntity, TWorld>>();
        private readonly Type _classContext;

        public LootTableBuilder(Type classContext)
        {
            _classContext = classContext;
        }

        public LootTableBuilder<TKey, TEntity, TWorld> Init(TKey key, params LootAction<TEntity, TWorld>[] actions)
        {
            _builder.Add(new LootTable<TKey, TEntity, TWorld>(key, _classContext, actions));
            return this;
        }

        internal IEnumerable<LootTable<TKey, TEntity, TWorld>> GetLootTables()
        {
            return _builder.GetLogic();
        }
    }
}
