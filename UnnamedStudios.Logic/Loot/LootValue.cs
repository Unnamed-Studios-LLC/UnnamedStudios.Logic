namespace UnnamedStudios.Logic.Loot
{
    public struct LootValue
    {
        public LootValue(ushort type, long count)
        {
            Type = type;
            Count = count;
        }

        public ushort Type { get; private set; }
        public long Count { get; private set; }
    }
}
