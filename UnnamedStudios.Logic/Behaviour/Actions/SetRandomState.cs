using System;
using System.Linq;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal sealed class SetRandomState<TEntity, TWorld> : BehaviourAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly EntityWorldFunc<TEntity, TWorld, int[]> _stateIdsGetter;
        private readonly int _parentLevel;

        public SetRandomState(string[] names, int parentLevel)
        {
            if (names is null)
            {
                throw new ArgumentNullException(nameof(names));
            }

            if (names.Length == 0)
            {
                throw new ArgumentException("States array cannot be empty", nameof(names));
            }

            foreach (var name in names)
            {
                if (name.Equals(string.Empty, StringComparison.Ordinal))
                {
                    throw new ArgumentException("State name cannot be empty", nameof(names));
                }
            }

            var stateIds = names.Select(StateId.Get).ToArray();
            _stateIdsGetter = (ref TEntity x, ref TWorld y) => stateIds;
            _parentLevel = parentLevel;
        }

        public SetRandomState(EntityWorldFunc<TEntity, TWorld, int[]> stateIdGetter, int parentLevel)
        {
            _stateIdsGetter = stateIdGetter;
            _parentLevel = parentLevel;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {
            var stateIds = _stateIdsGetter(ref entity, ref behaviourContext.World);
            if (stateIds == null || stateIds.Length == 0) return;
            var stateId = stateIds.RandomOf(ref behaviourContext.World);
            stateContext.SetState(stateId, _parentLevel);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
