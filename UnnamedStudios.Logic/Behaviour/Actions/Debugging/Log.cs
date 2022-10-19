using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class Log<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly LogLevel _logLevel;
        private readonly string _message;
        private readonly EntityFunc<TEntity, object[]> _argsGetter;

        public Log(LogLevel logLevel, string message, EntityFunc<TEntity, object[]> argsGetter)
        {
            _logLevel = logLevel;
            _message = message ?? throw new System.ArgumentNullException(nameof(message));
            _argsGetter = argsGetter ?? throw new System.ArgumentNullException(nameof(argsGetter));
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            entity.Log(_logLevel, _message, _argsGetter(ref entity));
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
