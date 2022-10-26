using UnnamedStudios.Logic.Behaviour.Actions;
using UnnamedStudios.Logic.Behaviour.Arguments;
using UnnamedStudios.Logic.Behaviour.Builder;
using Zero.Game.Shared;

namespace UnnamedStudios.Logic.Behaviour
{
    public abstract class BehaviourDefinition<TEntity> where TEntity : ILogicEntity
    {
        protected const int MillisecondsPerSecond = 1_000;
        protected const int MinutesPerHour = 60;
        protected const int SecondsPerMinute = 60;

        protected static MoveArgs DefaultMoveArgs => new MoveArgs(true);

        public abstract void Build(BehaviourBuilder<TEntity> builder);

        protected static BehaviourAction<TEntity> AddStatusEffect(uint type, int duration) => AddStatusEffect(type, (ref TEntity x) => duration);
        protected static BehaviourAction<TEntity> AddStatusEffect(uint type, EntityFunc<TEntity, int> durationGetter) => new AddStatusEffect<TEntity>(type, durationGetter);
        protected static BehaviourAction<TEntity> Attack(byte attackIndex, TargetingFunc<TEntity> targetingFunc) => new Attack<TEntity>(attackIndex, targetingFunc);

        protected static BehaviourAction<TEntity> Chat(string message) => Chat((ref TEntity x) => message);
        protected static BehaviourAction<TEntity> Chat(EntityFunc<TEntity, string> messageGetter) => new Chat<TEntity>(messageGetter, false);
        protected static BehaviourAction<TEntity> ChatWorld(string message) => ChatWorld((ref TEntity x) => message);
        protected static BehaviourAction<TEntity> ChatWorld(EntityFunc<TEntity, string> messageGetter) => new Chat<TEntity>(messageGetter, true);

        protected static BehaviourAction<TEntity> Delay(long delay, params BehaviourAction<TEntity>[] actions) => Delay((ref TEntity x) => delay, actions);
        protected static BehaviourAction<TEntity> Delay(EntityFunc<TEntity, long> delayGetter, params BehaviourAction<TEntity>[] actions) => new Delay<TEntity>(delayGetter, actions);

        protected static BehaviourAction<TEntity> Execute(EntityAction<TEntity> entityAction) => new Execute<TEntity>(entityAction);

        protected static BehaviourAction<TEntity> Force(byte magnitude) => new Force<TEntity>(magnitude);

        protected static int Forever() => Hours(9_999);

        protected static BehaviourAction<TEntity> Group(params BehaviourAction<TEntity>[] actions) => new Group<TEntity>(actions);

        protected static int Hours(int hours) => hours * Minutes(1) * MinutesPerHour;
        protected static uint Hours(uint hours) => hours * Minutes(1U) * MinutesPerHour;
        protected static long Hours(long hours) => hours * Minutes(1) * MinutesPerHour;
        protected static long Hours(float hours) => (long)(hours * Minutes(1) * MinutesPerHour);

        protected static ConditionalBehaviourAction<TEntity> If(EntityFunc<TEntity, bool> condition, params BehaviourAction<TEntity>[] actions) => new Conditional<TEntity>(condition, actions);

        protected static BehaviourAction<TEntity> Log(LogLevel logLevel, string message, EntityFunc<TEntity, object[]> argsGetter) => new Log<TEntity>(logLevel, message, argsGetter);
        protected static BehaviourAction<TEntity> Log(LogLevel logLevel, string message, params object[] args) => Log(logLevel, message, (ref TEntity x) => args);
        protected static BehaviourAction<TEntity> LogCritical(string message, EntityFunc<TEntity, object[]> argsGetter) => Log(LogLevel.Critical, message, argsGetter);
        protected static BehaviourAction<TEntity> LogCritical(string message, params object[] args) => Log(LogLevel.Critical, message, args);
        protected static BehaviourAction<TEntity> LogDebug(string message, EntityFunc<TEntity, object[]> argsGetter) => Log(LogLevel.Debug, message, argsGetter);
        protected static BehaviourAction<TEntity> LogDebug(string message, params object[] args) => Log(LogLevel.Debug, message, args);
        protected static BehaviourAction<TEntity> LogError(string message, EntityFunc<TEntity, object[]> argsGetter) => Log(LogLevel.Error, message, argsGetter);
        protected static BehaviourAction<TEntity> LogError(string message, params object[] args) => Log(LogLevel.Error, message, args);
        protected static BehaviourAction<TEntity> LogInfo(string message, EntityFunc<TEntity, object[]> argsGetter) => Log(LogLevel.Information, message, argsGetter);
        protected static BehaviourAction<TEntity> LogInfo(string message, params object[] args) => Log(LogLevel.Information, message, args);
        protected static BehaviourAction<TEntity> LogTrace(string message, EntityFunc<TEntity, object[]> argsGetter) => Log(LogLevel.Trace, message, argsGetter);
        protected static BehaviourAction<TEntity> LogTrace(string message, params object[] args) => Log(LogLevel.Trace, message, args);
        protected static BehaviourAction<TEntity> LogWarning(string message, EntityFunc<TEntity, object[]> argsGetter) => Log(LogLevel.Warning, message, argsGetter);
        protected static BehaviourAction<TEntity> LogWarning(string message, params object[] args) => Log(LogLevel.Warning, message, args);

