using UnnamedStudios.Logic.Abstract.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnnamedStudios.Logic.Behaviour.Builder
{
    public class BehaviourLibraryBuilder<TEntity> where TEntity : ILogicEntity
    {
        private readonly LogicLibraryBuilder<Behaviour<TEntity>, BehaviourDefinition<TEntity>, BehaviourBuilder<TEntity>, BehaviourLibrary<TEntity>> _builder = new LogicLibraryBuilder<Behaviour<TEntity>, BehaviourDefinition<TEntity>, BehaviourBuilder<TEntity>, BehaviourLibrary<TEntity>>(Build);

        public BehaviourLibraryBuilder<TEntity> AddAssembly<T>()
        {
            _builder.AddAssembly<T>();
            return this;
        }

        public BehaviourLibraryBuilder<TEntity> AddAssembly(Type assemblyType)
        {
            _builder.AddAssembly(assemblyType);
            return this;
        }

        public BehaviourLibraryBuilder<TEntity> AddAssembly(Assembly assembly)
        {
            _builder.AddAssembly(assembly);
            return this;
        }

        public BehaviourLibraryBuilder<TEntity> AddDefinition(Type type)
        {
            _builder.AddDefinition(type);
            return this;
        }

        public BehaviourLibrary<TEntity> Build()
        {
            return _builder.Build(x => new BehaviourLibrary<TEntity>(x));
        }

        private static IEnumerable<Behaviour<TEntity>> Build(BehaviourDefinition<TEntity> definition)
        {
            var builder = definition.Build();
            return builder.GetBehaviours();
        }
    }
}
