using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Log : BehaviourAction
    {
        private readonly LogLevel _logLevel;
        private readonly string _message;
        private readonly EntityFunc<object[]> _argsGetter;

        public Log(LogLevel logLevel, string message, EntityFunc<object[]> argsGetter)
        {
            _logLevel = logLevel;
            _message = message ?? throw new System.ArgumentNullException(nameof(message));
            _argsGetter = argsGetter ?? throw new System.ArgumentNullException(nameof(argsGetter));
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            entity.Log(_logLevel, _message, _argsGetter(entity));
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
