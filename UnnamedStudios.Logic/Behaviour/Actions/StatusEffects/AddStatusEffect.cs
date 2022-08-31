using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class AddStatusEffect : BehaviourAction
    {
        private readonly uint _type;
        private readonly EntityFunc<int> _durationGetter;

        public AddStatusEffect(uint type, EntityFunc<int> durationGetter)
        {
            _type = type;
            _durationGetter = durationGetter ?? throw new ArgumentNullException(nameof(durationGetter));
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            entity.AddStatusEffect(_type, (uint)_durationGetter(entity));
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
