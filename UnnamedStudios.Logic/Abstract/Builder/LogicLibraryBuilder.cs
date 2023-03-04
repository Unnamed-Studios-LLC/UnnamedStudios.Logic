using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnnamedStudios.Logic.Abstract.Builder
{
    internal class LogicLibraryBuilder<TKey, TLogic, TDefinition, TBuilder, TLibrary>
        where TLogic : LogicBase<TKey>
        where TDefinition : class
    {
        private readonly Dictionary<TKey, TLogic> _logic = new Dictionary<TKey, TLogic>();

        private readonly Func<TDefinition, IEnumerable<TLogic>> _logicGetter;

        public LogicLibraryBuilder(Func<TDefinition, IEnumerable<TLogic>> logicGetter)
        {
            _logicGetter = logicGetter ?? throw new ArgumentNullException(nameof(logicGetter));
        }

        public LogicLibraryBuilder<TKey, TLogic, TDefinition, TBuilder, TLibrary> AddAssembly<T>()
        {
            return AddAssembly(typeof(T));
        }

        public LogicLibraryBuilder<TKey, TLogic, TDefinition, TBuilder, TLibrary> AddAssembly(Type assemblyType)
        {
            return AddAssembly(assemblyType.Assembly);
        }

        public LogicLibraryBuilder<TKey, TLogic, TDefinition, TBuilder, TLibrary> AddAssembly(Assembly assembly)
        {
            var baseType = typeof(TDefinition);
            var types = assembly.GetTypes()
                .Where(x => baseType.IsAssignableFrom(x) && !x.IsAbstract);

            foreach (var type in types)
            {
                AddDefinition(type);
            }

            return this;
        }

        public LogicLibraryBuilder<TKey, TLogic, TDefinition, TBuilder, TLibrary> AddDefinition(Type type)
        {
            AssertType(type);

            var definition = Activator.CreateInstance(type) as TDefinition;

            foreach (var logic in _logicGetter(definition))
            {
                AddLogic(logic);
            }

            return this;
        }

        public TLibrary Build(Func<Dictionary<TKey, TLogic>, TLibrary> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            return factory(_logic);
        }

        private void AddLogic(TLogic logic)
        {
            if (_logic.TryGetValue(logic.Key, out var existing))
            {
                throw new Exception($"Conflicting behaviour of type '{logic.Key}' found in '{existing.ClassContext}' and '{logic.ClassContext}'");
            }

            _logic.Add(logic.Key, logic);
        }

        private void AssertType(Type type)
        {
            var baseType = typeof(TDefinition);
            if (!baseType.IsAssignableFrom(type))
            {
                throw new Exception($"'{type.FullName}' is not assignable to '{baseType.FullName}'");
            }

            if (type.IsAbstract)
            {
                throw new Exception($"'{type.FullName}' is abstract and cannot be created.");
            }

            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var constructor in constructors)
            {
                if (constructor.GetParameters().Length == 0)
                {
                    return;
                }
            }

            throw new Exception($"'{type.FullName}' does not contain a parameterless constructor.");
        }
    }
}
