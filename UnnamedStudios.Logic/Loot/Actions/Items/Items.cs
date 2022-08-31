using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public class Items : LootAction
    {
        private readonly float _chance;
        private readonly LootValue[] _loot;

        public Items(float chance, LootValue[] loot)
        {
            _chance = chance;
            _loot = loot;
        }

        public override IEnumerable<LootValue> GetLoot(ILogicEntity entity, LootContext context)
        {
            if (_chance < entity.Random01())
            {
                yield break;
            }

            yield return _loot[entity.RandomRange(0, _loot.Length)];
        }
    }
}
