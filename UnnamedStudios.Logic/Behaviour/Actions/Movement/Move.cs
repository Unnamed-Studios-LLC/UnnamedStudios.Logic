using UnnamedStudios.Logic.Behaviour.Arguments;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Move<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, Vec2> _vectorGetter;
        private readonly MoveArgs _args;

        public Move(EntityFunc<TEntity, Vec2> vectorGetter, MoveArgs args)
        {
            _vectorGetter = vectorGetter ?? throw new System.ArgumentNullException(nameof(vectorGetter));
            _args = args;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            values = _vectorGetter(ref entity);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var vector = (Vec2)values;
            var delta = behaviourContext.TimeDelta / 1000f;
            entity.MoveBy(vector * delta, _args);
        }
    }
}
