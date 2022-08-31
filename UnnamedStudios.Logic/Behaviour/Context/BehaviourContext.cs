namespace UnnamedStudios.Logic.Behaviour
{
    public class BehaviourContext
    {
        public long TimeTotal { get; set; }
        public long TimeDelta { get; set; }

        public float TimeDeltaF => TimeDelta * 0.001f;
    }
}
