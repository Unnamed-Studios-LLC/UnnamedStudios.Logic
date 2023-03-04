using UnnamedStudios.Logic.Abstract.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnnamedStudios.Logic.Behaviour.Builder
{
    public class BehaviourLibraryBuilder<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly LogicLibraryBuilder<TKey, Behaviour<TKey, TEntity, TWorld>, BehaviourDefinition<TKey, TEntity, TWorld>, BehaviourBuilder<TKey, TEntity, TWorld>, BehaviourLibrary<TKey, TEntity, TWorld>> _builder =
            new LogicLibraryBuilder<TKey, Behaviour<TKey, TEntity, TWorld>, BehaviourDefinition<TKey, TEntity, TWorld>, BehaviourBuilder<TKey, TEntity, TWorld>, BehaviourLibrary<TKey, TEntity, TWorld>>(Build);

        public BehaviourLibraryBuilder<TKey, TEntity, TWorld> AddAssembly<T>()
        {
            _builder.AddAssembly<T>();
            return this;
        }

        public BehaviourLibraryBuilder<TKey, TEntity, TWorld> AddAssembly(Type assemblyType)
        {
            _builder.AddAssembly(assemblyType);
            return this;
        }

        public BehaviourLibraryBuilder<TKey, TEntity, TWorld> AddAssembly(Assembly assembly)
        {
            _builder.AddAssembly(assembly);
            return this;
        }

        public BehaviourLibraryBuilder<TKey, TEntity, TWorld> AddDefinition(Type type)
        {
            _builder.AddDefinition(type);
            return this;
        }

        public BehaviourLibrary<TKey, TEntity, TWorld> Build()
        {
            return _builder.Build(x => new BehaviourLibrary<TKey, TEntity, TWorld>(x));
        }

        private static IEnumerable<Behaviour<TKey, TEntity, TWorld>> Build(BehaviourDefinition<TKey, TEntity, TWorld> definition)
        {
            var builder = definition.Build();
            return builder.GetBehaviours();
        }
    }
}
