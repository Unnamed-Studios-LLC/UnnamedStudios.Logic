namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SyncMinionStates<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, bool> _filter;

        public SyncMinionStates(EntityFunc<TEntity, bool> filter)
        {
            _filter = filter ?? throw new System.ArgumentNullException(nameof(filter));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var stateId = entity.StateId;
            behaviourContext.World.LoopMinions(ref entity, (ref TEntity minion) =>
            {
                if (!_filter(ref minion)) return;
                minion.SetState(stateId);
            });
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
