using Breakout.Components.Motion;
using Breakout.Interfaces;
using Breakout.Interfaces.Physics;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout.Components.Entities
{
    public class Ball : IRenderObject, IMovable, IActorCollidable, IHorizontalBoundCollidable, IVerticalBoundCollidable
    {
        private Actor __actor;

        private bool __movingLeft;
        private bool __movingRight;
        private bool __movingUp;
        private bool __movingDown;

        private float __speedIncrementY;
        private float __maxSpeedX;
        private float __maxSpeedY;

        private bool __hasHitBottom;

        public Ball(Actor p_actor)
        {
            this.__actor = p_actor;

            this.__movingDown = true;

            this.__movingLeft = false;
            this.__movingRight = false;
            this.__movingUp = false;

            this.__speedIncrementY = 0.05f;
            this.__maxSpeedX = 3.00f;
            this.__maxSpeedY = 3.00f;

            this.__hasHitBottom = false;
        }

        public Ball(Actor p_actor, bool p_movingDown)
        {
            this.__actor = p_actor;

            if (p_movingDown)
            {
                this.__movingDown = true;
                this.__movingUp = false;
            }
            else
            {
                this.__movingUp = true;
                this.__movingDown = false;
            }

            this.__movingLeft = false;
            this.__movingRight = false;
            

            this.__speedIncrementY = 0.05f;
            this.__maxSpeedX = 3.00f;
            this.__maxSpeedY = 3.00f;

            this.__hasHitBottom = false;
        }

        public Ball(Actor p_actor, Ball p_ball)
        {
            this.__actor = p_actor;

            this.__movingLeft = p_ball.__movingLeft;
            this.__movingRight= p_ball.__movingRight;
            this.__movingDown = p_ball.__movingDown;
            this.__movingUp = p_ball.__movingUp;

            this.__speedIncrementY = 0.05f;
            this.__maxSpeedX = 3.00f;
            this.__maxSpeedY = 3.00f;

            this.__hasHitBottom = false;
        }

        /// <summary>
        /// Used for the teleport powerup
        /// </summary>
        /// <param name="p_position"></param>

        public void setPosition(Vector2 p_position)
        {
            this.__actor.getHitbox().setX(p_position.x);
            this.__actor.getHitbox().setY(p_position.y);

            this.__actor.getSpriteManager().getPictureBox().Location = new Point((int) p_position.x, (int) p_position.y);
        }

        public bool hasHitBottom()
        {
            return this.__hasHitBottom;
        }

        /// <summary>
        /// Based on the boolean values,
        /// this will move the ball either up, down, left, or right
        /// </summary>

        public void moveBall()
        {
            if (this.__movingDown)
            {
                this.__moveDown();
            }
            else if (this.__movingUp)
            {
                this.__moveUp();
            }

            if (this.__movingLeft)
            {
                this.__moveLeft();
            }
            else if (this.__movingRight)
            {
                this.__moveRight();
            }
        }

        /// <summary>
        /// For updating the position with delta time
        /// To make the movement smoother
        /// </summary>
        /// <param name="p_deltaTime"></param>

        public void updatePosition(double p_deltaTime)
        {
            this.__actor.updatePosition(p_deltaTime);
        }

        public void decelerate()
        {
            this.__actor.decelerate();
        }

        public void bottomBoundCollision()
        {
            this.__hasHitBottom = true;
        }

        public void topBoundCollision()
        {
            this.__bounceDown();
        }

        public void leftBoundCollision()
        {
            this.__bounceRight();
        }

        public void rightBoundCollision()
        {
            this.__bounceLeft();
        }

        /// <summary>
        /// Bounces the ball up if the collision occurs
        /// from bricks and paddles
        /// </summary>
        /// <param name="p_physicsObject"></param>

        public void bottomActorCollision(IPhysicsObject p_physicsObject)
        {
            bool isPowerUp = p_physicsObject is PowerUp;
            bool isBall = p_physicsObject is Ball;

            if (isPowerUp || isBall)
            {
                return;
            }

            bool onMaxSpeed = this.__actor.getMovement().getSpeedY() >= this.__maxSpeedY;

            this.__bounceUp();
            this.__transferXVelocity(p_physicsObject);

            if (onMaxSpeed)
            {
                return;
            }

            this.__incrementSpeed(this.__speedIncrementY);
        }

        /// <summary>
        /// Bounces the ball down if the collision occurs
        /// from bricks and paddles
        /// </summary>
        /// <param name="p_physicsObject"></param>

        public void topActorCollision(IPhysicsObject p_physicsObject)
        {
            bool isPowerUp = p_physicsObject is PowerUp;
            bool isBall = p_physicsObject is Ball;

            if (isPowerUp || isBall)
            {
                return;
            }

            bool onMaxSpeed = this.__actor.getMovement().getSpeedY() >= this.__maxSpeedY;

            this.__bounceDown();
            this.__transferXVelocity(p_physicsObject);

            if (onMaxSpeed)
            {
                return;
            }

            this.__incrementSpeed(this.__speedIncrementY);
        }

        /// <summary>
        /// Bounces the ball right if the collision occurs
        /// from bricks and paddles
        /// </summary>
        /// <param name="p_physicsObject"></param>

        public void leftActorCollision(IPhysicsObject p_physicsObject)
        {
            bool isPowerUp = p_physicsObject is PowerUp;
            bool isBall = p_physicsObject is Ball;

            if (isPowerUp || isBall)
            {
                return;
            }

            bool onMaxSpeed = this.__actor.getMovement().getSpeedY() >= this.__maxSpeedY;

            this.__bounceRight();

            if (onMaxSpeed)
            {
                return;
            }

            this.__incrementSpeed(this.__speedIncrementY);
        }

        /// <summary>
        /// Bounces the ball left if the collision occurs
        /// from bricks and paddles
        /// </summary>
        /// <param name="p_physicsObject"></param>

        public void rightActorCollision(IPhysicsObject p_physicsObject)
        {
            bool isPowerUp = p_physicsObject is PowerUp;
            bool isBall = p_physicsObject is Ball;

            if (isPowerUp || isBall)
            {
                return;
            }

            bool onMaxSpeed = this.__actor.getMovement().getSpeedY() >= this.__maxSpeedY;

            this.__bounceLeft();

            if (onMaxSpeed)
            {
                return;
            }

            this.__incrementSpeed(this.__speedIncrementY);
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

        public Control getRenderObject()
        {
            return this.__actor.getRenderObject();
        }

        /// <summary>
        /// Used for transferring the paddle's X velocity to the ball
        /// </summary>
        /// <param name="p_physicsObject"></param>

        private void __transferXVelocity(IPhysicsObject p_physicsObject)
        {
            bool isPaddle = p_physicsObject is Paddle;

            if (!isPaddle)
            {
                return;
            }

            Paddle paddle = p_physicsObject as Paddle;

            float paddleVelocityX = paddle.getVelocity().x;
            float paddleSpeedX = paddle.getSpeedX();

            float ballVelocityX = this.getVelocity().x;
            float ballSpeedX = this.__actor.getMovement().getSpeedX();

            float newSpeedX = ballSpeedX;

            if (paddleVelocityX > 0)
            {
                if (ballVelocityX > 0)
                {
                    newSpeedX = paddleSpeedX + ballSpeedX;
                }
                else
                {
                    newSpeedX = ballSpeedX + -paddleSpeedX;
                }

                this.__bounceRight();
            }
            else if (paddleVelocityX < 0)
            {
                if (ballVelocityX < 0)
                {
                    newSpeedX = paddleSpeedX + ballSpeedX;
                }
                else
                {
                    newSpeedX = ballSpeedX + -paddleSpeedX;
                }

                this.__bounceLeft();
            }

            newSpeedX = (newSpeedX <= 0) ? 1 : newSpeedX;
            newSpeedX = (newSpeedX > this.__maxSpeedX) ? this.__maxSpeedX : newSpeedX;

            this.__actor.getMovement().setSpeedX(newSpeedX);
        }

        private void __moveLeft()
        {
            this.__actor.moveLeft();
        }

        private void __moveRight()
        {
            this.__actor.moveRight();
        }

        private void __moveUp()
        {
            this.__actor.moveUp();
        }

        private void __moveDown()
        {
            this.__actor.moveDown();
        }

        private void __incrementSpeed(float p_increment)
        {
            float newSpeed = this.__actor.getMovement().getSpeedY() + p_increment;

            this.__actor.getMovement().setSpeedY(newSpeed);
        }

        private void __bounceUp()
        {
            this.__movingDown = false;
            this.__movingUp = true;
        }

        private void __bounceDown()
        {
            this.__movingUp = false;
            this.__movingDown = true;
        }

        private void __bounceRight()
        {
            this.__movingLeft = false;
            this.__movingRight = true;
        }

        private void __bounceLeft()
        {
            this.__movingRight = false;
            this.__movingLeft = true;
        }
    }
}
