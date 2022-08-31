using UnnamedStudios.Logic.Behaviour.Actions;
using UnnamedStudios.Logic.Behaviour.Arguments;
using UnnamedStudios.Logic.Behaviour.Builder;
using System;
using System.Text;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour
{
    public abstract class BehaviourDefinition
    {
        protected const int MillisecondsPerSecond = 1_000;
        protected const int MinutesPerHour = 60;
        protected const int SecondsPerMinute = 60;

        protected static MoveArgs DefaultMoveArgs => new MoveArgs(true);

        public abstract void Build(BehaviourBuilder builder);

        protected static BehaviourAction AddStatusEffect(uint type, int duration) => AddStatusEffect(type, x => duration);
        protected static BehaviourAction AddStatusEffect(uint type, EntityFunc<int> durationGetter) => new AddStatusEffect(type, durationGetter);
        protected static BehaviourAction Attack(byte attackIndex, TargetingFunc targetingFunc) => new Attack(attackIndex, targetingFunc);

        protected static BehaviourAction Chat(string message) => Chat(x => message);
        protected static BehaviourAction Chat(EntityFunc<string> messageGetter) => new Chat(messageGetter, false);
        protected static BehaviourAction ChatWorld(string message) => ChatWorld(x => message);
        protected static BehaviourAction ChatWorld(EntityFunc<string> messageGetter) => new Chat(messageGetter, true);

        protected static BehaviourAction Delay(long delay, params BehaviourAction[] actions) => Delay(x => delay, actions);
        protected static BehaviourAction Delay(EntityFunc<long> delayGetter, params BehaviourAction[] actions) => new Delay(delayGetter, actions);

        protected static BehaviourAction Execute(EntityAction entityAction) => new Execute(entityAction);

        protected static BehaviourAction Force(byte magnitude) => new Force(magnitude);

        protected static int Forever() => Hours(9_999);

        protected static BehaviourAction Group(params BehaviourAction[] actions) => new Group(actions);

        protected static int Hours(int hours) => hours * Minutes(1) * MinutesPerHour;
        protected static uint Hours(uint hours) => hours * Minutes(1U) * MinutesPerHour;
        protected static long Hours(long hours) => hours * Minutes(1) * MinutesPerHour;
        protected static long Hours(float hours) => (long)(hours * Minutes(1) * MinutesPerHour);

        protected static ConditionalBehaviourAction If(EntityFunc<bool> condition, params BehaviourAction[] actions) => new Conditional(condition, actions);

        protected static BehaviourAction Log(LogLevel logLevel, string message, EntityFunc<object[]> argsGetter) => new Log(logLevel, message, argsGetter);
        protected static BehaviourAction Log(LogLevel logLevel, string message, params object[] args) => Log(logLevel, message, x => args);
        protected static BehaviourAction LogCritical(string message, EntityFunc<object[]> argsGetter) => Log(LogLevel.Critical, message, argsGetter);
        protected static BehaviourAction LogCritical(string message, params object[] args) => Log(LogLevel.Critical, message, args);
        protected static BehaviourAction LogDebug(string message, EntityFunc<object[]> argsGetter) => Log(LogLevel.Debug, message, argsGetter);
        protected static BehaviourAction LogDebug(string message, params object[] args) => Log(LogLevel.Debug, message, args);
        protected static BehaviourAction LogError(string message, EntityFunc<object[]> argsGetter) => Log(LogLevel.Error, message, argsGetter);
        protected static BehaviourAction LogError(string message, params object[] args) => Log(LogLevel.Error, message, args);
        protected static BehaviourAction LogInfo(string message, EntityFunc<object[]> argsGetter) => Log(LogLevel.Information, message, argsGetter);
        protected static BehaviourAction LogInfo(string message, params object[] args) => Log(LogLevel.Information, message, args);
        protected static BehaviourAction LogTrace(string message, EntityFunc<object[]> argsGetter) => Log(LogLevel.Trace, message, argsGetter);
        protected static BehaviourAction LogTrace(string message, params object[] args) => Log(LogLevel.Trace, message, args);
        protected static BehaviourAction LogWarning(string message, EntityFunc<object[]> argsGetter) => Log(LogLevel.Warning, message, argsGetter);
        protected static BehaviourAction LogWarning(string message, params object[] args) => Log(LogLevel.Warning, message, args);

        protected static int Minutes(int minutes) => minutes * Seconds(1) * SecondsPerMinute;
        protected static uint Minutes(uint minutes) => minutes * Seconds(1U) * SecondsPerMinute;
        protected static long Minutes(long minutes) => minutes * Seconds(1) * SecondsPerMinute;
        protected static long Minutes(float minutes) => (long)(minutes * Seconds(1) * SecondsPerMinute);

        protected static MoveArgs MoveArgs(bool checkCollision) => new MoveArgs(checkCollision);

        protected static BehaviourAction Move(Vec2 vector) => Move(vector, DefaultMoveArgs);
        protected static BehaviourAction Move(Vec2 vector, MoveArgs args) => Move(x => vector, args);
        protected static BehaviourAction Move(EntityFunc<Vec2> vectorGetter) => Move(vectorGetter, DefaultMoveArgs);
        protected static BehaviourAction Move(EntityFunc<Vec2> vectorGetter, MoveArgs args) => new Move(vectorGetter, args);
        protected static BehaviourAction MoveAngle(float degrees, float speed) => Move(Angle.Vec2(degrees * Angle.Deg2Rad) * speed);
        protected static BehaviourAction MoveOrbit(float distance, float speed, TargetingFunc targetingFunc) => MoveOrbit(x => distance, x => speed, targetingFunc);
        protected static BehaviourAction MoveOrbit(float distance, float speed, MoveArgs args, TargetingFunc targetingFunc) => MoveOrbit(x => distance, x => speed, args, targetingFunc);
        protected static BehaviourAction MoveOrbit(float distance, EntityFunc<float> speedGetter, TargetingFunc targetingFunc) => MoveOrbit(x => distance, speedGetter, targetingFunc);
        protected static BehaviourAction MoveOrbit(float distance, EntityFunc<float> speedGetter, MoveArgs args, TargetingFunc targetingFunc) => MoveOrbit(x => distance, speedGetter, args, targetingFunc);
        protected static BehaviourAction MoveOrbit(EntityFunc<float> distanceGetter, float speed, TargetingFunc targetingFunc) => MoveOrbit(distanceGetter, x => speed, targetingFunc);
        protected static BehaviourAction MoveOrbit(EntityFunc<float> distanceGetter, float speed, MoveArgs args, TargetingFunc targetingFunc) => MoveOrbit(distanceGetter, x => speed, args, targetingFunc);
        protected static BehaviourAction MoveOrbit(EntityFunc<float> distanceGetter, EntityFunc<float> speedGetter, TargetingFunc targetingFunc) => MoveOrbit(distanceGetter, speedGetter, DefaultMoveArgs, targetingFunc);
        protected static BehaviourAction MoveOrbit(EntityFunc<float> distanceGetter, EntityFunc<float> speedGetter, MoveArgs args, TargetingFunc targetingFunc) => new MoveOrbit(distanceGetter, speedGetter, args, targetingFunc);
        protected static BehaviourAction MoveRandomAngle(float speed) => MoveRandomAngle(speed, DefaultMoveArgs);
        protected static BehaviourAction MoveRandomAngle(float speed, MoveArgs args) => Move(x => Angle.Vec2(x.Random01() * Angle.PI2) * speed, args);
        protected static BehaviourAction MoveToConstantSpeed(float speed, TargetingFunc targetingFunc) => MoveToConstantSpeed(speed, 0, targetingFunc);
        protected static BehaviourAction MoveToConstantSpeed(float speed, float minRange, TargetingFunc targetingFunc) => MoveToConstantSpeed(speed, minRange, DefaultMoveArgs, targetingFunc);
        protected static BehaviourAction MoveToConstantSpeed(float speed, float minRange, MoveArgs args, TargetingFunc targetingFunc) => new MoveToConstantSpeed(speed, minRange, args, targetingFunc);
        protected static BehaviourAction MoveToConstantTime(long time, TargetingFunc targetingFunc) => MoveToConstantTime(time, 0, targetingFunc);
        protected static BehaviourAction MoveToConstantTime(long time, float minRange, TargetingFunc targetingFunc) => MoveToConstantTime(time, minRange, DefaultMoveArgs, targetingFunc);
        protected static BehaviourAction MoveToConstantTime(long time, float minRange, MoveArgs args, TargetingFunc targetingFunc) => new MoveToConstantTime(time, minRange, args, targetingFunc);

        protected static BehaviourAction Once(params BehaviourAction[] actions) => new Once(actions);

        protected static EntityFunc<T> RandomOf<T>(params T[] values) => x => x.RandomOf(values);
        protected static EntityFunc<float> RandomRange(float min, float max) => x => min + (max - min) * x.Random01();
        protected static EntityFunc<int> RandomRange(int min, int max) => x => x.RandomRange(min, max);
        protected static EntityFunc<long> RandomRange(long min, long max) => x => x.RandomRange((int)min, (int)max);

        protected static BehaviourAction RemoveOtherIndex() => new SetOther(-1);
        protected static BehaviourAction RemoveStatusEffect(uint type) => new RemoveStatusEffect(type);

        protected static BehaviourAction Repeat(long interval, params BehaviourAction[] actions) => Repeat(interval, -1, actions);
        protected static BehaviourAction Repeat(long interval, int count, params BehaviourAction[] actions) => Repeat(x => interval, count, actions);
        protected static BehaviourAction Repeat(EntityFunc<long> intervalFunc, params BehaviourAction[] actions) => Repeat(intervalFunc, -1, actions);
        protected static BehaviourAction Repeat(EntityFunc<long> intervalFunc, int count, params BehaviourAction[] actions) => new Repeat(intervalFunc, count, actions);

        protected static int Seconds(int seconds) => seconds * MillisecondsPerSecond;
        protected static uint Seconds(uint seconds) => seconds * MillisecondsPerSecond;
        protected static long Seconds(long seconds) => seconds * MillisecondsPerSecond;
        protected static long Seconds(float seconds) => (long)(seconds * MillisecondsPerSecond);

        protected static BehaviourAction SetOtherIndex(int otherIndex) => new SetOther(otherIndex);

        protected static BehaviourAction SetMinionState(string name) => SetMinionState(name, x => true);
        protected static BehaviourAction SetMinionState(string name, EntityFunc<bool> filter) => new SetMinionState(name, filter);
        protected static BehaviourAction SetState(string name) => SetState(name, 1);
        protected static BehaviourAction SetState(string name, int level) => new SetState(name, level);
        protected static BehaviourAction SetState(int stateId) => SetState(stateId, 1);
        protected static BehaviourAction SetState(int stateId, int level) => SetState(x => stateId, level);
        protected static BehaviourAction SetState(EntityFunc<int> stateIdGetter) => SetState(stateIdGetter, 1);
        protected static BehaviourAction SetState(EntityFunc<int> stateIdGetter, int level) => new SetState(stateIdGetter, level);

        protected static BehaviourAction SetTextureIndex(uint textureIndex) => new SetTexture(textureIndex);

        protected static BehaviourAction Spawn(ushort type, TargetingFunc targetingFunc, bool isMinion = true) => Spawn(x => type, targetingFunc, isMinion);
        protected static BehaviourAction Spawn(EntityFunc<ushort> typeGetter, TargetingFunc targetingFunc, bool isMinion = true) => new Spawn(typeGetter, targetingFunc, isMinion);

        protected static BehaviourAction State(string name, params BehaviourAction[] actions) => State(name, string.Empty, actions);
        protected static BehaviourAction State(string name, string defaultSubState, params BehaviourAction[] actions) => new State(name, defaultSubState, actions);

        protected static BehaviourAction StayOnGround(float speed, params ushort[] groundTypes) => StayOnGround(speed, 0, groundTypes);
        protected static BehaviourAction StayOnGround(float speed, MoveArgs args, params ushort[] groundTypes) => StayOnGround(speed, 0, args, groundTypes);
        protected static BehaviourAction StayOnGround(float speed, float minRange, params ushort[] groundTypes) => StayOnGround(speed, minRange, DefaultMoveArgs, groundTypes);
        protected static BehaviourAction StayOnGround(float speed, float minRange, MoveArgs args, params ushort[] groundTypes) => new StayOnGround(speed, minRange, args, groundTypes);

        protected static BehaviourAction SyncMinionStates() => SyncMinionStates(x => true);
        protected static BehaviourAction SyncMinionStates(EntityFunc<bool> filter) => new SyncMinionStates(filter);
        protected static BehaviourAction SyncToLeaderState(int level = 1) => new SyncToLeaderState(level);

        protected static TargetingFunc TargetAngle(float angleDegrees, float distance) => TargetOffset(x => Angle.Vec2(angleDegrees * Angle.Deg2Rad) * distance);
        protected static TargetingFunc TargetAngle(float angleDegrees, EntityFunc<float> distanceGetter) => TargetOffset(x => Angle.Vec2(angleDegrees * Angle.Deg2Rad) * distanceGetter(x));
        protected static TargetingFunc TargetAngle(EntityFunc<float> angleDegreesGetter, EntityFunc<float> distanceGetter) => TargetOffset(x => Angle.Vec2(angleDegreesGetter(x) * Angle.Deg2Rad) * distanceGetter(x));
        protected static TargetingFunc TargetLeader() => x => x.Leader?.Coordinates;
        protected static TargetingFunc TargetOffset(EntityFunc<Vec2> offsetGetter) => x => x.Coordinates + offsetGetter(x);
        protected static TargetingFunc TargetPlayerClosest(float scanRadius) => x => x.GetClosestPlayer(scanRadius)?.Coordinates;
        protected static TargetingFunc TargetPlayerVisibleClosest(float scanRadius) => x => x.GetClosestVisiblePlayer(scanRadius)?.Coordinates;
        protected static TargetingFunc TargetSelf() => x => x.Coordinates;
        protected static TargetingFunc TargetSpawn() => x => x.SpawnCoordinates;

        protected static Vec2 Vec2(float x, float y) => new Vec2(x, y);
        protected static Vec2 X(float x) => Vec2(x, 0);
        protected static Vec2 Y(float y) => Vec2(0, y);

        internal BehaviourBuilder Build()
        {
            var builder = new BehaviourBuilder(GetType());
            Build(builder);
            return builder;
        }
    }
}
