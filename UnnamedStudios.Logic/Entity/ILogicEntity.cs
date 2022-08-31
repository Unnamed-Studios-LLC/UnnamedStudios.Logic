﻿using UnnamedStudios.Logic.Behaviour.Arguments;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic
{
    public interface ILogicEntity
    {
        Vec2 Coordinates { get; }
        int Health { get; }
        float HealthPercentage { get; }
        ILogicEntity Leader { get; }
        int LeaderCount { get; }
        int MaxHealth { get; }
        int MinionCount { get; }
        string Name { get; }
        ushort ReferenceType { get; }
        Vec2 SpawnCoordinates { get; }
        int StateId { get; }

        void AddForce(byte magnitude);
        void AddStatusEffect(uint type, uint duration);
        void Attack(byte attackIndex, Vec2 targetCoordinates, ushort attackReference);

        void Chat(string message);
        void ChatWorld(string message);

        ILogicEntity GetClosestPlayer(float scanRadius);
        ILogicEntity GetClosestVisiblePlayer(float scanRadius);

        ushort GetGroundType(Vec2 coordinates);
        ILogicEntity GetMinion(int index);

        object GetValue(string key, object defaultValue);

        bool HasStatusEffect(uint type);

        void Log(LogLevel level, string message);
        void Log(LogLevel level, string format, params object[] args);

        void MoveBy(Vec2 vector, MoveArgs args);
        void MoveTo(Vec2 target, MoveArgs args);

        float Random01();
        T RandomOf<T>(params T[] group);
        int RandomRange(int min, int max);
        void RemoveStatusEffect(uint type);

        void SetOtherIndex(int index);
        void SetState(int stateId);
        void SetTextureIndex(uint index);

        void SetValue(string key, object value);

        ILogicEntity Spawn(ushort type, Vec2 coordinates, bool isMinion);
    }
}
