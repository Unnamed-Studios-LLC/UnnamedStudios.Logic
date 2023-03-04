namespace UnnamedStudios.Logic.Behaviour
{
    public struct BehaviourContext<TWorld>
    {
        public long TimeDelta;
        public long TimeTotal;
        public TWorld World;

        public BehaviourContext(long timeTotal, long timeDelta, TWorld world)
        {
            TimeTotal = timeTotal;
            TimeDelta = timeDelta;
            World = world;
        }

        public float TimeDeltaF => TimeDelta * 0.001f;
        public float TimeTotalF => TimeTotal * 0.001f;
    }
}
