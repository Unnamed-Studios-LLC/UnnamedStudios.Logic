namespace UnnamedStudios.Logic
{
    public delegate void EntityAction<TEntity>(ref TEntity entity);
    public delegate void EntityWorldAction<TEntity, TWorld>(ref TEntity entity, ref TWorld world);
    public delegate TResult EntityWorldFunc<TEntity, TWorld, out TResult>(ref TEntity entity, ref TWorld world);
}