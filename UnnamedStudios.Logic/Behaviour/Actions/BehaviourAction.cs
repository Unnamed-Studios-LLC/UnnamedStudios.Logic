namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public abstract class BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        public abstract void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values);

        public abstract void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values);
    }

    public abstract class BehaviourAction<TEntity, TState> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            TState generic = default;
            if (values != null)
            {
                generic = (TState)values;
            }
            Start(ref entity, ref behaviourContext, stateContext, ref generic);
            values = generic;
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            TState generic = default;
            if (values != null)
            {
                generic = (TState)values;
            }
            Update(ref entity, ref behaviourContext, stateContext, ref generic);
            values = generic;
        }

        protected abstract void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref TState values);

        protected abstract void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref TState values);
    }
}
