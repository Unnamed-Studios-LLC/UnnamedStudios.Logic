using UnnamedStudios.Logic.Loot.Actions;
using UnnamedStudios.Logic.Loot.Builder;
using UnnamedStudios.Logic.Loot.Context;
using System;
using System.Linq;

namespace UnnamedStudios.Logic.Loot
{
    public abstract class LootTableDefinition
    {
        public abstract void Build(LootTableBuilder builder);

        protected static ConditionalLootAction If(Func<LootContext, bool> condition, params LootAction[] actions) => new Conditional(condition, actions);

        protected static LootAction Item(float chance, ushort type) => Item(chance, type, 1);
        protected static LootAction Item(float chance, ushort type, long count) => OneOf(chance, new LootValue(type, count));

        protected static LootAction OneOf(float chance, params ushort[] types) => OneOf(chance, types.Select(x => new LootValue(x, 1)).ToArray());
        protected static LootAction OneOf(float chance, params LootValue[] itemValues) => new Items(chance, itemValues);

        internal LootTableBuilder Build()
        {
            var builder = new LootTableBuilder(GetType());
            Build(builder);
            return builder;
        }
    }
}
