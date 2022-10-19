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

    internal class Conditional<TEntity> : ConditionalAction<TEntity, ConditionalValues> where TEntity : ILogicEntity
    {
        private readonly static Group<TEntity> _falseDefault = new Group<TEntity>(Array.Empty<BehaviourAction<TEntity>>());

        private readonly EntityFunc<TEntity, bool> _condition;
        private readonly Group<TEntity> _trueGroup;
        private readonly Group<TEntity> _falseGroup;

        public Conditional(EntityFunc<TEntity, bool> condition, BehaviourAction<TEntity>[] trueActions)
        {
            _condition = condition;
            _trueGroup = new Group<TEntity>(trueActions);
            _falseGroup = _falseDefault;
        }

        private Conditional(EntityFunc<TEntity, bool> condition, Group<TEntity> trueGroup, BehaviourAction<TEntity>[] falseActions)
        {
            _condition = condition;
            _trueGroup = trueGroup;
            _falseGroup = new Group<TEntity>(falseActions);
        }

        public override ConditionalBehaviourAction<TEntity> Else(params BehaviourAction<TEntity>[] actions)
        {
            return new Conditional<TEntity>(_condition, _trueGroup, actions);
        }

        protected override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref ConditionalValues values)
        {
            values = new ConditionalValues();
        }

        protected override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref ConditionalValues values)
        {
            if (_condition(ref entity))
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
