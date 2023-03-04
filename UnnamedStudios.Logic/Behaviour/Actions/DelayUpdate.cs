namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class DelayUpdateValues
    {
        public long Remaining;
        public object GroupValues;
    }

    internal class DelayUpdate<TEntity, TWorld> : BehaviourAction<TEntity, TWorld, DelayUpdateValues>
        where TWorld : ILogicWorld
    {
        private readonly EntityWorldFunc<TEntity, TWorld, long> _delayGetter;
        private readonly Group<TEntity, TWorld> _group;

        public DelayUpdate(EntityWorldFunc<TEntity, TWorld, long> delayGetter, BehaviourAction<TEntity, TWorld>[] actions)
        {
            if (actions is null)
            {
                throw new System.ArgumentNullException(nameof(actions));
            }

            _delayGetter = delayGetter ?? throw new System.ArgumentNullException(nameof(delayGetter));
            _group = new Group<TEntity, TWorld>(actions);
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref DelayUpdateValues values)
        {
            values = new DelayUpdateValues
            {
                Remaining = _delayGetter(ref entity, ref behaviourContext.World)
            };

            _group.Start(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref DelayUpdateValues values)
        {
            var newRemaining = values.Remaining - behaviourContext.TimeDelta;
            if (newRemaining < 0)
            {
                _group.Update(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
            }
            values.Remaining = newRemaining;
        }
    }
}
