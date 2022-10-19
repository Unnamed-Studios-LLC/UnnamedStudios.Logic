using UnnamedStudios.Logic.Behaviour.Arguments;
using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class MoveToConstantTimeValues
    {
        public long RemainingTime { get; set; }
    }

    internal class MoveToConstantTime<TEntity> : BehaviourAction<TEntity, MoveToConstantTimeValues> where TEntity : ILogicEntity
    {
        private readonly long _time;
        private readonly float _minRangeSqr;
        private readonly MoveArgs _args;
        private readonly TargetingFunc<TEntity> _targetingFunc;

        public MoveToConstantTime(long time, float minRange, MoveArgs args, TargetingFunc<TEntity> targetingFunc)
        {
            _time = time;
            _minRangeSqr = minRange * minRange;
            _args = args;
            _targetingFunc = targetingFunc ?? throw new ArgumentNullException(nameof(targetingFunc));
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref MoveToConstantTimeValues values)
        {
            values = new MoveToConstantTimeValues
            {
                RemainingTime = _time
            };
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref MoveToConstantTimeValues values)
        {
            var targetCoordinates = _targetingFunc(ref entity, behaviourContext.World);
            if (targetCoordinates == null ||
                (entity.Coordinates - targetCoordinates.Value).SqrMagnitude < _minRangeSqr)
            {
                return;
            }

            if (values.RemainingTime <= behaviourContext.TimeDelta)
            {
                entity.MoveBy(targetCoordinates.Value - entity.Coordinates, _args);
                return;
            }

            var scalar = behaviourContext.TimeDelta / (float)values.RemainingTime;
            var vector = targetCoordinates.Value - entity.Coordinates;
            entity.MoveBy(vector * scalar, _args);

            values.RemainingTime -= behaviourContext.TimeDelta;
        }
    }
}
