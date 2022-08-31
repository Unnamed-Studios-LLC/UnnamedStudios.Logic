using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SyncToLeaderState : BehaviourAction
    {
        private readonly int _parentLevel;

        public SyncToLeaderState(int parentLevel)
        {
            _parentLevel = parentLevel;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            var leader = entity.Leader;
            if (leader == null)
            {
                return;
            }

            int level = 0;
            do
            {
                if (level == _parentLevel)
                {
                    stateContext.Current = leader.StateId;
                    return;
                }
                stateContext = stateContext.Parent;
                level++;
            }
            while (stateContext != null && stateContext != Behaviour.Top);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
