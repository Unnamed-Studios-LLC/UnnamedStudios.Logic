using UnnamedStudios.Logic.Loot.Actions;
using UnnamedStudios.Logic.Loot.Context;
using System;
using System.Collections.Generic;
using UnnamedStudios.Logic.Abstract;

namespace UnnamedStudios.Logic.Loot
{
    internal class LootTable<TKey, TEntity, TWorld> : LogicBase<TKey>
        where TWorld : ILogicWorld
    {
        private readonly LootAction<TEntity, TWorld>[] _actions;

        public LootTable(TKey key, Type classContext, LootAction<TEntity, TWorld>[] actions) : base(key, classContext)
        {
            _actions = actions;
        }

        public void GetLoot(ref TEntity entity, ref TWorld world, in LootContext context, List<LootValue> results)
        {
            foreach (var action in _actions)
            {
                action.GetLoot(ref entity, ref world, in context, results);
            }
        }
    }
}
