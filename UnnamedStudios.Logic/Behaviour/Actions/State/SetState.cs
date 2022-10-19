using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SetState<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, int> _stateIdGetter;
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

            var stateId = StateContext.RegisterStateName(name);
            _stateIdGetter = (ref TEntity x) => stateId;
            _parentLevel = parentLevel;
        }

        public SetState(EntityFunc<TEntity, int> stateIdGetter, int parentLevel)
        {
            _stateIdGetter = stateIdGetter;
            _parentLevel = parentLevel;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            int level = 0;
            do
            {
                if (level == _parentLevel)
                {
                    stateContext.Current = _stateIdGetter(ref entity);
                    return;
                }
                stateContext = stateContext.Parent;
                level++;
            }
            while (stateContext != null && stateContext != Behaviour<TEntity>.Top);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
