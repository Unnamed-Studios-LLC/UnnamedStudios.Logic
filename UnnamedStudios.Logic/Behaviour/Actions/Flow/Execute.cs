using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Execute<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly EntityAction<TEntity> _entityAction;

        public Execute(EntityAction<TEntity> entityAction)
        {
            _entityAction = entityAction ?? throw new ArgumentNullException(nameof(entityAction));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            _entityAction(ref entity);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
