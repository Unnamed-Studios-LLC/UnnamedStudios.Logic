using UnnamedStudios.Logic.Abstract.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableLibraryBuilder
    {
        private readonly LogicLibraryBuilder<LootTable, LootTableDefinition, LootTableBuilder, LootTableLibrary> _builder = new LogicLibraryBuilder<LootTable, LootTableDefinition, LootTableBuilder, LootTableLibrary>(Build);

        public LootTableLibraryBuilder AddAssembly<T>()
        {
            _builder.AddAssembly<T>();
            return this;
        }

        public LootTableLibraryBuilder AddAssembly(Type assemblyType)
        {
            _builder.AddAssembly(assemblyType);
            return this;
        }

        public LootTableLibraryBuilder AddAssembly(Assembly assembly)
        {
            _builder.AddAssembly(assembly);
            return this;
        }

        public LootTableLibraryBuilder AddDefinition(Type type)
        {
            _builder.AddDefinition(type);
            return this;
        }

        public LootTableLibrary Build()
        {
            return _builder.Build(x => new LootTableLibrary(x));
        }

        private static IEnumerable<LootTable> Build(LootTableDefinition definition)
        {
            var builder = definition.Build();
            return builder.GetLootTables();
        }
    }
}
