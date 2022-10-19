using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Spawn<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, ushort> _typeGetter;
        private readonly TargetingFunc<TEntity> _targetingFunc;
        private readonly bool _isMinion;

        public Spawn(EntityFunc<TEntity, ushort> typeGetter, TargetingFunc<TEntity> targetingFunc, bool isMinion)
        {
            _typeGetter = typeGetter ?? throw new ArgumentNullException(nameof(typeGetter));
            _targetingFunc = targetingFunc ?? throw new ArgumentNullException(nameof(targetingFunc));
            _isMinion = isMinion;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var targetCoordinates = _targetingFunc(ref entity);
            if (targetCoordinates == null)
            {
                return;
            }

            var type = _typeGetter(ref entity);
            entity.Spawn(type, targetCoordinates.Value, _isMinion, out _);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
