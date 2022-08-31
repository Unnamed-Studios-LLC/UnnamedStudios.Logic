using UnnamedStudios.Logic.Abstract;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Behaviour
{
    public class BehaviourLibrary
    {
        private readonly LogicLibrary<Behaviour> _library;

        internal BehaviourLibrary(Dictionary<ushort, Behaviour> behaviours)
        {
            _library = new LogicLibrary<Behaviour>(behaviours);
        }

        public int Count => _library.Count;

        public bool Contains(ushort type)
        {
            return _library.Contains(type);
        }

        public bool TryGetBehaviour(ushort type, out BehaviourRunner runner)
        {
            if (_library.TryGetLogic(type, out var behaviour))
            {
                runner = new BehaviourRunner(behaviour);
                return true;
            }

            runner = default;
            return false;
        }
    }
}
