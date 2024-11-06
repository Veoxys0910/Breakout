namespace Breakout.Interfaces.Physics
{
    public interface IVerticalBoundCollidable : IPhysicsObject
    {
        void bottomBoundCollision();

        void topBoundCollision();
    }
}
