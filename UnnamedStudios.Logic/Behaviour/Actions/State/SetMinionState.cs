namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SetMinionState<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly int _stateId;
        private readonly EntityFunc<TEntity, bool> _filter;

        public SetMinionState(string name, EntityFunc<TEntity, bool> filter)
        {
            _stateId = StateContext.RegisterStateName(name);
            _filter = filter ?? throw new System.ArgumentNullException(nameof(filter));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            behaviourContext.World.LoopMinions(ref entity, (ref TEntity minion) =>
            {
                if (!_filter(ref minion)) return;
                minion.SetState(_stateId);
            });
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
