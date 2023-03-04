using System.Collections.Generic;

namespace UnnamedStudios.Logic.Abstract
{
    internal class LogicLibrary<TKey, TLogic> where TLogic : LogicBase<TKey>
    {
        private readonly Dictionary<TKey, TLogic> _logic;

        internal LogicLibrary(Dictionary<TKey, TLogic> behaviours)
        {
            _logic = behaviours;
        }

        public int Count => _logic.Count;

        public bool Contains(TKey type)
        {
            return _logic.ContainsKey(type);
        }

        public bool TryGetLogic(TKey type, out TLogic logic)
        {
            return _logic.TryGetValue(type, out logic);
        }
    }
}
