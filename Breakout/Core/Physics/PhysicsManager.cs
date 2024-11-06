using Breakout.Components.Collision;
using Breakout.Components.Entities;
using Breakout.Interfaces.Physics;

namespace Breakout.Core.Physics
{
    public class PhysicsManager
    {
        private CollisionDetection __collisionManager;

        private int __resW;
        private int __resH;

        public PhysicsManager(CollisionDetection p_collisionDetection, int p_resW, int p_resH)
        {
            this.__collisionManager = p_collisionDetection;

            this.__resW = p_resW;
            this.__resH = p_resH;
        }

        /// <summary>
        /// Main physics loop.
        /// Loops through IPhysicsObject list
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <param name="p_deltaTime"></param>

        public void physicsLoop(GameWorld p_gameWorld, double p_deltaTime)
        {
            int size = p_gameWorld.getPhysicsObjectsSize();
            IPhysicsObject physicsObject = null;

            for (int i = 0; i < size; i++)
            {
                physicsObject = p_gameWorld.getPhysicsObject(i);

                this.__moveBall(physicsObject);
                this.__movePowerUp(physicsObject);

                this.__checkBoundsCollisions(physicsObject);

                this.__decelerate(physicsObject);

                this.__updatePosition(physicsObject, p_deltaTime);

                this.__checkActorCollisions(p_gameWorld, physicsObject);
                
            }
        }

        /// <summary>
        /// For updating the bounds when the window is resized
        /// </summary>
        /// <param name="p_resW"></param>
        /// <param name="p_resH"></param>

        public void updateRes(int p_resW, int p_resH)
        {
            this.__resW = p_resW;
            this.__resH = p_resH;
        }

        /// <summary>
        /// Updates position of IMovable objects
        /// </summary>
        /// <param name="p_physicsObject"></param>
        /// <param name="p_deltaTime"></param>

        private void __updatePosition(IPhysicsObject p_physicsObject, double p_deltaTime)
        {
            bool isMovable = p_physicsObject is IMovable;

            if (!isMovable)
            {
                return;
            }

            IMovable movable = p_physicsObject as IMovable;

            movable.updatePosition(p_deltaTime);
        }

        /// <summary>
        /// Decelerates IMovable objects
        /// </summary>
        /// <param name="p_physicsObject"></param>

        private void __decelerate(IPhysicsObject p_physicsObject)
        {
            bool isMovable = p_physicsObject is IMovable;

            if (!isMovable)
            {
                return;
            }

            IMovable movable = p_physicsObject as IMovable;

            movable.decelerate();
        }

        /// <summary>
        /// Moves ball based on the boolean values on which way is should be moving
        /// </summary>
        /// <param name="p_physicsObject"></param>

        private void __moveBall(IPhysicsObject p_physicsObject)
        {
            bool isBall = p_physicsObject is Ball;

            if (!isBall)
            {
                return;
            }

            Ball ball = p_physicsObject as Ball;

            ball.moveBall();
        }

        /// <summary>
        /// Moves power up downwards
        /// </summary>
        /// <param name="p_physicsObject"></param>

        private void __movePowerUp(IPhysicsObject p_physicsObject)
        {
            bool isPowerUp = p_physicsObject is PowerUp;

            if (!isPowerUp)
            {
                return;
            }

            PowerUp powerUp = p_physicsObject as PowerUp;

            powerUp.moveDown();
        }

        /// <summary>
        /// Used for checking bound collisions
        /// </summary>
        /// <param name="p_physicsObject"></param>

        private void __checkBoundsCollisions(IPhysicsObject p_physicsObject)
        {
            bool isVerticalBoundCollidable = p_physicsObject is IVerticalBoundCollidable;
            bool isHorizontalBoundCollidable = p_physicsObject is IHorizontalBoundCollidable;

            if (isVerticalBoundCollidable)
            {
                this.__collisionManager.bottomBoundsCheck(p_physicsObject, this.__resH);
                this.__collisionManager.topBoundsCheck(p_physicsObject);
            }

            if (isHorizontalBoundCollidable)
            {
                this.__collisionManager.leftBoundsCheck(p_physicsObject);
                this.__collisionManager.rightBoundsCheck(p_physicsObject, this.__resW);
            }
        }

        /// <summary>
        /// Used for checking actor collisions
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <param name="p_physicsObjectA"></param>

        private void __checkActorCollisions(GameWorld p_gameWorld, IPhysicsObject p_physicsObjectA)
        {
            int size = p_gameWorld.getPhysicsObjectsSize();
            IPhysicsObject physicsObjectB = null;

            for (int i = 0; i < size; i++)
            {
                physicsObjectB = p_gameWorld.getPhysicsObject(i);

                if (physicsObjectB == p_physicsObjectA)
                {
                    continue;
                }

                this.__collisionManager.actorCollision(p_physicsObjectA, physicsObjectB);
            }
        }
    }
}
