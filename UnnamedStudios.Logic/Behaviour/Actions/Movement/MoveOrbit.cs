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

    internal class MoveOrbit<TEntity> : BehaviourAction<TEntity, MoveOrbitValues> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, float> _distanceGetter;
        private readonly EntityFunc<TEntity, float> _speedGetter;
        private readonly MoveArgs _args;
        private readonly TargetingFunc<TEntity> _targetingFunc;

        public MoveOrbit(EntityFunc<TEntity, float> distanceGetter, EntityFunc<TEntity, float> speedGetter, MoveArgs args, TargetingFunc<TEntity> targetingFunc)
        {
            _distanceGetter = distanceGetter ?? throw new ArgumentNullException(nameof(distanceGetter));
            _speedGetter = speedGetter ?? throw new ArgumentNullException(nameof(speedGetter));
            _args = args;
            _targetingFunc = targetingFunc ?? throw new ArgumentNullException(nameof(targetingFunc));
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref MoveOrbitValues values)
        {
            values = new MoveOrbitValues
            {
                Distance = _distanceGetter(ref entity),
                Speed = _speedGetter(ref entity)
            };

            var targetCoordinates = _targetingFunc(ref entity, behaviourContext.World);
            if (targetCoordinates == null ||
                targetCoordinates.Value == entity.Coordinates)
            {
                return;
            }

            values.Angle = (targetCoordinates.Value - entity.Coordinates).Angle;
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref MoveOrbitValues values)
        {
            var maxSpeed = values.Speed * behaviourContext.TimeDeltaF;
            if (values.Distance != 0)
            {
                values.Angle += maxSpeed / values.Distance;
            }

            var targetCoordinates = _targetingFunc(ref entity, behaviourContext.World);
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
