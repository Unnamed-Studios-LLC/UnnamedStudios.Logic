using UnnamedStudios.Logic.Loot.Context;
using System;

namespace UnnamedStudios.Logic.Loot.Actions
{
    public abstract class ConditionalLootAction : LootAction
    {
        public abstract LootAction Else(LootAction[] actions);
        public abstract ConditionalLootAction ElseIf(Func<LootContext, bool> condition, LootAction[] actions);
    }
}
