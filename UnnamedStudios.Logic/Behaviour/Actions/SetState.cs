using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal sealed class SetState<TEntity, TWorld> : BehaviourAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly EntityWorldFunc<TEntity, TWorld, int> _stateIdGetter;
        private readonly int _parentLevel;

        public SetState(string name, int parentLevel)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Equals(string.Empty, StringComparison.Ordinal))
            {
                throw new ArgumentException("State name cannot be empty", nameof(name));
            }

            var stateId = StateId.Get(name);
            _stateIdGetter = (ref TEntity x, ref TWorld y) => stateId;
            _parentLevel = parentLevel;
        }

        public SetState(EntityWorldFunc<TEntity, TWorld, int> stateIdGetter, int parentLevel)
        {
            _stateIdGetter = stateIdGetter;
            _parentLevel = parentLevel;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {
            var stateId = _stateIdGetter(ref entity, ref behaviourContext.World);
            stateContext.SetState(stateId, _parentLevel);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
