using UnnamedStudios.Logic.Loot.Actions;
using UnnamedStudios.Logic.Loot.Context;
using System;
using System.Collections.Generic;
using UnnamedStudios.Logic.Abstract;

namespace UnnamedStudios.Logic.Loot
{
    internal class LootTable : LogicBase
    {
        private readonly LootAction[] _actions;

        public LootTable(ushort type, Type classContext, LootAction[] actions) : base(type, classContext)
        {
            _actions = actions;
        }

        public IEnumerable<LootValue> GetLoot(ILogicEntity entity, LootContext context)
        {
            foreach (var action in _actions)
            {
                foreach (var loot in action.GetLoot(entity, context))
                {
                    yield return loot;
                }
            }
        }
    }
}
