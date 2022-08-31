namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public abstract class BehaviourAction
    {
        public abstract void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values);

        public abstract void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values);
    }

    internal abstract class BehaviourAction<T> : BehaviourAction
    {
        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            T generic = default;
            if (values != null)
            {
                generic = (T)values;
            }
            Start(entity, behaviourContext, stateContext, ref generic);
            values = generic;
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            T generic = default;
            if (values != null)
            {
                generic = (T)values;
            }
            Update(entity, behaviourContext, stateContext, ref generic);
            values = generic;
        }

        protected abstract void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref T values);

        protected abstract void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref T values);
    }
}
