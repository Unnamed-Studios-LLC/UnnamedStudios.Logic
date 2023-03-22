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
            _group.Start(ref entity, ref behaviourContext, stateContext, ref values);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
