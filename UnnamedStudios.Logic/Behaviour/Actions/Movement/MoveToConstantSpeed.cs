using UnnamedStudios.Logic.Behaviour.Arguments;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class MoveToConstantSpeed<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly float _speed;
        private readonly float _minRangeSqr;
        private readonly MoveArgs _args;
        private readonly TargetingFunc<TEntity> _targetingFunc;

        public MoveToConstantSpeed(float speed, float minRange, MoveArgs args, TargetingFunc<TEntity> targetingFunc)
        {
            _speed = speed;
            _minRangeSqr = minRange * minRange;
            _args = args;
            _targetingFunc = targetingFunc ?? throw new System.ArgumentNullException(nameof(targetingFunc));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var targetCoordinates = _targetingFunc(ref entity);
            if (targetCoordinates == null ||
                (entity.Coordinates - targetCoordinates.Value).SqrMagnitude < _minRangeSqr)
            {
                return;
            }

            var vector = targetCoordinates.Value - entity.Coordinates;
            var delta = behaviourContext.TimeDelta / 1000f;
            var minMagnitude = _speed * delta;
            var magnitude = vector.Magnitude;

            if (magnitude < minMagnitude)
            {
                entity.MoveBy(vector, _args);
                return;
            }

            entity.MoveBy(Vec2.SetMagnitude(vector, magnitude, minMagnitude), _args);
        }
    }
}
