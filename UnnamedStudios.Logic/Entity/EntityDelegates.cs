using UnnamedStudios.Logic.Entity;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic
{
    public delegate void EntityAction<TEntity>(ref TEntity entity) where TEntity : ILogicEntity;
    public delegate TResult EntityFunc<TEntity, out TResult>(ref TEntity entity) where TEntity : ILogicEntity;
    public delegate Vec2? TargetingFunc<TEntity>(ref TEntity entity, ILogicWorld<TEntity> world) where TEntity : ILogicEntity;
}