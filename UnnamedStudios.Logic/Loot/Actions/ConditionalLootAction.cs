namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class ConditionalLootAction<TEntity, TWorld, TContext> : LootAction<TEntity, TWorld, TContext>
        where TWorld : ILogicWorld
    {
        public abstract LootAction<TEntity, TWorld, TContext> Else(params LootAction<TEntity, TWorld, TContext>[] actions);
        public abstract ConditionalLootAction<TEntity, TWorld, TContext> ElseIf(ConditionalLootDelegate<TContext> condition, params LootAction<TEntity, TWorld, TContext>[] actions);
    }
}
