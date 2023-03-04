namespace UnnamedStudios.Logic.Behaviour
{
    public class BehaviourRunner<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private object _values;
        private readonly Behaviour<TKey, TEntity, TWorld> _behaviour;

        internal BehaviourRunner(Behaviour<TKey, TEntity, TWorld> behaviour)
        {
            _behaviour = behaviour;
        }

        public int? StateId => _behaviour.GetStateId(ref _values);

        public void Death(ref TEntity entity, ref BehaviourContext<TWorld> context)
        {
            _behaviour.Death(ref entity, ref context, ref _values);
        }

        public void SetState(int stateId)
        {
            _behaviour.SetState(stateId, ref _values);
        }

        public void Start(ref TEntity entity, ref BehaviourContext<TWorld> context)
        {
            _behaviour.Start(ref entity, ref context, ref _values);
        }

        public void Update(ref TEntity entity, ref BehaviourContext<TWorld> context)
        {
            _behaviour.Update(ref entity, ref context, ref _values);
        }
    }
}
