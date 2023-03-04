using UnnamedStudios.Logic.Abstract;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableLibrary<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly LogicLibrary<TKey, LootTable<TKey, TEntity, TWorld>> _library;

        internal LootTableLibrary(Dictionary<TKey, LootTable<TKey, TEntity, TWorld>> lootTables)
        {
            _library = new LogicLibrary<TKey, LootTable<TKey, TEntity, TWorld>>(lootTables);
        }

        public int Count => _library.Count;

        public bool Contains(TKey key)
        {
            return _library.Contains(key);
        }

        public bool TryGetLootTable(TKey key, out LootTableRunner<TKey, TEntity, TWorld> runner)
        {
            if (_library.TryGetLogic(key, out var lootTable))
            {
                runner = new LootTableRunner<TKey, TEntity, TWorld>(lootTable);
                return true;
            }

            runner = default;
            return false;
        }
    }
}
