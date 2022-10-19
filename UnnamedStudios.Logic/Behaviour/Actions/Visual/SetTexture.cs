namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public class SetTexture<TEntity> : BehaviourAction<TEntity> where TEntity : ILogicEntity
    {
        private readonly byte _textureIndex;

        public SetTexture(byte textureIndex)
        {
            _textureIndex = textureIndex;
        }

        public override void Start(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {
            entity.SetTextureIndex(_textureIndex);
        }

        public override void Update(ref TEntity entity, ref BehaviourContext<TEntity> behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
