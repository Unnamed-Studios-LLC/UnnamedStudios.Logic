using UnnamedStudios.Logic.Behaviour.Actions;
using UnnamedStudios.Logic.Behaviour.Builder;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour
{
    public abstract class BehaviourDefinition<TKey, TEntity, TWorld>
        where TWorld : ILogicWorld
    {
        public const int MillisecondsPerSecond = 1_000;
        public const int MinutesPerHour = 60;
        public const int SecondsPerMinute = 60;

        public abstract void Build(BehaviourBuilder<TKey, TEntity, TWorld> builder);

        /*
        public static BehaviourAction<TEntity, TWorld> AddStatusEffect(uint type, int duration) => AddStatusEffect(type, (ref TEntity x, ref TWorld y) => duration);
        public static BehaviourAction<TEntity, TWorld> AddStatusEffect(uint type, EntityWorldFunc<TEntity, TWorld, int> durationGetter) => new AddStatusEffect<TEntity, TWorld>(type, durationGetter);

        public static BehaviourAction<TEntity, TWorld> Attack(byte attackIndex, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => Attack((ref TEntity x, ref TWorld y) => attackIndex, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> Attack(EntityWorldFunc<TEntity, TWorld, byte> attackIndexFunc, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => new Attack<TEntity, TWorld>(attackIndexFunc, targetingFunc);

        public static BehaviourAction<TEntity, TWorld> Chat(string message) => Chat((ref TEntity x, ref TWorld y) => message);
        public static BehaviourAction<TEntity, TWorld> Chat(EntityWorldFunc<TEntity, TWorld, string> messageGetter) => new Chat<TEntity, TWorld>(messageGetter, false);
        public static BehaviourAction<TEntity, TWorld> ChatWorld(string message) => ChatWorld((ref TEntity x, ref TWorld y) => message);
        public static BehaviourAction<TEntity, TWorld> ChatWorld(EntityWorldFunc<TEntity, TWorld, string> messageGetter) => new Chat<TEntity, TWorld>(messageGetter, true);
        */

        public static BehaviourAction<TEntity, TWorld> Delay(long delay, params BehaviourAction<TEntity, TWorld>[] actions) => Delay((ref TEntity x, ref TWorld y) => delay, actions);
        public static BehaviourAction<TEntity, TWorld> Delay(EntityWorldFunc<TEntity, TWorld, long> delayGetter, params BehaviourAction<TEntity, TWorld>[] actions) => new Delay<TEntity, TWorld>(delayGetter, actions);
        public static BehaviourAction<TEntity, TWorld> DelayUpdate(long delay, params BehaviourAction<TEntity, TWorld>[] actions) => DelayUpdate((ref TEntity x, ref TWorld y) => delay, actions);
        public static BehaviourAction<TEntity, TWorld> DelayUpdate(EntityWorldFunc<TEntity, TWorld, long> delayGetter, params BehaviourAction<TEntity, TWorld>[] actions) => new DelayUpdate<TEntity, TWorld>(delayGetter, actions);

        public static BehaviourAction<TEntity, TWorld> Execute(EntityWorldAction<TEntity, TWorld> entityAction) => new Execute<TEntity, TWorld>(entityAction);

        /*
        public static BehaviourAction<TEntity, TWorld> Force(byte magnitude) => new Force<TEntity, TWorld>(magnitude);
        */

        public static BehaviourAction<TEntity, TWorld> Group(params BehaviourAction<TEntity, TWorld>[] actions) => new Group<TEntity, TWorld>(actions);

        public static int Hours(int hours) => hours * Minutes(1) * MinutesPerHour;
        public static uint Hours(uint hours) => hours * Minutes(1U) * MinutesPerHour;
        public static long Hours(long hours) => hours * Minutes(1) * MinutesPerHour;
        public static long Hours(float hours) => (long)(hours * Minutes(1) * MinutesPerHour);

        public static ConditionalBehaviourAction<TEntity, TWorld> If(EntityWorldFunc<TEntity, TWorld, bool> condition, params BehaviourAction<TEntity, TWorld>[] actions) => new Conditional<TEntity, TWorld>(condition, actions);

        /*
        public static BehaviourAction<TEntity, TWorld> Log(LogLevel logLevel, string message, EntityWorldFunc<TEntity, TWorld, object[]> argsGetter) => new Log<TEntity, TWorld>(logLevel, message, argsGetter);
        public static BehaviourAction<TEntity, TWorld> Log(LogLevel logLevel, string message, params object[] args) => Log(logLevel, message, (ref TEntity x, ref TWorld y) => args);
        public static BehaviourAction<TEntity, TWorld> LogCritical(string message, EntityWorldFunc<TEntity, TWorld, object[]> argsGetter) => Log(LogLevel.Critical, message, argsGetter);
        public static BehaviourAction<TEntity, TWorld> LogCritical(string message, params object[] args) => Log(LogLevel.Critical, message, args);
        public static BehaviourAction<TEntity, TWorld> LogDebug(string message, EntityWorldFunc<TEntity, TWorld, object[]> argsGetter) => Log(LogLevel.Debug, message, argsGetter);
        public static BehaviourAction<TEntity, TWorld> LogDebug(string message, params object[] args) => Log(LogLevel.Debug, message, args);
        public static BehaviourAction<TEntity, TWorld> LogError(string message, EntityWorldFunc<TEntity, TWorld, object[]> argsGetter) => Log(LogLevel.Error, message, argsGetter);
        public static BehaviourAction<TEntity, TWorld> LogError(string message, params object[] args) => Log(LogLevel.Error, message, args);
        public static BehaviourAction<TEntity, TWorld> LogInfo(string message, EntityWorldFunc<TEntity, TWorld, object[]> argsGetter) => Log(LogLevel.Information, message, argsGetter);
        public static BehaviourAction<TEntity, TWorld> LogInfo(string message, params object[] args) => Log(LogLevel.Information, message, args);
        public static BehaviourAction<TEntity, TWorld> LogTrace(string message, EntityWorldFunc<TEntity, TWorld, object[]> argsGetter) => Log(LogLevel.Trace, message, argsGetter);
        public static BehaviourAction<TEntity, TWorld> LogTrace(string message, params object[] args) => Log(LogLevel.Trace, message, args);
        public static BehaviourAction<TEntity, TWorld> LogWarning(string message, EntityWorldFunc<TEntity, TWorld, object[]> argsGetter) => Log(LogLevel.Warning, message, argsGetter);
        public static BehaviourAction<TEntity, TWorld> LogWarning(string message, params object[] args) => Log(LogLevel.Warning, message, args);
        */

        public static int Minutes(int minutes) => minutes * Seconds(1) * SecondsPerMinute;
        public static uint Minutes(uint minutes) => minutes * Seconds(1U) * SecondsPerMinute;
        public static long Minutes(long minutes) => minutes * Seconds(1) * SecondsPerMinute;
        public static long Minutes(float minutes) => (long)(minutes * Seconds(1) * SecondsPerMinute);

        /*
        public static BehaviourAction<TEntity, TWorld> Move(Vec2 vector) => Move(vector, MoveArgs.Default);
        public static BehaviourAction<TEntity, TWorld> Move(Vec2 vector, MoveArgs args) => Move((ref TEntity x, ref TWorld y) => vector, args);
        public static BehaviourAction<TEntity, TWorld> Move(EntityWorldFunc<TEntity, TWorld, Vec2> vectorGetter) => Move(vectorGetter, MoveArgs.Default);
        public static BehaviourAction<TEntity, TWorld> Move(EntityWorldFunc<TEntity, TWorld, Vec2> vectorGetter, MoveArgs args) => new Move<TEntity, TWorld>(vectorGetter, args);
        public static BehaviourAction<TEntity, TWorld> MoveAngle(float degrees, float speed) => Move(Angle.Vec2(degrees * Angle.Deg2Rad) * speed);
        public static BehaviourAction<TEntity, TWorld> MoveFrom(float speed, EntityWorldFunc<TEntity, TWorld, Vec2?> targeting) => MoveFrom(speed, MoveArgs.Default, targeting);
        public static BehaviourAction<TEntity, TWorld> MoveFrom(float speed, float? maxRange, EntityWorldFunc<TEntity, TWorld, Vec2?> targeting) => MoveFrom(speed, maxRange, MoveArgs.Default, targeting);
        public static BehaviourAction<TEntity, TWorld> MoveFrom(float speed, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targeting) => MoveFrom(speed, null, args, targeting);
        public static BehaviourAction<TEntity, TWorld> MoveFrom(float speed, float? maxRange, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targeting) => new MoveFrom<TEntity, TWorld>(speed, maxRange, args, targeting);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(float speed, float distance, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveOrbit((ref TEntity x, ref TWorld y) => speed, (ref TEntity x, ref TWorld y) => distance, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(float speed, float distance, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveOrbit((ref TEntity x, ref TWorld y) => speed , (ref TEntity x, ref TWorld y) => distance, args, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(EntityWorldFunc<TEntity, TWorld, float> speedGetter, float distance, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveOrbit(speedGetter , (ref TEntity x, ref TWorld y) => distance, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(EntityWorldFunc<TEntity, TWorld, float> speedGetter, float distance, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveOrbit(speedGetter , (ref TEntity x, ref TWorld y) => distance, args, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(float speed, EntityWorldFunc<TEntity, TWorld, float> distanceGetter, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveOrbit((ref TEntity x, ref TWorld y) => speed, distanceGetter, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(float speed, EntityWorldFunc<TEntity, TWorld, float> distanceGetter, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveOrbit((ref TEntity x, ref TWorld y) => speed, distanceGetter, args, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(EntityWorldFunc<TEntity, TWorld, float> speedGetter, EntityWorldFunc<TEntity, TWorld, float> distanceGetter, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveOrbit(speedGetter, distanceGetter, MoveArgs.Default, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveOrbit(EntityWorldFunc<TEntity, TWorld, float> speedGetter, EntityWorldFunc<TEntity, TWorld, float> distanceGetter, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => new MoveOrbit<TEntity, TWorld>(speedGetter, distanceGetter, args, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveRandomAngle(float speed) => MoveRandomAngle(speed, MoveArgs.Default);
        public static BehaviourAction<TEntity, TWorld> MoveRandomAngle(float speed, MoveArgs args) => Move((ref TEntity x, ref TWorld y) => Angle.Vec2(x.Random01() * Angle.PI2) * speed, args);
        public static BehaviourAction<TEntity, TWorld> MoveToConstantSpeed(float speed, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveToConstantSpeed(speed, 0, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveToConstantSpeed(float speed, float minRange, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveToConstantSpeed(speed, minRange, MoveArgs.Default, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveToConstantSpeed(float speed, float minRange, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => new MoveToConstantSpeed<TEntity, TWorld>(speed, minRange, args, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveToConstantTime(long time, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveToConstantTime(time, 0, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveToConstantTime(long time, float minRange, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => MoveToConstantTime(time, minRange, MoveArgs.Default, targetingFunc);
        public static BehaviourAction<TEntity, TWorld> MoveToConstantTime(long time, float minRange, MoveArgs args, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc) => new MoveToConstantTime<TEntity, TWorld>(time, minRange, args, targetingFunc);
        */
        public static BehaviourAction<TEntity, TWorld> Once(params BehaviourAction<TEntity, TWorld>[] actions) => new Once<TEntity, TWorld>(actions);

        public static EntityWorldFunc<TEntity, TWorld, T> RandomOf<T>(params T[] values) => (ref TEntity x, ref TWorld y) => values.RandomOf(ref y);
        public static EntityWorldFunc<TEntity, TWorld, float> RandomRange(float min, float max) => (ref TEntity x, ref TWorld y) => min + (max - min) * y.Random01();
        public static EntityWorldFunc<TEntity, TWorld, int> RandomRange(int min, int max) => (ref TEntity x, ref TWorld y) => y.RandomRange(min, max);
        public static EntityWorldFunc<TEntity, TWorld, long> RandomRange(long min, long max) => (ref TEntity x, ref TWorld y) => y.RandomRange((int)min, (int)max);

        /*
        public static BehaviourAction<TEntity, TWorld> RemoveOtherIndex() => new SetOther<TEntity, TWorld>(0);
        public static BehaviourAction<TEntity, TWorld> RemoveStatusEffect(uint type) => new RemoveStatusEffect<TEntity, TWorld>(type);
        */
        public static BehaviourAction<TEntity, TWorld> Repeat(long interval, params BehaviourAction<TEntity, TWorld>[] actions) => Repeat(interval, -1, actions);
        public static BehaviourAction<TEntity, TWorld> Repeat(long interval, int count, params BehaviourAction<TEntity, TWorld>[] actions) => Repeat((ref TEntity x, ref TWorld y) => interval, count, actions);
        public static BehaviourAction<TEntity, TWorld> Repeat(EntityWorldFunc<TEntity, TWorld, long> intervalFunc, params BehaviourAction<TEntity, TWorld>[] actions) => Repeat(intervalFunc, -1, actions);
        public static BehaviourAction<TEntity, TWorld> Repeat(EntityWorldFunc<TEntity, TWorld, long> intervalFunc, int count, params BehaviourAction<TEntity, TWorld>[] actions) => new Repeat<TEntity, TWorld>(intervalFunc, count, actions);

        public static int Seconds(int seconds) => seconds * MillisecondsPerSecond;
        public static uint Seconds(uint seconds) => seconds * MillisecondsPerSecond;
        public static long Seconds(long seconds) => seconds * MillisecondsPerSecond;
        public static long Seconds(float seconds) => (long)(seconds * MillisecondsPerSecond);

        /*
        public static BehaviourAction<TEntity, TWorld> SetMinionState(string name) => SetMinionState(name, (ref TEntity x, ref TWorld y) => true);
        public static BehaviourAction<TEntity, TWorld> SetMinionState(string name, EntityWorldFunc<TEntity, TWorld, bool> filter) => new SetMinionState<TEntity, TWorld>(name, filter);

        public static BehaviourAction<TEntity, TWorld> SetOtherIndex(byte otherIndex) => new SetOther<TEntity, TWorld>((byte)(otherIndex + 1));
        */

        public static BehaviourAction<TEntity, TWorld> SetRandomState(params string[] names) => SetRandomState(1, names);
        public static BehaviourAction<TEntity, TWorld> SetRandomState(int level, params string[] names) => new SetRandomState<TEntity, TWorld>(names, level);

        public static BehaviourAction<TEntity, TWorld> SetState(string name) => SetState(name, 1);
        public static BehaviourAction<TEntity, TWorld> SetState(string name, int level) => new SetState<TEntity, TWorld>(name, level);
        public static BehaviourAction<TEntity, TWorld> SetState(int stateId) => SetState(stateId, 1);
        public static BehaviourAction<TEntity, TWorld> SetState(int stateId, int level) => SetState((ref TEntity x, ref TWorld y) => stateId, level);
        public static BehaviourAction<TEntity, TWorld> SetState(EntityWorldFunc<TEntity, TWorld, int> stateIdGetter) => SetState(stateIdGetter, 1);
        public static BehaviourAction<TEntity, TWorld> SetState(EntityWorldFunc<TEntity, TWorld, int> stateIdGetter, int level) => new SetState<TEntity, TWorld>(stateIdGetter, level);

        /*
        public static BehaviourAction<TEntity, TWorld> SetTextureIndex(byte textureIndex) => new SetTexture<TEntity, TWorld>(textureIndex);

        public static BehaviourAction<TEntity, TWorld> Spawn(ushort type, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc, bool isMinion = true) => Spawn((ref TEntity x, ref TWorld y) => type, targetingFunc, isMinion);
        public static BehaviourAction<TEntity, TWorld> Spawn(EntityWorldFunc<TEntity, TWorld, ushort> typeGetter, EntityWorldFunc<TEntity, TWorld, Vec2?> targetingFunc, bool isMinion = true) => new Spawn<TEntity, TWorld>(typeGetter, targetingFunc, isMinion);
        */
        public static BehaviourAction<TEntity, TWorld> State(string name, params BehaviourAction<TEntity, TWorld>[] actions) => State(name, string.Empty, actions);
        public static BehaviourAction<TEntity, TWorld> State(string name, string defaultSubState, params BehaviourAction<TEntity, TWorld>[] actions) => new State<TEntity, TWorld>(name, defaultSubState, actions);
        /*
        public static BehaviourAction<TEntity, TWorld> StayOnGround(float speed, params ushort[] groundTypes) => StayOnGround(speed, 0f, MoveArgs.Default, groundTypes);
        public static BehaviourAction<TEntity, TWorld> StayOnGround(float speed, MoveArgs args, params ushort[] groundTypes) => StayOnGround(speed, 0, args, groundTypes);
        public static BehaviourAction<TEntity, TWorld> StayOnGround(float speed, float minRange, params ushort[] groundTypes) => StayOnGround(speed, minRange, MoveArgs.Default, groundTypes);
        public static BehaviourAction<TEntity, TWorld> StayOnGround(float speed, float minRange, MoveArgs args, params ushort[] groundTypes) => new StayOnGround<TEntity, TWorld>(speed, minRange, args, groundTypes);

        public static BehaviourAction<TEntity, TWorld> SyncMinionStates() => SyncMinionStates((ref TEntity x, ref TWorld y) => true);
        public static BehaviourAction<TEntity, TWorld> SyncMinionStates(EntityWorldFunc<TEntity, TWorld, bool> filter) => new SyncMinionStates<TEntity, TWorld>(filter);
        public static BehaviourAction<TEntity, TWorld> SyncToLeaderState(int level = 1) => new SyncToLeaderState<TEntity, TWorld>(level);

        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetAngle(float angleDegrees, float distance) => TargetOffset((ref TEntity x, ref TWorld y) => Angle.Vec2(angleDegrees * Angle.Deg2Rad) * distance);
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetAngle(float angleDegrees, EntityWorldFunc<TEntity, TWorld, float> distanceGetter) => TargetOffset((ref TEntity x, ref TWorld y) => Angle.Vec2(angleDegrees * Angle.Deg2Rad) * distanceGetter(ref x, ref y));
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetAngle(EntityWorldFunc<TEntity, TWorld, float> angleDegreesGetter, EntityWorldFunc<TEntity, TWorld, float> distanceGetter) => TargetOffset((ref TEntity x, ref TWorld y) => Angle.Vec2(angleDegreesGetter(ref x, ref y) * Angle.Deg2Rad) * distanceGetter(ref x, ref y));
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetLeader() => (ref TEntity entity, ref TWorld y) => entity.GetLeaderCoordinates();
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetOffset(Vec2 vector) => (ref TEntity x, ref TWorld y) => x.Coordinates + vector;
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetOffset(EntityWorldFunc<TEntity, TWorld, Vec2> offsetGetter) => (ref TEntity x, ref TWorld y) => x.Coordinates + offsetGetter(ref x, ref y);
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetPlayerClosest(float scanRadius) => (ref TEntity entity, ref TWorld y) => entity.GetClosestPlayerCoordinates(scanRadius);
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetPlayerVisibleClosest(float scanRadius) => (ref TEntity entity, ref TWorld y) => entity.GetClosestVisiblePlayerCoordinates(scanRadius);
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetSelf() => (ref TEntity x, ref TWorld y) => x.Coordinates;
        public static EntityWorldFunc<TEntity, TWorld, Vec2?> TargetSpawn() => (ref TEntity x, ref TWorld y) => x.SpawnCoordinates;
        */

        public static BehaviourAction<TEntity, TWorld> Until(long duration, params BehaviourAction<TEntity, TWorld>[] actions) => Until((ref TEntity x, ref TWorld y) => duration, actions);
        public static BehaviourAction<TEntity, TWorld> Until(EntityWorldFunc<TEntity, TWorld, long> durationGetter, params BehaviourAction<TEntity, TWorld>[] actions) => new Until<TEntity, TWorld>(durationGetter, actions);

        public static Vec2 Vec2(float x, float y) => new Vec2(x, y);
        public static Vec2 X(float x) => Vec2(x, 0);
        public static Vec2 Y(float y) => Vec2(0, y);

        internal BehaviourBuilder<TKey, TEntity, TWorld> Build()
        {
            var builder = new BehaviourBuilder<TKey, TEntity, TWorld>(GetType());
            Build(builder);
            return builder;
        }
    }
}
