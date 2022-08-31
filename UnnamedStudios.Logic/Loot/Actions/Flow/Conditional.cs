using UnnamedStudios.Logic.Loot.Context;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    internal class Conditional : ConditionalLootAction
    {
        private readonly List<(Func<LootContext, bool>, LootAction[])> _conditions = new List<(Func<LootContext, bool>, LootAction[])>();
        private LootAction[] _else;

        public Conditional(Func<LootContext, bool> condition, LootAction[] actions)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            _conditions.Add((condition, actions));
        }

        public override IEnumerable<LootValue> GetLoot(ILogicEntity entity, LootContext context)
        {
            for (int i = 0; i < _conditions.Count; i++)
            {
                var pair = _conditions[i];
                if (!pair.Item1(context))
                {
                    continue;
                }

                foreach (var action in pair.Item2)
                {
                    foreach (var item in action.GetLoot(entity, context))
                    {
                        yield return item;
                    }
                }
                yield break;
            }

            if (_else == null)
            {
                yield break;
            }

            foreach (var action in _else)
            {
                foreach (var item in action.GetLoot(entity, context))
                {
                    yield return item;
                }
            }
        }

        public override LootAction Else(LootAction[] actions)
        {
            _else = actions;
            return this;
        }

        public override ConditionalLootAction ElseIf(Func<LootContext, bool> condition, LootAction[] actions)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            _conditions.Add((condition, actions));
            return this;
        }
    }
}
