using System;

namespace UnnamedStudios.Logic.Behaviour
{
    public class BehaviourRunner
    {
        private object _values;
        private readonly Behaviour _behaviour;
        private readonly BehaviourContext _context = new BehaviourContext();

        internal BehaviourRunner(Behaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public int? StateId => _behaviour.GetStateId(ref _values);

        public void Run(ILogicEntity entity, long timeTotal, long timeDelta)
        {
            _context.TimeTotal = timeTotal;
            _context.TimeDelta = timeDelta;

            _behaviour.Update(entity, _context, ref _values);
        }

        public void SetState(int stateId)
        {
            _behaviour.SetState(stateId, ref _values);
        }
    }
}
