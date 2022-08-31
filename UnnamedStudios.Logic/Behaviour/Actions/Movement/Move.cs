using UnnamedStudios.Logic.Behaviour.Arguments;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Move : BehaviourAction
    {
        private readonly EntityFunc<Vec2> _vectorGetter;
        private readonly MoveArgs _args;

        public Move(EntityFunc<Vec2> vectorGetter, MoveArgs args)
        {
            _vectorGetter = vectorGetter ?? throw new System.ArgumentNullException(nameof(vectorGetter));
            _args = args;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            values = _vectorGetter(entity);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            var vector = (Vec2)values;
            var delta = behaviourContext.TimeDelta / 1000f;
            entity.MoveBy(vector * delta, _args);
        }
    }
}
