using UnnamedStudios.Logic.Abstract;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableLibrary<TEntity> where TEntity : ILogicEntity
    {
        private readonly LogicLibrary<LootTable<TEntity>> _library;

        internal LootTableLibrary(Dictionary<ushort, LootTable<TEntity>> lootTables)
        {
            _library = new LogicLibrary<LootTable<TEntity>>(lootTables);
        }

        public int Count => _library.Count;

        public bool Contains(ushort type)
        {
            return _library.Contains(type);
        }

        public bool TryGetLootTable(ushort type, out LootTableRunner<TEntity> runner)
        {
            if (_library.TryGetLogic(type, out var lootTable))
            {
                runner = new LootTableRunner<TEntity>(lootTable);
                return true;
            }

            runner = default;
            return false;
        }
    }
}
