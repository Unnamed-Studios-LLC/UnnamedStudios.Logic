using UnnamedStudios.Logic.Abstract.Builder;
using UnnamedStudios.Logic.Behaviour.Actions;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Behaviour.Builder
{
    public class BehaviourBuilder<TEntity> where TEntity : ILogicEntity
    {
        private readonly LogicBuilder<Behaviour<TEntity>> _builder = new LogicBuilder<Behaviour<TEntity>>();
        private readonly Type _classContext;

        public BehaviourBuilder(Type classContext)
        {
            _classContext = classContext;
        }

        public BehaviourBuilder<TEntity> Init(ushort type, params BehaviourAction<TEntity>[] actions)
        {
            return Init(type, string.Empty, actions);
        }

        public BehaviourBuilder<TEntity> Init(ushort type, int randomDelay, params BehaviourAction<TEntity>[] actions)
        {
            return Init(type, string.Empty, randomDelay, actions);
        }

        public BehaviourBuilder<TEntity> Init(ushort type, string defaultSubState, params BehaviourAction<TEntity>[] actions)
        {
            return Init(type, defaultSubState, 1000, actions);
        }

        public BehaviourBuilder<TEntity> Init(ushort type, string defaultSubState, int randomDelay, params BehaviourAction<TEntity>[] actions)
        {
            if (randomDelay > 0)
            {
                actions = new BehaviourAction<TEntity>[]
                {
                    new Delay<TEntity>((ref TEntity x) => x.RandomRange(0, randomDelay), actions)
                };
            }

            _builder.Add(new Behaviour<TEntity>(type, defaultSubState, _classContext, actions));
            return this;
        }

        internal IEnumerable<Behaviour<TEntity>> GetBehaviours()
        {
            return _builder.GetLogic();
        }
    }
}
