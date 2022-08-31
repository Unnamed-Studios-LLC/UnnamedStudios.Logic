namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class GroupValues
    {
        public GroupValues(object[] actionData)
        {
            ActionData = actionData;
        }

        public object[] ActionData { get; }
    }

    internal class Group : BehaviourAction<GroupValues>
    {
        private readonly BehaviourAction[] _actions;

        public Group(BehaviourAction[] actions)
        {
            _actions = actions ?? throw new System.ArgumentNullException(nameof(actions));
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref GroupValues values)
        {
            if (_actions.Length == 0)
            {
                return;
            }

            values = new GroupValues(new object[_actions.Length]);
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].Start(entity, behaviourContext, stateContext, ref values.ActionData[i]);
            }
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref GroupValues values)
        {
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].Update(entity, behaviourContext, stateContext, ref values.ActionData[i]);
            }
        }
    }
}
