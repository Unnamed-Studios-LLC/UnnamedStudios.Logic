using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SetState : BehaviourAction
    {
        private readonly EntityFunc<int> _stateIdGetter;
        private readonly int _parentLevel;

        public SetState(string name, int parentLevel)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Equals(string.Empty, StringComparison.Ordinal))
            {
                throw new ArgumentException("State name cannot be empty", nameof(name));
            }

            var stateId = StateContext.RegisterStateName(name);
            _stateIdGetter = x => stateId;
            _parentLevel = parentLevel;
        }

        public SetState(EntityFunc<int> stateIdGetter, int parentLevel)
        {
            _stateIdGetter = stateIdGetter;
            _parentLevel = parentLevel;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            int level = 0;
            do
            {
                if (level == _parentLevel)
                {
                    stateContext.Current = _stateIdGetter(entity);
                    return;
                }
                stateContext = stateContext.Parent;
                level++;
            }
            while (stateContext != null && stateContext != Behaviour.Top);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
