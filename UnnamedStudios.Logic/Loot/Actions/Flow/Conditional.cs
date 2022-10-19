using UnnamedStudios.Logic.Loot.Context;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    internal class Conditional<TEntity> : ConditionalLootAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly List<(ConditionalLootDelegate, LootAction<TEntity>[])> _conditions = new List<(ConditionalLootDelegate, LootAction<TEntity>[])>();
        private LootAction<TEntity>[] _else;

        public Conditional(ConditionalLootDelegate condition, LootAction<TEntity>[] actions)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            _conditions.Add((condition, actions));
        }

        public override void GetLoot(ref TEntity entity, in LootContext context, List<LootValue> results)
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
                    action.GetLoot(ref entity, in context, results);
                }
                return;
            }

            if (_else == null)
            {
                return;
            }

            foreach (var action in _else)
            {
                action.GetLoot(ref entity, in context, results);
            }
        }

        public override LootAction<TEntity> Else(LootAction<TEntity>[] actions)
        {
            _else = actions;
            return this;
        }

        public override ConditionalLootAction<TEntity> ElseIf(ConditionalLootDelegate condition, LootAction<TEntity>[] actions)
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
