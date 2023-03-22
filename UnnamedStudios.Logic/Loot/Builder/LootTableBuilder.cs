using UnnamedStudios.Logic.Abstract.Builder;
using UnnamedStudios.Logic.Loot.Actions;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableBuilder<TKey, TEntity, TWorld, TContext>
        where TWorld : ILogicWorld
    {
        private readonly LogicBuilder<TKey, LootTable<TKey, TEntity, TWorld, TContext>> _builder = new LogicBuilder<TKey, LootTable<TKey, TEntity, TWorld, TContext>>();
        private readonly Type _classContext;

        public LootTableBuilder(Type classContext)
        {
            _classContext = classContext;
        }

        public LootTableBuilder<TKey, TEntity, TWorld, TContext> Init(TKey key, params LootAction<TEntity, TWorld, TContext>[] actions)
        {
            _builder.Add(new LootTable<TKey, TEntity, TWorld, TContext>(key, _classContext, actions));
            return this;
        }

        internal IEnumerable<LootTable<TKey, TEntity, TWorld, TContext>> GetLootTables()
        {
            return _builder.GetLogic();
        }
    }
}
