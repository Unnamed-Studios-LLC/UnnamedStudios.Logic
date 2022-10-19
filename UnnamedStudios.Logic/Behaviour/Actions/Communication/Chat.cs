using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Chat<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, string> _messageGetter;
        private readonly bool _world;

        public Chat(EntityFunc<TEntity, string> messageGetter, bool world)
        {
            _messageGetter = messageGetter ?? throw new ArgumentNullException(nameof(messageGetter));
            _world = world;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var message = _messageGetter(ref entity);
            if (_world)
            {
                entity.ChatWorld(message);
            }
            else
            {
                entity.Chat(message);
            }
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
