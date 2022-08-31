namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class DelayValues
    {
        public long Remaining;
        public object GroupValues;
    }

    internal class Delay : BehaviourAction<DelayValues>
    {
        private readonly EntityFunc<long> _delayGetter;
        private readonly Group _group;

        public Delay(EntityFunc<long> delayGetter, BehaviourAction[] actions)
        {
            if (actions is null)
            {
                throw new System.ArgumentNullException(nameof(actions));
            }

            _delayGetter = delayGetter ?? throw new System.ArgumentNullException(nameof(delayGetter));
            _group = new Group(actions);
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref DelayValues values)
        {
            values = new DelayValues
            {
                Remaining = _delayGetter(entity)
            };
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref DelayValues values)
        {
            var newRemaining = values.Remaining - behaviourContext.TimeDelta;
            if (newRemaining < 0)
            {
                if (values.Remaining >= 0)
                {
                    _group.Start(entity, behaviourContext, stateContext, ref values.GroupValues);
                }
                _group.Update(entity, behaviourContext, stateContext, ref values.GroupValues);
            }
            values.Remaining = newRemaining;
        }
    }
}
