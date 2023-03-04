using System;
using UnnamedStudios.Logic.Abstract;
using UnnamedStudios.Logic.Behaviour.Actions;

namespace UnnamedStudios.Logic.Behaviour
{
    internal class Behaviour<TKey, TEntity, TWorld> : LogicBase<TKey>
        where TWorld : ILogicWorld
    {
        private readonly State<TEntity, TWorld> _state;
        private State<TEntity, TWorld> _death;

        internal Behaviour(TKey key, string defaultSubState, Type classContext, BehaviourAction<TEntity, TWorld>[] actions) : base(key, classContext)
        {
            _state = new State<TEntity, TWorld>("_", defaultSubState, actions);
        }

        public void Death(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, ref object values)
        {
            if (_death == null) return;
            _death.SetState(_state.GetStateId(ref values), ref values);
            _death.Start(ref entity, ref behaviourContext, StateContext.Top, ref values);
            _death.Update(ref entity, ref behaviourContext, StateContext.Top, ref values);
        }

        public int? GetStateId(ref object values)
        {
            if (values == null)
            {
                return null;
            }
            return _state.GetStateId(ref values);
        }

        public void SetState(int stateId, ref object values)
        {
            _state.SetState(stateId, ref values);
        }

        public void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, ref object values)
        {
            _state.Start(ref entity, ref behaviourContext, StateContext.Top, ref values);
        }

        public void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, ref object values)
        {
            _state.Update(ref entity, ref behaviourContext, StateContext.Top, ref values);
        }

        internal void SetDeath(BehaviourAction<TEntity, TWorld>[] actions)
        {
            _death = new State<TEntity, TWorld>("_", "_", actions);
        }
    }
}
