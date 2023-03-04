using System;

namespace UnnamedStudios.Logic.Behaviour.Actions
{
    internal class ConditionalValues
    {
        public bool FalseRunning;
        public object FalseValues;
        public bool TrueRunning;
        public object TrueValues;
    }

    internal class Conditional<TEntity, TWorld> : ConditionalAction<TEntity, TWorld, ConditionalValues>
        where TWorld : ILogicWorld
    {
        private readonly static Group<TEntity, TWorld> _falseDefault = new Group<TEntity, TWorld>(Array.Empty<BehaviourAction<TEntity, TWorld>>());

        private readonly EntityWorldFunc<TEntity, TWorld, bool> _condition;
        private readonly Group<TEntity, TWorld> _trueGroup;
        private readonly Group<TEntity, TWorld> _falseGroup;

        public Conditional(EntityWorldFunc<TEntity, TWorld, bool> condition, BehaviourAction<TEntity, TWorld>[] trueActions)
        {
            _condition = condition;
            _trueGroup = new Group<TEntity, TWorld>(trueActions);
            _falseGroup = _falseDefault;
        }

        private Conditional(EntityWorldFunc<TEntity, TWorld, bool> condition, Group<TEntity, TWorld> trueGroup, BehaviourAction<TEntity, TWorld>[] falseActions)
        {
            _condition = condition;
            _trueGroup = trueGroup;
            _falseGroup = new Group<TEntity, TWorld>(falseActions);
        }

        public override ConditionalBehaviourAction<TEntity, TWorld> Else(params BehaviourAction<TEntity, TWorld>[] actions)
        {
            return new Conditional<TEntity, TWorld>(_condition, _trueGroup, actions);
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref ConditionalValues values)
        {
            values = new ConditionalValues();
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TWorld> behaviourContext, StateContext stateContext, ref ConditionalValues values)
        {
            if (_condition(ref entity, ref behaviourContext.World))
            {
                values.FalseRunning = false;
                if (!values.TrueRunning)
                {
                    _trueGroup.Start(ref entity, ref behaviourContext, stateContext, ref values.TrueValues);
                    values.TrueRunning = true;
                }
                _trueGroup.Update(ref entity, ref behaviourContext, stateContext, ref values.TrueValues);
            }
            else
            {
                values.TrueRunning = false;
                if (!values.FalseRunning)
                {
                    _falseGroup.Start(ref entity, ref behaviourContext, stateContext, ref values.FalseValues);
                    values.FalseRunning = true;
                }
                _falseGroup.Update(ref entity, ref behaviourContext, stateContext, ref values.FalseValues);
            }
        }
    }
}
