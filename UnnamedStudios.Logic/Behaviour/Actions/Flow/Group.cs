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

    internal class Group<TEntity> : BehaviourAction<TEntity, GroupValues> where TEntity : ILogicEntity
    {
        private readonly BehaviourAction<TEntity>[] _actions;

        public Group(BehaviourAction<TEntity>[] actions)
        {
            _actions = actions ?? throw new System.ArgumentNullException(nameof(actions));
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref GroupValues values)
        {
            if (_actions.Length == 0)
            {
                return;
            }

            values = new GroupValues(new object[_actions.Length]);
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].Start(ref entity, ref behaviourContext, stateContext, ref values.ActionData[i]);
            }
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref GroupValues values)
        {
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].Update(ref entity, ref behaviourContext, stateContext, ref values.ActionData[i]);
            }
        }
    }
}
