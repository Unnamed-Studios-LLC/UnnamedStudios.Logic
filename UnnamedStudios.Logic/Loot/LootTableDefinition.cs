using UnnamedStudios.Logic.Loot.Actions;
using UnnamedStudios.Logic.Loot.Builder;
using System.Linq;

namespace UnnamedStudios.Logic.Loot
{
    public abstract class LootTableDefinition<TEntity> where TEntity : ILogicEntity
    {
        public abstract void Build(LootTableBuilder<TEntity> builder);

        protected static ConditionalLootAction<TEntity> If(ConditionalLootDelegate condition, params LootAction<TEntity>[] actions) => new Conditional<TEntity>(condition, actions);

        protected static LootAction<TEntity> Item(float chance, ushort type) => Item(chance, type, 1);
        protected static LootAction<TEntity> Item(float chance, ushort type, long count) => OneOf(chance, new LootValue(type, count));

        protected static LootAction<TEntity> OneOf(float chance, params ushort[] types) => OneOf(chance, types.Select(x => new LootValue(x, 1)).ToArray());
        protected static LootAction<TEntity> OneOf(float chance, params LootValue[] itemValues) => new Items<TEntity>(chance, itemValues);

        internal LootTableBuilder<TEntity> Build()
        {
            var builder = new LootTableBuilder<TEntity>(GetType());
            Build(builder);
            return builder;
        }
    }
}
