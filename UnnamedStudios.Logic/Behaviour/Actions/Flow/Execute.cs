using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Execute : BehaviourAction
    {
        private readonly EntityAction _entityAction;

        public Execute(EntityAction entityAction)
        {
            _entityAction = entityAction ?? throw new ArgumentNullException(nameof(entityAction));
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            _entityAction(entity);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
