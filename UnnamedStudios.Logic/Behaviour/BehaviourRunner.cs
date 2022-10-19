namespace UnnamedStudios.Logic.Behaviour
{
    public class BehaviourRunner<TEntity> where TEntity : ILogicEntity
    {
        private object _values;
        private readonly Behaviour<TEntity> _behaviour;

        internal BehaviourRunner(Behaviour<TEntity> behaviour)
        {
            _behaviour = behaviour;
        }

        public int? StateId => _behaviour.GetStateId(ref _values);

        public void Run(ref TEntity entity, ref BehaviourContext<TEntity> context)
        {
            _behaviour.Update(ref entity, ref context, ref _values);
        }

        public void SetState(int stateId)
        {
            _behaviour.SetState(stateId, ref _values);
        }
    }
}
