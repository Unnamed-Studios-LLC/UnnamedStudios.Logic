namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Once<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly Group<TEntity> _group;

        public Once(BehaviourAction<TEntity>[] actions)
        {
            _group = new Group<TEntity>(actions);
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            values = false;
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var value = (bool)values;
            if (!value)
            {
                object discard = null;
                _group.Start(ref entity, ref behaviourContext, stateContext, ref discard);
                _group.Update(ref entity, ref behaviourContext, stateContext, ref discard);
            }
            values = true;
        }
    }
}
