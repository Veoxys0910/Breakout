namespace Breakout.Interfaces.Physics
{
    public interface IHorizontalBoundCollidable : IPhysicsObject
    {
        void leftBoundCollision();

        void rightBoundCollision();
    }
}
