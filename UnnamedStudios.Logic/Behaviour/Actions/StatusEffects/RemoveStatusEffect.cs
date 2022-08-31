namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class RemoveStatusEffect : BehaviourAction
    {
        private readonly uint _type;

        public RemoveStatusEffect(uint type)
        {
            _type = type;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            entity.RemoveStatusEffect(_type);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
