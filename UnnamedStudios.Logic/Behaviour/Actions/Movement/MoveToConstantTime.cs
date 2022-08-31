using UnnamedStudios.Logic.Behaviour.Arguments;
using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class MoveToConstantTimeValues
    {
        public long RemainingTime { get; set; }
    }

    internal class MoveToConstantTime : BehaviourAction<MoveToConstantTimeValues>
    {
        private readonly long _time;
        private readonly float _minRangeSqr;
        private readonly MoveArgs _args;
        private readonly TargetingFunc _targetingFunc;

        public MoveToConstantTime(long time, float minRange, MoveArgs args, TargetingFunc targetingFunc)
        {
            _time = time;
            _minRangeSqr = minRange * minRange;
            _args = args;
            _targetingFunc = targetingFunc ?? throw new ArgumentNullException(nameof(targetingFunc));
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref MoveToConstantTimeValues values)
        {
            values = new MoveToConstantTimeValues
            {
                RemainingTime = _time
            };
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref MoveToConstantTimeValues values)
        {
            var targetCoordinates = _targetingFunc(entity);
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
