using UnnamedStudios.Logic.Loot;
using UnnamedStudios.Logic.Loot.Builder;
using UnnamedStudios.Logic.Loot.Context;

namespace UnnamedStudios.Logic.Demo
{
    public class SampleLootTables : LootTableDefinition<SampleEntity>
    {
        public override void Build(LootTableBuilder<SampleEntity> builder)
        {
            builder.Init(SampleTypes.EnemyWarrior,
                OneOf(0.5f, SampleTypes.HealthPotion, SampleTypes.ManaPotion) // 50% chance to drop health or mana potion, never both. (the chance is rolled once for the item group)
            );

            builder.Init(SampleTypes.EnemyArcher,
                If((in LootContext x) => x.DamagePercent > 0.5 || x.Index == 0, // if the damager did 50% of the damage OR they were the top damager (Index is the index of the damager within a list sorted by damage dealt)
                    Item(0.1f, SampleTypes.MysticalSword) // 10% chance to drop mystical sword
                ),
                Item(1, SampleTypes.IronSword) // 100% chance to drop iron sword
            );
        }
    }
}
