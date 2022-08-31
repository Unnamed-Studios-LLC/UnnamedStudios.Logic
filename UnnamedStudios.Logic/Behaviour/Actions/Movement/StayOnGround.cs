using UnnamedStudios.Logic.Behaviour.Arguments;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public class StayOnGroundValues
    {
        public Vec2? LastValidCoordinates { get; set; }
    }

    internal class StayOnGround : BehaviourAction<StayOnGroundValues>
    {
        private readonly float _speed;
        private readonly float _minRangeSqr;
        private readonly MoveArgs _args;
        private readonly ushort[] _groundTypes;

        public StayOnGround(float speed, float minRange, MoveArgs args, ushort[] groundTypes)
        {
            _speed = speed;
            _minRangeSqr = minRange * minRange;
            _args = args;
            _groundTypes = groundTypes;
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref StayOnGroundValues values)
        {
            values = new StayOnGroundValues();
            var coordinates = entity.Coordinates;
            if (AreCoordinatesValid(entity, coordinates))
            {
                values.LastValidCoordinates = coordinates;
            }
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref StayOnGroundValues values)
        {
            var coordinates = entity.Coordinates;
            if (AreCoordinatesValid(entity, coordinates))
            {
                values.LastValidCoordinates = coordinates;
                return;
            }

            if (values.LastValidCoordinates == null ||
                (entity.Coordinates - values.LastValidCoordinates.Value).SqrMagnitude < _minRangeSqr)
            {
                return;
            }

            var vector = values.LastValidCoordinates.Value - entity.Coordinates;
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

        private bool AreCoordinatesValid(ILogicEntity entity, Vec2 coordinates)
        {
            var groundType = entity.GetGroundType(coordinates);
            for (int i = 0; i < _groundTypes.Length; i++)
            {
                if (_groundTypes[i] == groundType)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
