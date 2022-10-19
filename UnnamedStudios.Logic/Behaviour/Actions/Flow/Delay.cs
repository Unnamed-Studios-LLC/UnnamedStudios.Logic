namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class DelayValues
    {
        public long Remaining;
        public object GroupValues;
    }

    internal class Delay<TEntity> : BehaviourAction<TEntity, DelayValues> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, long> _delayGetter;
        private readonly Group<TEntity> _group;

        public Delay(EntityFunc<TEntity, long> delayGetter, BehaviourAction<TEntity>[] actions)
        {
            if (actions is null)
            {
                throw new System.ArgumentNullException(nameof(actions));
            }

            _delayGetter = delayGetter ?? throw new System.ArgumentNullException(nameof(delayGetter));
            _group = new Group<TEntity>(actions);
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref DelayValues values)
        {
            values = new DelayValues
            {
                Remaining = _delayGetter(ref entity)
            };
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref DelayValues values)
        {
            var newRemaining = values.Remaining - behaviourContext.TimeDelta;
            if (newRemaining < 0)
            {
                if (values.Remaining >= 0)
                {
                    _group.Start(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
                }
                _group.Update(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
            }
            values.Remaining = newRemaining;
        }
    }
}
