namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Once : BehaviourAction
    {
        private readonly Group _group;

        public Once(BehaviourAction[] actions)
        {
            _group = new Group(actions);
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            values = false;
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            var value = (bool)values;
            if (!value)
            {
                object discard = null;
                _group.Start(entity, behaviourContext, stateContext, ref discard);
                _group.Update(entity, behaviourContext, stateContext, ref discard);
            }
            values = true;
        }
    }
}
