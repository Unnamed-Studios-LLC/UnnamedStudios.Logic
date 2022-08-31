using Zero.Game.Shared;

namespace UnnamedStudios.Logic
{
    public delegate void EntityAction(ILogicEntity entity);
    public delegate TResult EntityFunc<out TResult>(ILogicEntity entity);
    public delegate Vec2? TargetingFunc(ILogicEntity entity);
}
