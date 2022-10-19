namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Attack<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly byte _attackIndex;
        private readonly TargetingFunc<TEntity> _targetingFunc;

        public Attack(byte attackIndex, TargetingFunc<TEntity> targetingFunc)
        {
            _attackIndex = attackIndex;
            _targetingFunc = targetingFunc ?? throw new System.ArgumentNullException(nameof(targetingFunc));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var targetCoordinates = _targetingFunc(ref entity, behaviourContext.World);
            if (targetCoordinates == null)
            {
                return;
            }

            entity.Attack(_attackIndex, targetCoordinates.Value, entity.ReferenceType);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
