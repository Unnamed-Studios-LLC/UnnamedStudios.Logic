using System.Collections.Concurrent;

namespace UnnamedStudios.Logic.Behaviour
{
    public static class StateId
    {
        private readonly static ConcurrentDictionary<string, int> s_nameToIdMap = new ConcurrentDictionary<string, int>()
        {
            [string.Empty] = 0
        };
        private static int s_nextId = 1;

        public static int Get(string name)
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
    }
}
