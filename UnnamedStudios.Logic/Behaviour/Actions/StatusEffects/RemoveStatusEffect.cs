namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class RemoveStatusEffect<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly uint _type;

        public RemoveStatusEffect(uint type)
        {
            _type = type;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            entity.RemoveStatusEffect(_type);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
