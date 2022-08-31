using System.Collections.Concurrent;

namespace UnnamedStudios.Logic.Behaviour
{
    public class StateContext
    {
        private readonly static ConcurrentDictionary<string, int> s_nameToIdMap = new ConcurrentDictionary<string, int>()
        {
            [string.Empty] = 0
        };
        private static int s_nextId = 1;

        public StateContext(int current, StateContext parent)
        {
            Current = current;
            Parent = parent;
        }

        public int Current { get; set; }
        public StateContext Parent { get; }

        public static int RegisterStateName(string name)
        {
            int id;
            while (!s_nameToIdMap.TryGetValue(name, out id))
            {
                lock (s_nameToIdMap)
                {
                    id = s_nextId++;
                }

                if (s_nameToIdMap.TryAdd(name, id))
                {
                    break;
                }
            }

            return id;
        }

        public bool InState(int stateId)
        {
            if (Current == 0)
            {
                Current = stateId;
                return true;
            }
            return Current == stateId;
        }
    }
}
