using UnnamedStudios.Logic.Entity;

namespace UnnamedStudios.Logic.Behaviour
{
    public struct BehaviourContext<TEntity> where TEntity : ILogicEntity
    {
        public BehaviourContext(long timeTotal, long timeDelta, ILogicWorld<TEntity> world)
        {
            TimeTotal = timeTotal;
            TimeDelta = timeDelta;
            World = world;
        }

        public long TimeTotal { get; }
        public long TimeDelta { get; }
        public ILogicWorld<TEntity> World { get; }

        public float TimeDeltaF => TimeDelta * 0.001f;
    }
}
