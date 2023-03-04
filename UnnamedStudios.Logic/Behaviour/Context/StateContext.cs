using System.Collections.Concurrent;

namespace UnnamedStudios.Logic.Behaviour
{
    public class StateContext
    {
        public readonly static StateContext Top = new StateContext(0, null);

        public StateContext(int current, StateContext parent)
        {
            Current = current;
            Parent = parent;
        }

        public int Current { get; set; }
        public StateContext Parent { get; }

        public bool InState(int stateId)
        {
            if (Current == 0)
            {
                Current = stateId;
                return true;
            }
            return Current == stateId;
        }

        public void SetState(int stateId, int parentLevel)
        {
            var stateContext = this;
            int level = 0;
            do
            {
                if (level == parentLevel)
                {
                    stateContext.Current = stateId;
                    return;
                }
                stateContext = stateContext.Parent;
                level++;
            }
            while (stateContext != null && stateContext != Top);
        }
    }
}
