using UnnamedStudios.Logic.Abstract.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnnamedStudios.Logic.Behaviour.Builder
{
    public class BehaviourLibraryBuilder
    {
        private readonly LogicLibraryBuilder<Behaviour, BehaviourDefinition, BehaviourBuilder, BehaviourLibrary> _builder = new LogicLibraryBuilder<Behaviour, BehaviourDefinition, BehaviourBuilder, BehaviourLibrary>(Build);

        public BehaviourLibraryBuilder AddAssembly<T>()
        {
            _builder.AddAssembly<T>();
            return this;
        }

        public BehaviourLibraryBuilder AddAssembly(Type assemblyType)
        {
            _builder.AddAssembly(assemblyType);
            return this;
        }

        public BehaviourLibraryBuilder AddAssembly(Assembly assembly)
        {
            _builder.AddAssembly(assembly);
            return this;
        }

        public BehaviourLibraryBuilder AddDefinition(Type type)
        {
            _builder.AddDefinition(type);
            return this;
        }

        public BehaviourLibrary Build()
        {
            return _builder.Build(x => new BehaviourLibrary(x));
        }

        private static IEnumerable<Behaviour> Build(BehaviourDefinition definition)
        {
            var builder = definition.Build();
            return builder.GetBehaviours();
        }
    }
}
