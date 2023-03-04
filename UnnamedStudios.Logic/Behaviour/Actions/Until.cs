namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class UntilValues
    {
        public long Remaining;
        public object GroupValues;
    }

    internal class Until<TEntity, TWorld> : BehaviourAction<TEntity, TWorld, UntilValues>
        where TWorld : ILogicWorld
    {
        private readonly EntityWorldFunc<TEntity, TWorld, long> _untilGetter;
        private readonly Group<TEntity, TWorld> _group;

        public Until(EntityWorldFunc<TEntity, TWorld, long> untilGetter, BehaviourAction<TEntity, TWorld>[] actions)
        {
            if (actions is null)
            {
                throw new System.ArgumentNullException(nameof(actions));
            }

            _untilGetter = untilGetter ?? throw new System.ArgumentNullException(nameof(untilGetter));
            _group = new Group<TEntity, TWorld>(actions);
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref UntilValues values)
        {
            values = new UntilValues
            {
                Remaining = _untilGetter(ref entity, ref behaviourContext.World)
            };

            _group.Start(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref UntilValues values)
        {
            values.Remaining -= behaviourContext.TimeDelta;
            if (values.Remaining >= 0)
            {
                _group.Update(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
            }
        }
    }
}