        protected static int Minutes(int minutes) => minutes * Seconds(1) * SecondsPerMinute;
        protected static uint Minutes(uint minutes) => minutes * Seconds(1U) * SecondsPerMinute;
        protected static long Minutes(long minutes) => minutes * Seconds(1) * SecondsPerMinute;
        protected static long Minutes(float minutes) => (long)(minutes * Seconds(1) * SecondsPerMinute);

        protected static MoveArgs MoveArgs(bool checkCollision) => new MoveArgs(checkCollision);

        protected static BehaviourAction<TEntity> Move(Vec2 vector) => Move(vector, DefaultMoveArgs);
        protected static BehaviourAction<TEntity> Move(Vec2 vector, MoveArgs args) => Move((ref TEntity x) => vector, args);
        protected static BehaviourAction<TEntity> Move(EntityFunc<TEntity, Vec2> vectorGetter) => Move(vectorGetter, DefaultMoveArgs);
        protected static BehaviourAction<TEntity> Move(EntityFunc<TEntity, Vec2> vectorGetter, MoveArgs args) => new Move<TEntity>(vectorGetter, args);
        protected static BehaviourAction<TEntity> MoveAngle(float degrees, float speed) => Move(Angle.Vec2(degrees * Angle.Deg2Rad) * speed);
        protected static BehaviourAction<TEntity> MoveFrom(float speed, TargetingFunc<TEntity> targeting) => MoveFrom(speed, DefaultMoveArgs, targeting);
        protected static BehaviourAction<TEntity> MoveFrom(float speed, MoveArgs args, TargetingFunc<TEntity> targeting) => new MoveFrom<TEntity>(speed, args, targeting);
        protected static BehaviourAction<TEntity> MoveOrbit(float distance, float speed, TargetingFunc<TEntity> targetingFunc) => MoveOrbit((ref TEntity x) => distance, (ref TEntity x) => speed, targetingFunc);
        protected static BehaviourAction<TEntity> MoveOrbit(float distance, float speed, MoveArgs args, TargetingFunc<TEntity> targetingFunc) => MoveOrbit((ref TEntity x) => distance, (ref TEntity x) => speed, args, targetingFunc);
        protected static BehaviourAction<TEntity> MoveOrbit(float distance, EntityFunc<TEntity, float> speedGetter, TargetingFunc<TEntity> targetingFunc) => MoveOrbit((ref TEntity x) => distance, speedGetter, targetingFunc);
        protected static BehaviourAction<TEntity> MoveOrbit(float distance, EntityFunc<TEntity, float> speedGetter, MoveArgs args, TargetingFunc<TEntity> targetingFunc) => MoveOrbit((ref TEntity x) => distance, speedGetter, args, targetingFunc);
        protected static BehaviourAction<TEntity> MoveOrbit(EntityFunc<TEntity, float> distanceGetter, float speed, TargetingFunc<TEntity> targetingFunc) => MoveOrbit(distanceGetter, (ref TEntity x) => speed, targetingFunc);
        protected static BehaviourAction<TEntity> MoveOrbit(EntityFunc<TEntity, float> distanceGetter, float speed, MoveArgs args, TargetingFunc<TEntity> targetingFunc) => MoveOrbit(distanceGetter, (ref TEntity x) => speed, args, targetingFunc);
        protected static BehaviourAction<TEntity> MoveOrbit(EntityFunc<TEntity, float> distanceGetter, EntityFunc<TEntity, float> speedGetter, TargetingFunc<TEntity> targetingFunc) => MoveOrbit(distanceGetter, speedGetter, DefaultMoveArgs, targetingFunc);
        protected static BehaviourAction<TEntity> MoveOrbit(EntityFunc<TEntity, float> distanceGetter, EntityFunc<TEntity, float> speedGetter, MoveArgs args, TargetingFunc<TEntity> targetingFunc) => new MoveOrbit<TEntity>(distanceGetter, speedGetter, args, targetingFunc);
        protected static BehaviourAction<TEntity> MoveRandomAngle(float speed) => MoveRandomAngle(speed, DefaultMoveArgs);
        protected static BehaviourAction<TEntity> MoveRandomAngle(float speed, MoveArgs args) => Move((ref TEntity x) => Angle.Vec2(x.Random01() * Angle.PI2) * speed, args);
        protected static BehaviourAction<TEntity> MoveToConstantSpeed(float speed, TargetingFunc<TEntity> targetingFunc) => MoveToConstantSpeed(speed, 0, targetingFunc);
        protected static BehaviourAction<TEntity> MoveToConstantSpeed(float speed, float minRange, TargetingFunc<TEntity> targetingFunc) => MoveToConstantSpeed(speed, minRange, DefaultMoveArgs, targetingFunc);
        protected static BehaviourAction<TEntity> MoveToConstantSpeed(float speed, float minRange, MoveArgs args, TargetingFunc<TEntity> targetingFunc) => new MoveToConstantSpeed<TEntity>(speed, minRange, args, targetingFunc);
        protected static BehaviourAction<TEntity> MoveToConstantTime(long time, TargetingFunc<TEntity> targetingFunc) => MoveToConstantTime(time, 0, targetingFunc);
        protected static BehaviourAction<TEntity> MoveToConstantTime(long time, float minRange, TargetingFunc<TEntity> targetingFunc) => MoveToConstantTime(time, minRange, DefaultMoveArgs, targetingFunc);
        protected static BehaviourAction<TEntity> MoveToConstantTime(long time, float minRange, MoveArgs args, TargetingFunc<TEntity> targetingFunc) => new MoveToConstantTime<TEntity>(time, minRange, args, targetingFunc);

