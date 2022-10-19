using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public class Items<TEntity> : LootAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly float _chance;
        private readonly LootValue[] _loot;

        public Items(float chance, LootValue[] loot)
        {
            _chance = chance;
            _loot = loot;
        }

        public override void GetLoot(ref TEntity entity, in LootContext context, List<LootValue> results)
        {
            if (_chance < entity.Random01())
            {
                return;
            }

            results.Add(_loot[entity.RandomRange(0, _loot.Length)]);
        }
    }
}
