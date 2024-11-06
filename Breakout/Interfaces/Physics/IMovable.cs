using Breakout.Components.Motion;

namespace Breakout.Interfaces.Physics
{
    public interface IMovable : IPhysicsObject
    {
        void updatePosition(double p_deltaTime);

        Vector2 getVelocity();

        void decelerate();
    }
}
