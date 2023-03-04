namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class ConditionalLootAction<TEntity, TWorld> : LootAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        public abstract LootAction<TEntity, TWorld> Else(params LootAction<TEntity, TWorld>[] actions);
        public abstract ConditionalLootAction<TEntity, TWorld> ElseIf(ConditionalLootDelegate condition, params LootAction<TEntity, TWorld>[] actions);
    }
}
