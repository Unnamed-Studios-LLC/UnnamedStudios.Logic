namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class ConditionalLootAction<TEntity> : LootAction<TEntity> where TEntity : ILogicEntity
    {
        public abstract LootAction<TEntity> Else(LootAction<TEntity>[] actions);
        public abstract ConditionalLootAction<TEntity> ElseIf(ConditionalLootDelegate condition, LootAction<TEntity>[] actions);
    }
}
