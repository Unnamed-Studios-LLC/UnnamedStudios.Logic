using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Spawn : BehaviourAction
    {
        private readonly EntityFunc<ushort> _typeGetter;
        private readonly TargetingFunc _targetingFunc;
        private readonly bool _isMinion;

        public Spawn(EntityFunc<ushort> typeGetter, TargetingFunc targetingFunc, bool isMinion)
        {
            _typeGetter = typeGetter ?? throw new ArgumentNullException(nameof(typeGetter));
            _targetingFunc = targetingFunc ?? throw new ArgumentNullException(nameof(targetingFunc));
            _isMinion = isMinion;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            var targetCoordinates = _targetingFunc(entity);
            if (targetCoordinates == null)
            {
                return;
            }

            var type = _typeGetter(entity);
            entity.Spawn(type, targetCoordinates.Value, _isMinion);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