        protected static BehaviourAction<TEntity> Once(params BehaviourAction<TEntity>[] actions) => new Once<TEntity>(actions);

        protected static EntityFunc<TEntity, T> RandomOf<T>(params T[] values) => (ref TEntity x) => x.RandomOf(values);
        protected static EntityFunc<TEntity, float> RandomRange(float min, float max) => (ref TEntity x) => min + (max - min) * x.Random01();
        protected static EntityFunc<TEntity, int> RandomRange(int min, int max) => (ref TEntity x) => x.RandomRange(min, max);
        protected static EntityFunc<TEntity, long> RandomRange(long min, long max) => (ref TEntity x) => x.RandomRange((int)min, (int)max);

        protected static BehaviourAction<TEntity> RemoveOtherIndex() => new SetOther<TEntity>(0);
        protected static BehaviourAction<TEntity> RemoveStatusEffect(uint type) => new RemoveStatusEffect<TEntity>(type);

        protected static BehaviourAction<TEntity> Repeat(long interval, params BehaviourAction<TEntity>[] actions) => Repeat(interval, -1, actions);
        protected static BehaviourAction<TEntity> Repeat(long interval, int count, params BehaviourAction<TEntity>[] actions) => Repeat((ref TEntity x) => interval, count, actions);
        protected static BehaviourAction<TEntity> Repeat(EntityFunc<TEntity, long> intervalFunc, params BehaviourAction<TEntity>[] actions) => Repeat(intervalFunc, -1, actions);
        protected static BehaviourAction<TEntity> Repeat(EntityFunc<TEntity, long> intervalFunc, int count, params BehaviourAction<TEntity>[] actions) => new Repeat<TEntity>(intervalFunc, count, actions);

        protected static int Seconds(int seconds) => seconds * MillisecondsPerSecond;
        protected static uint Seconds(uint seconds) => seconds * MillisecondsPerSecond;
        protected static long Seconds(long seconds) => seconds * MillisecondsPerSecond;
        protected static long Seconds(float seconds) => (long)(seconds * MillisecondsPerSecond);

        protected static BehaviourAction<TEntity> SetOtherIndex(byte otherIndex) => new SetOther<TEntity>((byte)(otherIndex + 1));

        protected static BehaviourAction<TEntity> SetMinionState(string name) => SetMinionState(name, (ref TEntity x) => true);
        protected static BehaviourAction<TEntity> SetMinionState(string name, EntityFunc<TEntity, bool> filter) => new SetMinionState<TEntity>(name, filter);
        protected static BehaviourAction<TEntity> SetState(string name) => SetState(name, 1);
        protected static BehaviourAction<TEntity> SetState(string name, int level) => new SetState<TEntity>(name, level);
        protected static BehaviourAction<TEntity> SetState(int stateId) => SetState(stateId, 1);
        protected static BehaviourAction<TEntity> SetState(int stateId, int level) => SetState((ref TEntity x) => stateId, level);
        protected static BehaviourAction<TEntity> SetState(EntityFunc<TEntity, int> stateIdGetter) => SetState(stateIdGetter, 1);
        protected static BehaviourAction<TEntity> SetState(EntityFunc<TEntity, int> stateIdGetter, int level) => new SetState<TEntity>(stateIdGetter, level);

