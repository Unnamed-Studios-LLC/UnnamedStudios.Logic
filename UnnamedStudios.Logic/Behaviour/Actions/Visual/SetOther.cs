namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public class SetOther : BehaviourAction
    {
        private readonly int _otherIndex;

        public SetOther(int otherIndex)
        {
            _otherIndex = otherIndex;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            entity.SetOtherIndex(_otherIndex);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
