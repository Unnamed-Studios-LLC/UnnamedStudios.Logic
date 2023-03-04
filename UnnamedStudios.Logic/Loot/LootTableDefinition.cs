using UnnamedStudios.Logic.Loot.Actions;
using UnnamedStudios.Logic.Loot.Builder;
using System.Linq;

namespace UnnamedStudios.Logic.Loot
{
    public abstract class LootTableDefinition<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        public abstract void Build(LootTableBuilder<TKey, TEntity, TWorld> builder);

        protected static ConditionalLootAction<TEntity, TWorld> If(ConditionalLootDelegate condition, params LootAction<TEntity, TWorld>[] actions) => new Conditional<TEntity, TWorld>(condition, actions);

        protected static LootAction<TEntity, TWorld> Item(float chance, ushort type) => Item(chance, type, 1);
        protected static LootAction<TEntity, TWorld> Item(float chance, ushort type, long count) => OneOf(chance, new LootValue(type, count));

        protected static LootAction<TEntity, TWorld> OneOf(float chance, params ushort[] types) => OneOf(chance, types.Select(x => new LootValue(x, 1)).ToArray());
        protected static LootAction<TEntity, TWorld> OneOf(float chance, params LootValue[] itemValues) => new Items<TEntity, TWorld>(chance, itemValues);

        internal LootTableBuilder<TKey, TEntity, TWorld> Build()
        {
            var builder = new LootTableBuilder<TKey, TEntity, TWorld>(GetType());
            Build(builder);
            return builder;
        }
    }
}
