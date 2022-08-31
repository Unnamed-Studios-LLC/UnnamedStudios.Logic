namespace UnnamedStudios.Logic.Loot.Context
{
    public struct LootContext
    {
        public LootContext(int index, int damage, int damageSum)
        {
            Index = index;
            Damage = damage;
            DamageSum = damageSum;
        }

        public int Index { get; }
        public int Damage { get; }
        public float DamagePercent => Damage / (float)DamageSum;
        public int DamageSum { get; }
    }
}
