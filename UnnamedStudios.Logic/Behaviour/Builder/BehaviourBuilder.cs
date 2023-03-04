using UnnamedStudios.Logic.Abstract.Builder;
using UnnamedStudios.Logic.Behaviour.Actions;
using System;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Behaviour.Builder
{
    public class BehaviourBuilder<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly LogicBuilder<TKey, Behaviour<TKey, TEntity, TWorld>> _builder = new LogicBuilder<TKey, Behaviour<TKey, TEntity, TWorld>>();
        private readonly Type _classContext;
        private Behaviour<TKey, TEntity, TWorld> _currentBehaviour;

        public BehaviourBuilder(Type classContext)
        {
            _classContext = classContext;
        }

        public BehaviourBuilder<TKey, TEntity, TWorld> Init(TKey key, params BehaviourAction<TEntity, TWorld>[] actions)
        {
            return Init(key, string.Empty, actions);
        }

        public BehaviourBuilder<TKey, TEntity, TWorld> Init(TKey key, int randomDelay, params BehaviourAction<TEntity, TWorld>[] actions)
        {
            return Init(key, string.Empty, randomDelay, actions);
        }

        public BehaviourBuilder<TKey, TEntity, TWorld> Init(TKey key, string defaultSubState, params BehaviourAction<TEntity, TWorld>[] actions)
        {
            return Init(key, defaultSubState, 1000, actions);
        }

        public BehaviourBuilder<TKey, TEntity, TWorld> Init(TKey key, string defaultSubState, int randomDelay, params BehaviourAction<TEntity, TWorld>[] actions)
        {
            if (randomDelay > 0)
            {
                actions = new BehaviourAction<TEntity, TWorld>[]
                {
                    new Delay<TEntity, TWorld>((ref TEntity x, ref TWorld y) => y.RandomRange(0, randomDelay), actions)
                };
            }

            _currentBehaviour = new Behaviour<TKey, TEntity, TWorld>(key, defaultSubState, _classContext, actions);
            _builder.Add(_currentBehaviour);
            return this;
        }

        public BehaviourBuilder<TKey, TEntity, TWorld> OnDeath(params BehaviourAction<TEntity, TWorld>[] actions)
        {
            _currentBehaviour?.SetDeath(actions);
            return this;
        }

        internal IEnumerable<Behaviour<TKey, TEntity, TWorld>> GetBehaviours()
        {
            return _builder.GetLogic();
        }
    }
}
