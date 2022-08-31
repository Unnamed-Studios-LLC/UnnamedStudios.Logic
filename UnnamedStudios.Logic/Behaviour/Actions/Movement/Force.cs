namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Force : BehaviourAction
    {
        private readonly byte _magnitude;

        public Force(byte magnitude)
        {
            _magnitude = magnitude;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            entity.AddForce(_magnitude);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
