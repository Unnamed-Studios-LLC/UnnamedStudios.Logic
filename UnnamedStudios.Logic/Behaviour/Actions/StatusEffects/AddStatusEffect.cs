using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class AddStatusEffect<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly uint _type;
        private readonly EntityFunc<TEntity, int> _durationGetter;

        public AddStatusEffect(uint type, EntityFunc<TEntity, int> durationGetter)
        {
            _type = type;
            _durationGetter = durationGetter ?? throw new ArgumentNullException(nameof(durationGetter));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            entity.AddStatusEffect(_type, (uint)_durationGetter(ref entity));
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
