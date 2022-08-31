using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class RepeatValues
    {
        public int Count;
        public long EveryValue;
        public object GroupValues;
    }

    internal class Repeat : BehaviourAction<RepeatValues>
    {
        private readonly EntityFunc<long> _intervalFunc;
        private readonly int _count;
        private readonly Group _group;

        public Repeat(EntityFunc<long> intervalFunc, int count, BehaviourAction[] actions)
        {
            _intervalFunc = intervalFunc ?? throw new System.ArgumentNullException(nameof(intervalFunc));
            _count = count;
            _group = new Group(actions);
        }

        protected override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref RepeatValues values)
        {
            values = new RepeatValues
            {
                EveryValue = 0,
            };
        }

        protected override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref RepeatValues values)
        {
            if (_count >= 0 &&
                values.Count > _count)
            {
                return;
            }

            if (Every.Interval(behaviourContext.TimeDelta, _intervalFunc(entity), ref values.EveryValue))
            {
                if (_count >= 0 &&
                    ++values.Count > _count)
                {
                    return;
                }

                values.GroupValues = null;
                _group.Start(entity, behaviourContext, stateContext, ref values.GroupValues);
            }
            
            if (values.GroupValues != null)
            {
                _group.Update(entity, behaviourContext, stateContext, ref values.GroupValues);
            }
        }
    }
}
