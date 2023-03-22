using System;
using System.Collections.Generic;
using System.Reflection;
using UnnamedStudios.Logic.Behaviour;
using UnnamedStudios.Logic.Behaviour.Builder;
using UnnamedStudios.Logic.Loot;
using UnnamedStudios.Logic.Loot.Builder;

namespace UnnamedStudios.Logic.Demo
{
    public static class HowToUse
    {
        // =================================================================================
        // =================================================================================

        // ============================
        // Building the logic libraries
        // ============================

        public static BehaviourLibrary<ushort, SampleEntity, SampleWorld> BehaviourLibrary { get; private set; }
        public static LootTableLibrary<ushort, SampleEntity, SampleWorld> LootTableLibrary { get; private set; }

        public static void BuildLibraries()
        {
            var assemblyContainingDefinitions = Assembly.GetExecutingAssembly();

            BehaviourLibrary = new BehaviourLibraryBuilder<ushort, SampleEntity, SampleWorld>()
                .AddAssembly(assemblyContainingDefinitions)
                .Build();

            LootTableLibrary = new LootTableLibraryBuilder<ushort, SampleEntity, SampleWorld>()
                .AddAssembly(assemblyContainingDefinitions)
                .Build();

            // built libraries
        }

        // =================================================================================
        // =================================================================================

        // ==========================
        // Retrieving and using logic
        // ==========================

        public class LogicRunner
        {
            private SampleEntity _entity;
            private readonly BehaviourRunner<ushort, SampleEntity, SampleWorld> _behaviour;
            private readonly LootTableRunner<ushort, SampleEntity, SampleWorld> _lootTable;

            //
            // loading logic
            //

            public LogicRunner(SampleEntity entity, ushort type)
            {
                _entity = entity;

                if (!BehaviourLibrary.TryGetBehaviour(type, out _behaviour))
                {
                    // no behaviour found for type
                }

                if (!LootTableLibrary.TryGetLootTable(type, out _lootTable))
                {
                    // no loot table found for type
                }
            }

            //
            // getting loot (on death, etc..)
            //

            public void GetLoot(SampleWorld world, in LootContext context, List<LootValue> results)
            {
                _lootTable?.GetLoot(ref _entity, ref world, in context, results);
            }

            //
            // run the behaviour every update
            //

            public void Update(ref BehaviourContext<SampleWorld> context)
            {
                _behaviour?.Update(ref _entity, ref context);
            }
        }
    }
}
