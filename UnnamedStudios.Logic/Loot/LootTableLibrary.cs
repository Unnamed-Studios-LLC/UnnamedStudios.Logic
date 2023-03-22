using UnnamedStudios.Logic.Abstract;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableLibrary<TKey, TEntity, TWorld, TContext>
        where TWorld : ILogicWorld
    {
        private readonly LogicLibrary<TKey, LootTable<TKey, TEntity, TWorld, TContext>> _library;

        internal LootTableLibrary(Dictionary<TKey, LootTable<TKey, TEntity, TWorld, TContext>> lootTables)
        {
            _library = new LogicLibrary<TKey, LootTable<TKey, TEntity, TWorld, TContext>>(lootTables);
        }

        public int Count => _library.Count;

        public bool Contains(TKey key)
        {
            return _library.Contains(key);
        }

        public bool TryGetLootTable(TKey key, out LootTableRunner<TKey, TEntity, TWorld, TContext> runner)
        {
            if (_library.TryGetLogic(key, out var lootTable))
            {
                runner = new LootTableRunner<TKey, TEntity, TWorld, TContext>(lootTable);
                return true;
            }

            runner = default;
            return false;
        }
    }
}
