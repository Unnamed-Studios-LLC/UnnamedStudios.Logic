using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Execute<TEntity, TWorld> : BehaviourAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly EntityWorldAction<TEntity, TWorld> _entityAction;

        public Execute(EntityWorldAction<TEntity, TWorld> entityAction)
        {
            _entityAction = entityAction ?? throw new ArgumentNullException(nameof(entityAction));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {
            _entityAction(ref entity, ref behaviourContext.World);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
