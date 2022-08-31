using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class ConditionalValues
    {
        public bool FalseRunning;
        public object FalseValues;
        public bool TrueRunning;
        public object TrueValues;
    }

    internal class Conditional : ConditionalAction<ConditionalValues>
    {
        private readonly static Group _falseDefault = new Group(Array.Empty<BehaviourAction>());

        private readonly EntityFunc<bool> _condition;
        private readonly Group _trueGroup;
        private readonly Group _falseGroup;

        public Conditional(EntityFunc<bool> condition, BehaviourAction[] trueActions)
        {
            _condition = condition;
            _trueGroup = new Group(trueActions);
            _falseGroup = _falseDefault;
        }

        private Conditional(EntityFunc<bool> condition, Group trueGroup, BehaviourAction[] falseActions)
        {
            _condition = condition;
            _trueGroup = trueGroup;
            _falseGroup = new Group(falseActions);
        }

        public override ConditionalBehaviourAction Else(params BehaviourAction[] actions)
        {
            return new Conditional(_condition, _trueGroup, actions);
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref ConditionalValues values)
        {
            values = new ConditionalValues();
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref ConditionalValues values)
        {
            if (_condition(entity))
            {
                values.FalseRunning = false;
                if (!values.TrueRunning)
                {
                    _trueGroup.Start(entity, behaviourContext, stateContext, ref values.TrueValues);
                    values.TrueRunning = true;
                }
                _trueGroup.Update(entity, behaviourContext, stateContext, ref values.TrueValues);
            }
            else
            {
                values.TrueRunning = false;
                if (!values.FalseRunning)
                {
                    _falseGroup.Start(entity, behaviourContext, stateContext, ref values.FalseValues);
                    values.FalseRunning = true;
                }
                _falseGroup.Update(entity, behaviourContext, stateContext, ref values.FalseValues);
            }
        }
    }
}
