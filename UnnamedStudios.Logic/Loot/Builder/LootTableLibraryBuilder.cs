using UnnamedStudios.Logic.Abstract.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableLibraryBuilder<TKey, TEntity, TWorld, TContext>
        where TWorld : ILogicWorld
    {
        private readonly LogicLibraryBuilder<TKey, LootTable<TKey, TEntity, TWorld, TContext>, LootTableDefinition<TKey, TEntity, TWorld, TContext>, LootTableBuilder<TKey, TEntity, TWorld, TContext>, LootTableLibrary<TKey, TEntity, TWorld, TContext>> _builder =
            new LogicLibraryBuilder<TKey, LootTable<TKey, TEntity, TWorld, TContext>, LootTableDefinition<TKey, TEntity, TWorld, TContext>, LootTableBuilder<TKey, TEntity, TWorld, TContext>, LootTableLibrary<TKey, TEntity, TWorld, TContext>>(Build);

        public LootTableLibraryBuilder<TKey, TEntity, TWorld, TContext> AddAssembly<T>()
        {
            _builder.AddAssembly<T>();
            return this;
        }

        public LootTableLibraryBuilder<TKey, TEntity, TWorld, TContext> AddAssembly(Type assemblyType)
        {
            _builder.AddAssembly(assemblyType);
            return this;
        }

        public LootTableLibraryBuilder<TKey, TEntity, TWorld, TContext> AddAssembly(Assembly assembly)
        {
            _builder.AddAssembly(assembly);
            return this;
        }

        public LootTableLibraryBuilder<TKey, TEntity, TWorld, TContext> AddDefinition(Type type)
        {
            _builder.AddDefinition(type);
            return this;
        }

        public LootTableLibrary<TKey, TEntity, TWorld, TContext> Build()
        {
            return _builder.Build(x => new LootTableLibrary<TKey, TEntity, TWorld, TContext>(x));
        }

        private static IEnumerable<LootTable<TKey, TEntity, TWorld, TContext>> Build(LootTableDefinition<TKey, TEntity, TWorld, TContext> definition)
        {
            var builder = definition.Build();
            return builder.GetLootTables();
        }
    }
}
