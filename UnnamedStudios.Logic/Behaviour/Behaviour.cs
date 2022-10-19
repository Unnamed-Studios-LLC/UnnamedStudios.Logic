using UnnamedStudios.Logic.Behaviour.Actions;
using System;
using UnnamedStudios.Logic.Abstract;

namespace UnnamedStudios.Logic.Behaviour
{
    internal class Behaviour<TEntity> : LogicBase where TEntity : ILogicEntity
    {
        public readonly static StateContext Top = new StateContext(0, null);

        private readonly State<TEntity> _state;

        public Behaviour(ushort type, string defaultSubState, Type classContext, BehaviourAction<TEntity>[] actions) : base(type, classContext)
        {
            _state = new State<TEntity>("_", defaultSubState, actions);
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

        public void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, ref object values)
        {
            if (values == null)
            {
                _state.Start(ref entity, ref behaviourContext, Top, ref values);
            }
            _state.Update(ref entity, ref behaviourContext, Top, ref values);
        }
    }
}
