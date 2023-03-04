using UnnamedStudios.Logic.Abstract.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableLibraryBuilder<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly LogicLibraryBuilder<TKey, LootTable<TKey, TEntity, TWorld>, LootTableDefinition<TKey, TEntity, TWorld>, LootTableBuilder<TKey, TEntity, TWorld>, LootTableLibrary<TKey, TEntity, TWorld>> _builder =
            new LogicLibraryBuilder<TKey, LootTable<TKey, TEntity, TWorld>, LootTableDefinition<TKey, TEntity, TWorld>, LootTableBuilder<TKey, TEntity, TWorld>, LootTableLibrary<TKey, TEntity, TWorld>>(Build);

        public LootTableLibraryBuilder<TKey, TEntity, TWorld> AddAssembly<T>()
        {
            _builder.AddAssembly<T>();
            return this;
        }

        public LootTableLibraryBuilder<TKey, TEntity, TWorld> AddAssembly(Type assemblyType)
        {
            _builder.AddAssembly(assemblyType);
            return this;
        }

        public LootTableLibraryBuilder<TKey, TEntity, TWorld> AddAssembly(Assembly assembly)
        {
            _builder.AddAssembly(assembly);
            return this;
        }

        public LootTableLibraryBuilder<TKey, TEntity, TWorld> AddDefinition(Type type)
        {
            _builder.AddDefinition(type);
            return this;
        }

        public LootTableLibrary<TKey, TEntity, TWorld> Build()
        {
            return _builder.Build(x => new LootTableLibrary<TKey, TEntity, TWorld>(x));
        }

        private static IEnumerable<LootTable<TKey, TEntity, TWorld>> Build(LootTableDefinition<TKey, TEntity, TWorld> definition)
        {
            var builder = definition.Build();
            return builder.GetLootTables();
        }
    }
}
