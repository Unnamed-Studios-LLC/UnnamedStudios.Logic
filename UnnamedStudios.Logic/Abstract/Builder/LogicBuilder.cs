using System.Collections.Generic;

namespace UnnamedStudios.Logic.Abstract.Builder
{
    internal class LogicBuilder<TKey, TLogic> where TLogic : LogicBase<TKey>
    {
        private readonly List<TLogic> _logics = new List<TLogic>();

        public void Add(TLogic logic)
        {
            _logics.Add(logic);
        }

        public IEnumerable<TLogic> GetLogic()
        {
            return _logics;
        }
    }
}
