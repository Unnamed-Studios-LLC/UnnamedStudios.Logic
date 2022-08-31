namespace UnnamedStudios.Logic.Behaviour.Actions
{
    public class SetTexture : BehaviourAction
    {
        private readonly uint _textureIndex;

        public SetTexture(uint textureIndex)
        {
            _textureIndex = textureIndex;
        }

        public override void Start(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {
            entity.SetTextureIndex(_textureIndex);
        }

        public override void Update(ILogicEntity entity, BehaviourContext behaviourContext, StateContext stateContext, ref object values)
        {

        }
    }
}
