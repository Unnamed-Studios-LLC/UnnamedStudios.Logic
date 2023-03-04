using UnnamedStudios.Logic.Loot.Context;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    internal class Conditional<TEntity, TWorld> : ConditionalLootAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly List<(ConditionalLootDelegate, LootAction<TEntity, TWorld>[])> _conditions = new List<(ConditionalLootDelegate, LootAction<TEntity, TWorld>[])>();
        private LootAction<TEntity, TWorld>[] _else;

        public Conditional(ConditionalLootDelegate condition, params LootAction<TEntity, TWorld>[] actions)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            _conditions.Add((condition, actions));
        }

        public override void GetLoot(ref TEntity entity, ref TWorld world, in LootContext context, List<LootValue> results)
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
                    action.GetLoot(ref entity, ref world, in context, results);
                }
                return;
            }

            if (_else == null)
            {
                return;
            }

            foreach (var action in _else)
            {
                action.GetLoot(ref entity, ref world, in context, results);
            }
        }

        public override LootAction<TEntity, TWorld> Else(params LootAction<TEntity, TWorld>[] actions)
        {
            _else = actions;
            return this;
        }

        public override ConditionalLootAction<TEntity, TWorld> ElseIf(ConditionalLootDelegate condition, params LootAction<TEntity, TWorld>[] actions)
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
