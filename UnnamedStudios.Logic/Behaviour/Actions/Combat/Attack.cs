namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Attack : BehaviourAction
    {
        private readonly byte _attackIndex;
        private readonly TargetingFunc _targetingFunc;

        public Attack(byte attackIndex, TargetingFunc targetingFunc)
        {
            _attackIndex = attackIndex;
            _targetingFunc = targetingFunc ?? throw new System.ArgumentNullException(nameof(targetingFunc));
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            var targetCoordinates = _targetingFunc(entity);
            if (targetCoordinates == null)
            {
                return;
            }

            entity.Attack(_attackIndex, targetCoordinates.Value, entity.ReferenceType);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
