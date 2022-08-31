using UnnamedStudios.Logic.Behaviour;
using UnnamedStudios.Logic.Behaviour.Builder;

namespace UnnamedStudios.Logic.Demo
{
    public class SampleBehaviours : BehaviourDefinition
    {
        public override void Build(BehaviourBuilder builder)
        {
            builder.Init(SampleTypes.EnemyWarrior,
                Repeat(500, // repeat these every 500 ms to recalc the random angle and requery closest player
                    MoveRandomAngle(2), // add random jitter to the movement
                    MoveToConstantSpeed(4, TargetPlayerClosest(12)) // chases players within 12 units
                ),
                Attack(0, TargetPlayerClosest(5)) // attack closest player within 5 units
            );

            builder.Init(SampleTypes.EnemyArcher,
                State("move",
                    Repeat(500, MoveRandomAngle(2)), // add random jitter to the movement
                    Delay(2000, // after 2 seconds
                        If(x => x.GetClosestPlayer(15) != null, SetState("shoot")) // if a player is within 15 units, goto shoot state
                    )
                ),
                State("shoot",
                    Attack(0, TargetPlayerClosest(15)), // attack the closest player within 15 units
                    Delay(1000, SetState("move")) // delay for 1 second, then go back to move state
                )
            );
        }
    }
}
