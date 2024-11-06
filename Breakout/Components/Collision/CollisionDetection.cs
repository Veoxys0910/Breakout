using Breakout.Interfaces.Physics;
using System;

//Used for the different collision checks between actors and the edges of the screen.
namespace Breakout.Components.Collision
{
    public class CollisionDetection
    {
        /// <summary>
        /// Checks for bottom edge collision and calls the bottomBoundCollision method of the physics object
        /// if there is one.
        /// </summary>
        /// <param name="p_physicsObject"></param>
        /// <param name="p_resH"></param>

        public void bottomBoundsCheck(IPhysicsObject p_physicsObject, int p_resH)
        {
            IVerticalBoundCollidable physicsObject = p_physicsObject as IVerticalBoundCollidable;

            int bottom = (int) physicsObject.getPosition().y + physicsObject.getHeight();

            bool isColliding = bottom >= p_resH;

            if (isColliding)
            {
                physicsObject.bottomBoundCollision();
            }
        }

        /// <summary>
        /// Checks for top edge collision and calls the topBoundCollision method of the physics object
        /// if there is one.
        /// </summary>
        /// <param name="p_physicsObject"></param>

        public void topBoundsCheck(IPhysicsObject p_physicsObject)
        {
            IVerticalBoundCollidable physicsObject = p_physicsObject as IVerticalBoundCollidable;

            int top = (int) physicsObject.getPosition().y;

            bool isColliding = top <= 0;

            if (isColliding)
            {
                physicsObject.topBoundCollision();
            }
        }

        /// <summary>
        /// Checks for left edge collision and calls the leftBoundCollision method of the physics object
        /// if there is one.
        /// </summary>
        /// <param name="p_physicsObject"></param>

        public void leftBoundsCheck(IPhysicsObject p_physicsObject)
        {
            IHorizontalBoundCollidable physicsObject = p_physicsObject as IHorizontalBoundCollidable;

            int left = (int) physicsObject.getPosition().x;

            bool isColliding = left <= 0;

            if (isColliding)
            {
                physicsObject.leftBoundCollision();
            }
        }

        /// <summary>
        /// Checks for right edge collision and calls the rightBoundCollision method of the physics object
        /// if there is one.
        /// </summary>
        /// <param name="p_physicsObject"></param>
        /// <param name="p_resW"></param>

        public void rightBoundsCheck(IPhysicsObject p_physicsObject, int p_resW)
        {
            IHorizontalBoundCollidable physicsObject = p_physicsObject as IHorizontalBoundCollidable;

            int right = (int) physicsObject.getPosition().x + physicsObject.getWidth();

            bool isColliding = right >= p_resW;

            if (isColliding)
            {
                physicsObject.rightBoundCollision();
            }
        }

        /// <summary>
        /// Checks if 2 actors are colliding and returns a boolean value.
        /// </summary>
        /// <param name="p_actorA"></param>
        /// <param name="p_actorB"></param>
        /// <returns></returns>
        private bool __checkActorCollision(IActorCollidable p_actorA, IActorCollidable p_actorB)
        {
            bool hasCollision = false;
            bool xCollision = false;
            bool yCollision = false;

            int actorALeft = (int)p_actorA.getPosition().x;
            int actorARight = actorALeft + p_actorA.getWidth();
            int actorATop = (int)p_actorA.getPosition().y;
            int actorABottom = actorATop + p_actorA.getHeight();

            int actorBLeft = (int)p_actorB.getPosition().x;
            int actorBRight = actorBLeft + p_actorB.getWidth();
            int actorBTop = (int)p_actorB.getPosition().y;
            int actorBBottom = actorBTop + p_actorB.getHeight();

            xCollision = actorARight > actorBLeft && actorALeft < actorBRight;
            yCollision = actorABottom > actorBTop && actorATop < actorBBottom;

            hasCollision = xCollision && yCollision;

            return hasCollision;
        }

        /// <summary>
        /// Once both actors are colliding,
        /// this method will determine which axis the collision occurs.
        /// </summary>
        /// <param name="p_objectA"></param>
        /// <param name="p_objectB"></param>

        public void actorCollision(IPhysicsObject p_objectA, IPhysicsObject p_objectB)
        {
            bool bothActorCollidable = p_objectA is IActorCollidable && p_objectB is IActorCollidable;

            if (!bothActorCollidable)
            {
                return;
            }

            IActorCollidable actorA = p_objectA as IActorCollidable;
            IActorCollidable actorB = p_objectB as IActorCollidable;

            if (!this.__checkActorCollision(actorA, actorB))
            {
                return;
            }

            int halfWidthA = actorA.getWidth() / 2;
            int halfHeightA = actorA.getHeight() / 2;

            int halfWidthB = actorB.getWidth() / 2;
            int halfHeightB = actorB.getHeight() / 2;

            int centerXA = (int) actorA.getPosition().x + halfWidthA;
            int centerYA = (int) actorA.getPosition().y + halfHeightA;

            int centerXB = (int) actorB.getPosition().x + halfWidthB;
            int centerYB = (int) actorB.getPosition().y + halfHeightB;

            int differenceX = centerXA - centerXB;
            int differenceY = centerYA - centerYB;

            int minDistanceX = halfWidthA + halfWidthB;
            int minDistanceY = halfHeightA + halfHeightB;

            int depthX = (differenceX > 0) ? minDistanceX - differenceX : -minDistanceX - differenceX;
            int depthY = (differenceY > 0) ? minDistanceY - differenceY : -minDistanceY - differenceY;

            bool hasDepth = depthX != 0 && depthY != 0;

            if (!hasDepth)
            {
                return;
            }

            bool hasCollisionX = Math.Abs(depthX) < Math.Abs(depthY);

            if (hasCollisionX)
            {
                this.__collisionX(actorA, actorB, depthX);
            }
            else
            {
                this.__collisionY(actorA, actorB, depthY);
            }
        }

        /// <summary>
        /// This method checks which side the collision occurs then calls the appropriate
        /// actorCollision method
        /// </summary>
        /// <param name="p_actorA"></param>
        /// <param name="p_actorB"></param>
        /// <param name="p_depthX"></param>
        
        private void __collisionX(IActorCollidable p_actorA, IActorCollidable p_actorB, int p_depthX)
        {
            bool leftCollision = p_depthX > 0;

            if (leftCollision)
            {
                p_actorA.leftActorCollision(p_actorB);
                //p_actorB.rightActorCollision(p_actorA);
            }
            else
            {
                p_actorA.rightActorCollision(p_actorB);
                //p_actorB.leftActorCollision(p_actorA);
            }
        }

        /// <summary>
        /// This method checks which side the collision occurs then calls the appropriate
        /// actorCollision method
        /// </summary>
        /// <param name="p_actorA"></param>
        /// <param name="p_actorB"></param>
        /// <param name="p_depthY"></param>

        private void __collisionY(IActorCollidable p_actorA, IActorCollidable p_actorB, int p_depthY)
        {
            bool topCollision = p_depthY > 0;

            if (topCollision)
            {
                p_actorA.topActorCollision(p_actorB);
                //p_actorB.bottomActorCollision(p_actorA);
            }
            else
            {
                p_actorA.bottomActorCollision(p_actorB);
               //p_actorB.topActorCollision(p_actorA);
            }
        }
    }
}
