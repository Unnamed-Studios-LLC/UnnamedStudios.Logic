using UnnamedStudios.Logic.Loot.Actions;
using UnnamedStudios.Logic.Loot.Context;
using System;
using System.Collections.Generic;
using UnnamedStudios.Logic.Abstract;

namespace UnnamedStudios.Logic.Loot
{
    internal class LootTable<TEntity> : LogicBase where TEntity : ILogicEntity
    {
        private readonly LootAction<TEntity>[] _actions;

        public LootTable(ushort type, Type classContext, LootAction<TEntity>[] actions) : base(type, classContext)
        {
            _actions = actions;
        }

        public void GetLoot(ref TEntity entity, in LootContext context, List<LootValue> results)
        {
            foreach (var action in _actions)
            {
                action.GetLoot(ref entity, in context, results);
            }
        }
    }
}