        protected static BehaviourAction<TEntity> SetTextureIndex(byte textureIndex) => new SetTexture<TEntity>(textureIndex);

        protected static BehaviourAction<TEntity> Spawn(ushort type, TargetingFunc<TEntity> targetingFunc, bool isMinion = true) => Spawn((ref TEntity x) => type, targetingFunc, isMinion);
        protected static BehaviourAction<TEntity> Spawn(EntityFunc<TEntity, ushort> typeGetter, TargetingFunc<TEntity> targetingFunc, bool isMinion = true) => new Spawn<TEntity>(typeGetter, targetingFunc, isMinion);

        protected static BehaviourAction<TEntity> State(string name, params BehaviourAction<TEntity>[] actions) => State(name, string.Empty, actions);
        protected static BehaviourAction<TEntity> State(string name, string defaultSubState, params BehaviourAction<TEntity>[] actions) => new State<TEntity>(name, defaultSubState, actions);

        protected static BehaviourAction<TEntity> StayOnGround(float speed, params ushort[] groundTypes) => StayOnGround(speed, 0, groundTypes);
        protected static BehaviourAction<TEntity> StayOnGround(float speed, MoveArgs args, params ushort[] groundTypes) => StayOnGround(speed, 0, args, groundTypes);
        protected static BehaviourAction<TEntity> StayOnGround(float speed, float minRange, params ushort[] groundTypes) => StayOnGround(speed, minRange, DefaultMoveArgs, groundTypes);
        protected static BehaviourAction<TEntity> StayOnGround(float speed, float minRange, MoveArgs args, params ushort[] groundTypes) => new StayOnGround<TEntity>(speed, minRange, args, groundTypes);

        protected static BehaviourAction<TEntity> SyncMinionStates() => SyncMinionStates((ref TEntity x) => true);
        protected static BehaviourAction<TEntity> SyncMinionStates(EntityFunc<TEntity, bool> filter) => new SyncMinionStates<TEntity>(filter);
        protected static BehaviourAction<TEntity> SyncToLeaderState(int level = 1) => new SyncToLeaderState<TEntity>(level);

        protected static TargetingFunc<TEntity> TargetAngle(float angleDegrees, float distance) => TargetOffset((ref TEntity x) => Angle.Vec2(angleDegrees * Angle.Deg2Rad) * distance);
        protected static TargetingFunc<TEntity> TargetAngle(float angleDegrees, EntityFunc<TEntity, float> distanceGetter) => TargetOffset((ref TEntity x) => Angle.Vec2(angleDegrees * Angle.Deg2Rad) * distanceGetter(ref x));
        protected static TargetingFunc<TEntity> TargetAngle(EntityFunc<TEntity, float> angleDegreesGetter, EntityFunc<TEntity, float> distanceGetter) => TargetOffset((ref TEntity x) => Angle.Vec2(angleDegreesGetter(ref x) * Angle.Deg2Rad) * distanceGetter(ref x));
        protected static TargetingFunc<TEntity> TargetLeader() => (ref TEntity entity) => entity.GetLeaderCoordinates();
        protected static TargetingFunc<TEntity> TargetOffset(Vec2 vector) => (ref TEntity x) => x.Coordinates + vector;
        protected static TargetingFunc<TEntity> TargetOffset(EntityFunc<TEntity, Vec2> offsetGetter) => (ref TEntity x) => x.Coordinates + offsetGetter(ref x);
        protected static TargetingFunc<TEntity> TargetPlayerClosest(float scanRadius) => (ref TEntity entity) => entity.GetClosestPlayerCoordinates(scanRadius);
        protected static TargetingFunc<TEntity> TargetPlayerVisibleClosest(float scanRadius) => (ref TEntity entity) => entity.GetClosestVisiblePlayerCoordinates(scanRadius);
        protected static TargetingFunc<TEntity> TargetSelf() => (ref TEntity x) => x.Coordinates;
        protected static TargetingFunc<TEntity> TargetSpawn() => (ref TEntity x) => x.SpawnCoordinates;

        protected static Vec2 Vec2(float x, float y) => new Vec2(x, y);
        protected static Vec2 X(float x) => Vec2(x, 0);
        protected static Vec2 Y(float y) => Vec2(0, y);

        internal BehaviourBuilder<TEntity> Build()
        {
            var builder = new BehaviourBuilder<TEntity>(GetType());
            Build(builder);
            return builder;
        }
    }
}
