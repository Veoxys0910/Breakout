using Breakout.Components.Motion;

namespace Breakout.Interfaces.Physics
{
    public interface IPhysicsObject
    {
        Vector2 getPosition();

        int getWidth();

        int getHeight();
    }
}
