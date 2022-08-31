using UnnamedStudios.Logic.Abstract;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot
{
    public class LootTableLibrary
    {
        private readonly LogicLibrary<LootTable> _library;

        internal LootTableLibrary(Dictionary<ushort, LootTable> lootTables)
        {
            _library = new LogicLibrary<LootTable>(lootTables);
        }

        public int Count => _library.Count;

        public bool Contains(ushort type)
        {
            return _library.Contains(type);
        }

        public bool TryGetLootTable(ushort type, out LootTableRunner runner)
        {
            if (_library.TryGetLogic(type, out var lootTable))
            {
                runner = new LootTableRunner(lootTable);
                return true;
            }

            runner = default;
            return false;
        }
    }
}
