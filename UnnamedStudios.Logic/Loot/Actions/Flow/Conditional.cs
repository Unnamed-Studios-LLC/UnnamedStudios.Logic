using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    internal class Conditional<TEntity, TWorld, TContext> : ConditionalLootAction<TEntity, TWorld, TContext>
        where TWorld : ILogicWorld
    {
        private readonly List<(ConditionalLootDelegate<TContext>, LootAction<TEntity, TWorld, TContext>[])> _conditions = new List<(ConditionalLootDelegate<TContext>, LootAction<TEntity, TWorld, TContext>[])>();
        private LootAction<TEntity, TWorld, TContext>[] _else;

        public Conditional(ConditionalLootDelegate<TContext> condition, params LootAction<TEntity, TWorld, TContext>[] actions)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            _conditions.Add((condition, actions));
        }

        public override void GetLoot(ref TEntity entity, ref TWorld world, in TContext context, List<LootValue> results)
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

        public override LootAction<TEntity, TWorld, TContext> Else(params LootAction<TEntity, TWorld, TContext>[] actions)
        {
            _else = actions;
            return this;
        }

        public override ConditionalLootAction<TEntity, TWorld, TContext> ElseIf(ConditionalLootDelegate<TContext> condition, params LootAction<TEntity, TWorld, TContext>[] actions)
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
