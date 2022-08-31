using System;
using System.Collections.Generic;
using System.Reflection;
using UnnamedStudios.Logic.Behaviour;
using UnnamedStudios.Logic.Behaviour.Builder;
using UnnamedStudios.Logic.Loot;
using UnnamedStudios.Logic.Loot.Builder;
using UnnamedStudios.Logic.Loot.Context;

namespace UnnamedStudios.Logic.Demo
{
    public static class HowToUse
    {
        // =================================================================================
        // =================================================================================

        // ============================
        // Building the logic libraries
        // ============================

        public static BehaviourLibrary BehaviourLibrary { get; private set; }
        public static LootTableLibrary LootTableLibrary { get; private set; }

        public static void BuildLibraries()
        {
            var assemblyContainingDefinitions = Assembly.GetExecutingAssembly();

            BehaviourLibrary = new BehaviourLibraryBuilder()
                .AddAssembly(assemblyContainingDefinitions)
                .Build();

            LootTableLibrary = new LootTableLibraryBuilder()
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
            private readonly ILogicEntity _entity;
            private readonly BehaviourRunner _behaviour;
            private readonly LootTableRunner _lootTable;

            //
            // loading logic
            //

            public LogicRunner(ILogicEntity entity, ushort type)
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

            public IEnumerable<LootValue> GetLoot(LootContext context)
            {
                return _lootTable?.GetLoot(_entity, context) ?? Array.Empty<LootValue>();
            }

            //
            // run the behaviour every update
            //

            public void Update(long timeTotalMs, long timeDeltaMs)
            {
                _behaviour?.Run(_entity, timeTotalMs, timeDeltaMs);
            }
        }
    }
}
