using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    /*
    public abstract class TargetingFunc
    {
        public abstract Vec2? GetTargetCoordinates(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values);
    }
    */

    /*
    internal abstract class TargetingFunc<T> : TargetingFunc
    {
        public override Vec2? GetTargetCoordinates(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            T generic = default;
            if (values != null)
            {
                generic = (T)values;
            }
            var coordinates = GetTargetCoordinates(entity, ref behaviourContext, stateContext, ref generic);
            values = generic;
            return coordinates;
        }

        public abstract Vec2? GetTargetCoordinates(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref T values);
    }
    */
}
