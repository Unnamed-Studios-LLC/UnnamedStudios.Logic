namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public abstract class ConditionalBehaviourAction : BehaviourAction
    {
        public abstract ConditionalBehaviourAction Else(params BehaviourAction[] actions);
    }

    internal abstract class ConditionalAction<T> : ConditionalBehaviourAction
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
