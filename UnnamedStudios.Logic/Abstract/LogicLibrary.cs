using System.Collections.Generic;

namespace UnnamedStudios.Logic.Abstract
{
    internal class LogicLibrary<TLogic> where TLogic : LogicBase
    {
        private readonly Dictionary<ushort, TLogic> _logic;

        internal LogicLibrary(Dictionary<ushort, TLogic> behaviours)
        {
            _logic = behaviours;
        }

        public int Count => _logic.Count;

        public bool Contains(ushort type)
        {
            return _logic.ContainsKey(type);
        }

        public bool TryGetLogic(ushort type, out TLogic logic)
        {
            return _logic.TryGetValue(type, out logic);
        }
    }
}
