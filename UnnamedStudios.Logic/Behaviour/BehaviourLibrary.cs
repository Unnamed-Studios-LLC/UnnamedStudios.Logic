using UnnamedStudios.Logic.Abstract;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Behaviour
{
    public class BehaviourLibrary<TEntity> where TEntity : ILogicEntity
    {
        private readonly LogicLibrary<Behaviour<TEntity>> _library;

        internal BehaviourLibrary(Dictionary<ushort, Behaviour<TEntity>> behaviours)
        {
            _library = new LogicLibrary<Behaviour<TEntity>>(behaviours);
        }

        public int Count => _library.Count;

        public bool Contains(ushort type)
        {
            return _library.Contains(type);
        }

        public bool TryGetBehaviour(ushort type, out BehaviourRunner<TEntity> runner)
        {
            if (_library.TryGetLogic(type, out var behaviour))
            {
                runner = new BehaviourRunner<TEntity>(behaviour);
                return true;
            }

            runner = default;
            return false;
        }
    }
}
