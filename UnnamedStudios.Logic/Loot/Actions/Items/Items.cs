using UnnamedStudios.Logic.Loot.Context;
using System.Collections.Generic;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public class Items<TEntity, TWorld> : LootAction<TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        private readonly float _chance;
        private readonly LootValue[] _loot;

        public Items(float chance, LootValue[] loot)
        {
            _chance = chance;
            _loot = loot;
        }

        public override void GetLoot(ref TEntity entity, ref TWorld world, in LootContext context, List<LootValue> results)
        {
            if (_chance < world.Random01())
            {
                return;
            }

            results.Add(_loot.RandomOf(ref world));
        }
    }
}
