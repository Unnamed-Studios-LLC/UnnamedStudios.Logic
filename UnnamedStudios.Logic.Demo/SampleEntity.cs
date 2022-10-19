using System;
using UnnamedStudios.Logic.Behaviour.Arguments;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Demo
{
    public class SampleEntity : ILogicEntity
    {
        //
        // implement your logic
        //

        public Vec2 Coordinates => throw new NotImplementedException();
        public int Health => throw new NotImplementedException();
        public float HealthPercentage => throw new NotImplementedException();
        public int LeaderCount => throw new NotImplementedException();
        public int MaxHealth => throw new NotImplementedException();
        public int MinionCount => throw new NotImplementedException();
        public string Name => throw new NotImplementedException();
        public ushort ReferenceType => throw new NotImplementedException();
        public Vec2 SpawnCoordinates => throw new NotImplementedException();
        public int StateId => throw new NotImplementedException();

        public void AddForce(byte magnitude) => throw new NotImplementedException();
        public void AddStatusEffect(uint type, uint duration) => throw new NotImplementedException();
        public void Attack(byte attackIndex, Vec2 targetCoordinates, ushort attackReference) => throw new NotImplementedException();
        public void Chat(string message) => throw new NotImplementedException();
        public void ChatWorld(string message) => throw new NotImplementedException();
        public ushort GetGroundType(Vec2 coordinates) => throw new NotImplementedException();
        public object GetValue(string key, object defaultValue) => throw new NotImplementedException();
        public bool HasStatusEffect(uint type) => throw new NotImplementedException();
        public bool HasTargetableWithin(float radius) => throw new NotImplementedException();
        public void Log(LogLevel level, string message) => throw new NotImplementedException();
        public void Log(LogLevel level, string format, params object[] args) => throw new NotImplementedException();
        public void MoveBy(Vec2 vector, MoveArgs args) => throw new NotImplementedException();
        public void MoveTo(Vec2 target, MoveArgs args) => throw new NotImplementedException();
        public float Random01() => throw new NotImplementedException();
        public T RandomOf<T>(params T[] group) => throw new NotImplementedException();
        public int RandomRange(int min, int max) => throw new NotImplementedException();
        public void RemoveStatusEffect(uint type) => throw new NotImplementedException();
        public void SetOtherIndex(int index) => throw new NotImplementedException();
        public void SetState(int stateId) => throw new NotImplementedException();
        public void SetTextureIndex(uint index) => throw new NotImplementedException();
        public void SetValue(string key, object value) => throw new NotImplementedException();
    }
}
