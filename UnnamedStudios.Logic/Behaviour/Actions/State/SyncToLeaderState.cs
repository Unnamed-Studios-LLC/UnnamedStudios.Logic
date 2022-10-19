using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class SyncToLeaderState<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly int _parentLevel;

        public SyncToLeaderState(int parentLevel)
        {
            _parentLevel = parentLevel;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            var leaderId = entity.GetLeaderStateId();
            if (leaderId == null)
            {
                return;
            }

            int level = 0;
            do
            {
                if (level == _parentLevel)
                {
                    stateContext.Current = leaderId.Value;
                    return;
                }
                stateContext = stateContext.Parent;
                level++;
            }
            while (stateContext != null && stateContext != Behaviour<TEntity>.Top);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
