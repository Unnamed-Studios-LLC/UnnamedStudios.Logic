using System;
using System.Text;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Chat : BehaviourAction
    {
        private readonly EntityFunc<string> _messageGetter;
        private readonly bool _world;

        public Chat(EntityFunc<string> messageGetter, bool world)
        {
            _messageGetter = messageGetter ?? throw new ArgumentNullException(nameof(messageGetter));
            _world = world;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            var message = _messageGetter(entity);
            if (_world)
            {
                entity.ChatWorld(message);
            }
            else
            {
                entity.Chat(message);
            }
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
