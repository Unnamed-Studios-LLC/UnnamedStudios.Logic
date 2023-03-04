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

    internal class State<TEntity, TWorld> : BehaviourAction<TEntity, TWorld, StateValues>
        where TWorld : ILogicWorld
    {
        private readonly int _stateNameId;
        private readonly int _defaultSubStateId;
        private readonly Group<TEntity, TWorld> _group;

        public State(string name, string defaultSubState, BehaviourAction<TEntity, TWorld>[] actions)
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

            _stateNameId = StateId.Get(name);
            _defaultSubStateId = StateId.Get(defaultSubState);
            _group = new Group<TEntity, TWorld>(actions);
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

        protected override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref StateValues values)
        {
            values = new StateValues(new StateContext(_defaultSubStateId, stateContext));
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref StateValues values)
        {
            if (!stateContext.InState(_stateNameId))
            {
                values.Running = false;
                return;
            }

            if (!values.Running)
            {
                values.Context.Current = _defaultSubStateId;
                _group.Start(ref entity, ref behaviourContext, values.Context, ref values.GroupValues);
                values.Running = true;
            }
            _group.Update(ref entity, ref behaviourContext, values.Context, ref values.GroupValues);
            values.Running = stateContext.InState(_stateNameId);
        }
    }
}
