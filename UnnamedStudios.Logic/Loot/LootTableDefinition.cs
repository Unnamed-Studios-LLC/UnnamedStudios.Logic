using UnnamedStudios.Logic.Loot.Actions;
using UnnamedStudios.Logic.Loot.Builder;
using System.Linq;

namespace UnnamedStudios.Logic.Loot
{
    public abstract class LootTableDefinition<TKey, TEntity, TWorld, TContext>
        where TWorld : ILogicWorld
    {
        public abstract void Build(LootTableBuilder<TKey, TEntity, TWorld, TContext> builder);

        protected static ConditionalLootAction<TEntity, TWorld, TContext> If(ConditionalLootDelegate<TContext> condition, params LootAction<TEntity, TWorld, TContext>[] actions) => new Conditional<TEntity, TWorld, TContext>(condition, actions);

        protected static LootAction<TEntity, TWorld, TContext> Item(float chance, ushort type) => Item(chance, type, 1);
        protected static LootAction<TEntity, TWorld, TContext> Item(float chance, ushort type, long count) => OneOf(chance, new LootValue(type, count));

        protected static LootAction<TEntity, TWorld, TContext> OneOf(float chance, params ushort[] types) => OneOf(chance, types.Select(x => new LootValue(x, 1)).ToArray());
        protected static LootAction<TEntity, TWorld, TContext> OneOf(float chance, params LootValue[] itemValues) => new Items<TEntity, TWorld, TContext>(chance, itemValues);

        internal LootTableBuilder<TKey, TEntity, TWorld, TContext> Build()
        {
            var builder = new LootTableBuilder<TKey, TEntity, TWorld, TContext>(GetType());
            Build(builder);
            return builder;
        }
    }
}
