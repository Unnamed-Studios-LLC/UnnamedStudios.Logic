namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SyncMinionStates : BehaviourAction
    {
        private readonly EntityFunc<bool> _filter;

        public SyncMinionStates(EntityFunc<bool> filter)
        {
            _filter = filter ?? throw new System.ArgumentNullException(nameof(filter));
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            var stateId = entity.StateId;
            for (int i = 0; i < entity.MinionCount; i++)
            {
                var minion = entity.GetMinion(i);
                if (!_filter(minion))
                {
                    continue;
                }

                minion.SetState(stateId);
            }
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
