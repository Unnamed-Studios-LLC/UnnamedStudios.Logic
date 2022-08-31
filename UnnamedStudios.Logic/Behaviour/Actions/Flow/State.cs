using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class StateValues
    {
        public object GroupValues;

        public StateValues(StateContext context)
        {
            Context = context;
        }

        public StateContext Context { get; }
        public bool Running { get; set; }
    }

    internal class State : BehaviourAction<StateValues>
    {
        private readonly int _stateNameId;
        private readonly int _defaultSubStateId;
        private readonly Group _group;

        public State(string name, string defaultSubState, BehaviourAction[] actions)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (defaultSubState is null)
            {
                throw new ArgumentNullException(nameof(defaultSubState));
            }

            if (actions is null)
            {
                throw new ArgumentNullException(nameof(actions));
            }

            if (name.Equals(string.Empty, StringComparison.Ordinal))
            {
                throw new ArgumentException("State name cannot be empty", nameof(name));
            }

            _stateNameId = StateContext.RegisterStateName(name);
            _defaultSubStateId = StateContext.RegisterStateName(defaultSubState);
            _group = new Group(actions);
        }

        public int GetStateId(ref object values)
        {
            var stateValues = (StateValues)values;
            return stateValues.Context.Current;
        }

        public void SetState(int stateId, ref object values)
        {
            var stateValues = (StateValues)values;
            stateValues.Context.Current = stateId;
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref StateValues values)
        {
            values = new StateValues(new StateContext(_defaultSubStateId, stateContext));
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref StateValues values)
        {
            if (stateContext.InState(_stateNameId))
            {
                if (!values.Running)
                {
                    values.Context.Current = _defaultSubStateId;
                    _group.Start(entity, behaviourContext, values.Context, ref values.GroupValues);
                    values.Running = true;
                }
                _group.Update(entity, behaviourContext, values.Context, ref values.GroupValues);
            }
            else
            {
                values.Running = false;
            }
        }
    }
}
