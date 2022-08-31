using UnnamedStudios.Logic.Behaviour.Actions;
using System;
using UnnamedStudios.Logic.Abstract;

namespace UnnamedStudios.Logic.Behaviour
{
    internal class Behaviour : LogicBase
    {
        public readonly static StateContext Top = new StateContext(0, null);

        private readonly State _state;

        public Behaviour(ushort type, string defaultSubState, Type classContext, BehaviourAction[] actions) : base(type, classContext)
        {
            _state = new State("_", defaultSubState, actions);
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

        public void Update(ILogicEntity entity, BehaviourContext behaviourContext, ref object values)
        {
            if (values == null)
            {
                _state.Start(entity, behaviourContext, Top, ref values);
            }
            _state.Update(entity, behaviourContext, Top, ref values);
        }
    }
}
