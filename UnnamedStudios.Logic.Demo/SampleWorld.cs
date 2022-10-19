using System;
using UnnamedStudios.Logic.Entity;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Demo
{
    public class SampleWorld : ILogicWorld<SampleEntity>
    {
        //
        // implement your logic
        //

        public ref SampleEntity GetClosestPlayer(Vec2 coordinates, float scanRadius, out bool found) => throw new NotImplementedException();
        public ref SampleEntity GetClosestVisiblePlayer(Vec2 coordinates, float scanRadius, out bool found) => throw new NotImplementedException();
        public ref SampleEntity GetLeader(ref SampleEntity minion, out bool found) => throw new NotImplementedException();
        public ref SampleEntity GetMinion(ref SampleEntity leader, int index, out bool found) => throw new NotImplementedException();
        public ref SampleEntity Spawn(ushort type, Vec2 coordinates, bool isMinion, out bool success) => throw new NotImplementedException();
    }
}
