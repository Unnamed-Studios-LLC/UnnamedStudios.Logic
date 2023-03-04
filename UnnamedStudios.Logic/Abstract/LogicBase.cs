using System;

namespace UnnamedStudios.Logic.Abstract
{
    internal abstract class LogicBase<TKey>
    {
        protected LogicBase(TKey key, Type classContext)
        {
            Key = key;
            ClassContext = classContext;
        }

        public TKey Key { get; }
        public Type ClassContext { get; }
    }
}
