namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SetMinionState : BehaviourAction
    {
        private readonly int _stateId;
        private readonly EntityFunc<bool> _filter;

        public SetMinionState(string name, EntityFunc<bool> filter)
        {
            _stateId = StateContext.RegisterStateName(name);
            _filter = filter ?? throw new System.ArgumentNullException(nameof(filter));
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            for (int i = 0; i < entity.MinionCount; i++)
            {
                var minion = entity.GetMinion(i);
                if (!_filter(minion))
                {
                    continue;
                }

                minion.SetState(_stateId);
            }
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
