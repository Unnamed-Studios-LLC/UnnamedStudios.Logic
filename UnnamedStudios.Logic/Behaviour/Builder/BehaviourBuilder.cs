using UnnamedStudios.Logic.Abstract.Builder;
using UnnamedStudios.Logic.Behaviour.Actions;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Behaviour.Builder
{
    public class BehaviourBuilder
    {
        private readonly LogicBuilder<Behaviour> _builder = new LogicBuilder<Behaviour>();
        private readonly Type _classContext;

        public BehaviourBuilder(Type classContext)
        {
            _classContext = classContext;
        }

        public BehaviourBuilder Init(ushort type, params BehaviourAction[] actions)
        {
            return Init(type, string.Empty, actions);
        }

        public BehaviourBuilder Init(ushort type, int randomDelay, params BehaviourAction[] actions)
        {
            return Init(type, string.Empty, randomDelay, actions);
        }

        public BehaviourBuilder Init(ushort type, string defaultSubState, params BehaviourAction[] actions)
        {
            return Init(type, defaultSubState, 1000, actions);
        }

        public BehaviourBuilder Init(ushort type, string defaultSubState, int randomDelay, params BehaviourAction[] actions)
        {
            if (randomDelay > 0)
            {
                actions = new BehaviourAction[]
                {
                    new Delay(x => x.RandomRange(0, randomDelay), actions)
                };
            }

            _builder.Add(new Behaviour(type, defaultSubState, _classContext, actions));
            return this;
        }

        internal IEnumerable<Behaviour> GetBehaviours()
        {
            return _builder.GetLogic();
        }
    }
}
