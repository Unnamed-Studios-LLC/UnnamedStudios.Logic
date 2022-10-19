using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class RepeatValues
    {
        public int Count;
        public long EveryValue;
        public object GroupValues;
    }

    internal class Repeat<TEntity> : BehaviourAction<TEntity, RepeatValues> where TEntity : ILogicEntity
    {
        private readonly EntityFunc<TEntity, long> _intervalFunc;
        private readonly int _count;
        private readonly Group<TEntity> _group;

        public Repeat(EntityFunc<TEntity, long> intervalFunc, int count, BehaviourAction<TEntity>[] actions)
        {
            _intervalFunc = intervalFunc ?? throw new System.ArgumentNullException(nameof(intervalFunc));
            _count = count;
            _group = new Group<TEntity>(actions);
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref RepeatValues values)
        {
            values = new RepeatValues
            {
                EveryValue = 0,
            };
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref RepeatValues values)
        {
            if (_count >= 0 &&
                values.Count > _count)
            {
                return;
            }

            if (Every.Interval(behaviourContext.TimeDelta, _intervalFunc(ref entity), ref values.EveryValue))
            {
                if (_count >= 0 &&
                    ++values.Count > _count)
                {
                    return;
                }

                values.GroupValues = null;
                _group.Start(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
            }
            
            if (values.GroupValues != null)
            {
                _group.Update(ref entity, ref behaviourContext, stateContext, ref values.GroupValues);
            }
        }
    }
}
