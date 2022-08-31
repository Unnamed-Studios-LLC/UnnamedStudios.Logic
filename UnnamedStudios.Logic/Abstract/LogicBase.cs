using System;

namespace UnnamedStudios.Logic.Abstract
{
    internal abstract class LogicBase
    {
        protected LogicBase(ushort type, Type classContext)
        {
            Type = type;
            ClassContext = classContext;
        }

        public ushort Type { get; }
        public Type ClassContext { get; }
    }
}
