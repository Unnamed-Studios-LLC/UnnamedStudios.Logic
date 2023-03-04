namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Once<TEntity, TWorld> : BehaviourAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly Group<TEntity, TWorld> _group;

        public Once(BehaviourAction<TEntity, TWorld>[] actions)
        {
            _group = new Group<TEntity, TWorld>(actions);
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {
            values = false;
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
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
