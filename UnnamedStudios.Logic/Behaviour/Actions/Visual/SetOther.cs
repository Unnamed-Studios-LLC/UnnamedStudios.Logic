namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public class SetOther<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly int _otherIndex;

        public SetOther(int otherIndex)
        {
            _otherIndex = otherIndex;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            entity.SetOtherIndex(_otherIndex);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
