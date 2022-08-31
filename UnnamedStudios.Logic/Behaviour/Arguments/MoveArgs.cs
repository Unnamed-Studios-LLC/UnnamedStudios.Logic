namespace UnnamedStudios.Logic.Behaviour.Arguments
{
    public struct MoveArgs
    {
        public MoveArgs(bool checkCollision)
        {
            CheckCollision = checkCollision;
        }

        public bool CheckCollision { get; }
    }
}
