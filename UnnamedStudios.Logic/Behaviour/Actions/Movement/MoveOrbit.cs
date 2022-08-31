using UnnamedStudios.Logic.Behaviour.Arguments;
using System;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class MoveOrbitValues
    {
        public float Distance { get; set; }
        public float Speed { get; set; }
        public float Angle { get; set; }
    }

    internal class MoveOrbit : BehaviourAction<MoveOrbitValues>
    {
        private readonly EntityFunc<float> _distanceGetter;
        private readonly EntityFunc<float> _speedGetter;
        private readonly MoveArgs _args;
        private readonly TargetingFunc _targetingFunc;

        public MoveOrbit(EntityFunc<float> distanceGetter, EntityFunc<float> speedGetter, MoveArgs args, TargetingFunc targetingFunc)
        {
            _distanceGetter = distanceGetter ?? throw new ArgumentNullException(nameof(distanceGetter));
            _speedGetter = speedGetter ?? throw new ArgumentNullException(nameof(speedGetter));
            _args = args;
            _targetingFunc = targetingFunc ?? throw new ArgumentNullException(nameof(targetingFunc));
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref MoveOrbitValues values)
        {
            values = new MoveOrbitValues
            {
                Distance = _distanceGetter(entity),
                Speed = _speedGetter(entity)
            };

            var targetCoordinates = _targetingFunc(entity);
            if (targetCoordinates == null ||
                targetCoordinates.Value == entity.Coordinates)
            {
                return;
            }

            values.Angle = (targetCoordinates.Value - entity.Coordinates).Angle;
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref MoveOrbitValues values)
        {
            var maxSpeed = values.Speed * behaviourContext.TimeDeltaF;
            if (values.Distance != 0)
            {
                values.Angle += maxSpeed / values.Distance;
            }

            var targetCoordinates = _targetingFunc(entity);
            if (targetCoordinates == null)
            {
                return;
            }

            var orbitTarget = targetCoordinates.Value + Angle.Vec2(values.Angle) * values.Distance;
            var moveVector = orbitTarget - entity.Coordinates;
            if (moveVector.SqrMagnitude < maxSpeed * maxSpeed)
            {
                entity.MoveTo(orbitTarget, _args);
                return;
            }

            moveVector = moveVector.SetMagnitude(Math.Abs(maxSpeed));
            entity.MoveBy(moveVector, _args);
        }
    }
}
