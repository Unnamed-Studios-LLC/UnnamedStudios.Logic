namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Force<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly byte _magnitude;

        public Force(byte magnitude)
        {
            _magnitude = magnitude;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            entity.AddForce(_magnitude);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
