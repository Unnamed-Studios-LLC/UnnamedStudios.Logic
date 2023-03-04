using UnnamedStudios.Logic.Abstract;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Behaviour
{
    public class BehaviourLibrary<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly LogicLibrary<TKey, Behaviour<TKey, TEntity, TWorld>> _library;

        internal BehaviourLibrary(Dictionary<TKey, Behaviour<TKey, TEntity, TWorld>> behaviours)
        {
            _library = new LogicLibrary<TKey, Behaviour<TKey, TEntity, TWorld>>(behaviours);
        }

        public int Count => _library.Count;

        public bool Contains(TKey type)
        {
            return _library.Contains(type);
        }

        public bool TryGetBehaviour(TKey type, out BehaviourRunner<TKey, TEntity, TWorld> runner)
        {
            if (_library.TryGetLogic(type, out var behaviour))
            {
                runner = new BehaviourRunner<TKey, TEntity, TWorld>(behaviour);
                return true;
            }

            runner = default;
            return false;
        }
    }
}
