namespace Breakout.Interfaces.Physics
{
    public interface IActorCollidable : IPhysicsObject
    {
        void bottomActorCollision(IPhysicsObject p_physicsObject);

        void topActorCollision(IPhysicsObject p_physicsObject);

        void leftActorCollision(IPhysicsObject p_physicsObject);

        void rightActorCollision(IPhysicsObject p_physicsObject);
    }
}
