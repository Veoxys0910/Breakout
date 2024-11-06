using Breakout.Components.Motion;
using Breakout.Interfaces;
using Breakout.Interfaces.Physics;
using System.Windows.Forms;

namespace Breakout.Components.Entities
{
    public class Paddle : IRenderObject, IMovable, IActorCollidable, IHorizontalBoundCollidable
    {
        private Actor __actor;

        public Paddle(Actor p_actor)
        {
            this.__actor = p_actor;
        }

        /// <summary>
        /// Used for centering the paddle on mouse movements
        /// </summary>
        /// <param name="p_newX"></param>

        public void moveXCentered(float p_newX)
        {
            float currentX = this.__actor.getHitbox().getX();
            int width = this.__actor.getHitbox().getWidth();

            this.__actor.getMovement().setXCentered(currentX, p_newX, width);
        }

        public void moveLeft()
        {
            this.__actor.moveLeft();
        }

        public void moveRight()
        {
            this.__actor.moveRight();
        }

        public void updatePosition(double p_deltaTime)
        {
            this.__actor.updatePosition(p_deltaTime);
        }

        public void decelerate()
        {
            this.__actor.decelerate();
        }

        /// <summary>
        /// Used to stop movement when colliding with the left side
        /// </summary>

        public void leftBoundCollision()
        {
            bool movingLeft = this.__actor.getMovement().getVelocity().x < 0;

            if (movingLeft)
            {
                this.__actor.getMovement().stopXVelocity();
            }
        }

        /// <summary>
        /// Used to stop movement when colliding with the right side
        /// </summary>

        public void rightBoundCollision()
        {
            bool movingRight = this.__actor.getMovement().getVelocity().x > 0;

            if (movingRight)
            {
                this.__actor.getMovement().stopXVelocity();
            }
        }

        public void bottomActorCollision(IPhysicsObject p_physicsObject)
        {
            System.Diagnostics.Debug.WriteLine($"{p_physicsObject.ToString()} Hit.");
        }

        public void topActorCollision(IPhysicsObject p_physicsObject)
        {
            System.Diagnostics.Debug.WriteLine($"{p_physicsObject.ToString()} Hit.");
        }

        public void leftActorCollision(IPhysicsObject p_physicsObject)
        {
            System.Diagnostics.Debug.WriteLine($"{p_physicsObject.ToString()} Hit.");
        }

        public void rightActorCollision(IPhysicsObject p_physicsObject)
        {
            System.Diagnostics.Debug.WriteLine($"{p_physicsObject.ToString()} Hit.");
        }

        public Control getRenderObject()
        {
            return this.__actor.getRenderObject();
        }

        public Vector2 getPosition()
        {
            Vector2 position = new Vector2();

            position.x = this.__actor.getHitbox().getX();
            position.y = this.__actor.getHitbox().getY();

            return position;
        }

        public Vector2 getVelocity()
        {
            return this.__actor.getMovement().getVelocity();
        }

        public int getWidth()
        {
            return this.__actor.getHitbox().getWidth();
        }

        public int getHeight()
        {
            return this.__actor.getHitbox().getHeight();
        }

        public float getSpeedX()
        {
            return this.__actor.getMovement().getSpeedX();
        }
    }
}
