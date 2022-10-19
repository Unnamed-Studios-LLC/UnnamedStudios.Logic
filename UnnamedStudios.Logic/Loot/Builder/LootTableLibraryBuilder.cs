using UnnamedStudios.Logic.Abstract.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnnamedStudios.Logic.Loot.Builder
{
    public class LootTableLibraryBuilder<TEntity> where TEntity : ILogicEntity
    {
        private readonly LogicLibraryBuilder<LootTable<TEntity>, LootTableDefinition<TEntity>, LootTableBuilder<TEntity>, LootTableLibrary<TEntity>> _builder = new LogicLibraryBuilder<LootTable<TEntity>, LootTableDefinition<TEntity>, LootTableBuilder<TEntity>, LootTableLibrary<TEntity>>(Build);

        public LootTableLibraryBuilder<TEntity> AddAssembly<T>()
        {
            _builder.AddAssembly<T>();
            return this;
        }

        public LootTableLibraryBuilder<TEntity> AddAssembly(Type assemblyType)
        {
            _builder.AddAssembly(assemblyType);
            return this;
        }

        public LootTableLibraryBuilder<TEntity> AddAssembly(Assembly assembly)
        {
            _builder.AddAssembly(assembly);
            return this;
        }

        public LootTableLibraryBuilder<TEntity> AddDefinition(Type type)
        {
            _builder.AddDefinition(type);
            return this;
        }

        public LootTableLibrary<TEntity> Build()
        {
            return _builder.Build(x => new LootTableLibrary<TEntity>(x));
        }

        private static IEnumerable<LootTable<TEntity>> Build(LootTableDefinition<TEntity> definition)
        {
            var builder = definition.Build();
            return builder.GetLootTables();
        }
    }
}
