using Breakout.Components.Collision;
using Breakout.Components.Motion;
using Breakout.Components.Sprite;
using Breakout.Core;
using Breakout.Interfaces;
using Breakout.Interfaces.Physics;
using System;
using System.Windows.Forms;

namespace Breakout.Components.Entities
{
    public class PowerUp : IMovable, IRenderObject, IVerticalBoundCollidable, IActorCollidable
    {
        private Actor __actor;
        private Power __power;

        private bool __boundCollided;
        private bool __paddleCollided;

        public PowerUp(Actor p_actor)
        {
            this.__actor = p_actor;

            this.__boundCollided = false;
            this.__paddleCollided = false;

            this.__generatePower();
        }

        /// <summary>
        /// Used for activating the power that collided with the paddle
        /// and disposing the power up
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <param name="p_powerUp"></param>

        public void activatePowerUp(GameWorld p_gameWorld, PowerUp p_powerUp)
        {
            switch (p_powerUp.getPower())
            {
                case Power.ADD_BALL:
                    this.__addBallPower(p_gameWorld);
                    break;

                case Power.TELEPORT_BALL:
                    this.__teleportBallPower(p_gameWorld);
                    break;
            }

            p_gameWorld.removePowerUp(p_powerUp);
        }

        /// <summary>
        /// Used to add an extra ball where the paddle is
        /// </summary>
        /// <param name="p_gameWorld"></param>

        private void __addBallPower(GameWorld p_gameWorld)
        {
            Paddle paddle = null;
            Vector2 paddlePosition = new Vector2();

            Rectangle rect = new Rectangle();
            Vector2 position = new Vector2();
            Vector2 velocity = new Vector2();

            Hitbox hitbox = null;
            SpriteManager spriteManager = null;
            Movement movement = null;

            Actor actor = null;
            Ball ball = null;

            int width = 20;
            int height = 20;

            string imageName = "Ball_1";

            int moveSpeed = 3;
            int decelerationSpeed = 0;

            paddle = p_gameWorld.getPlayer1();
            paddlePosition = paddle.getPosition();

            int x = (int) paddlePosition.x + (paddle.getWidth() / 2);
            int y = (int) paddlePosition.y - height;

            rect = new Rectangle(x, y, width, height);
            position = new Vector2(x, y);
            velocity = new Vector2(0, moveSpeed);

            hitbox = new Hitbox(rect);
            spriteManager = new SpriteManager(imageName);
            movement = new Movement(velocity, moveSpeed, decelerationSpeed);

            spriteManager.updatePosition(position);

            actor = new Actor(hitbox, spriteManager, movement);
            ball = new Ball(actor, p_gameWorld.getBall(0));

            p_gameWorld.addBall(ball);

            p_gameWorld.addPhysicsObject(ball);
            p_gameWorld.addRenderObject(ball);

            p_gameWorld.addControl(ball.getRenderObject());
        }

        /// <summary>
        /// Used to teleport a ball to a random brick
        /// </summary>
        /// <param name="p_gameWorld"></param>

        private void __teleportBallPower(GameWorld p_gameWorld)
        {
            Random random = new Random();

            int index = random.Next(0, p_gameWorld.getBallsSize());

            Ball ball = p_gameWorld.getBall(index);

            index = random.Next(0, p_gameWorld.getBrickSize());
            Brick brick = p_gameWorld.getBrick(index);

            ball.setPosition(brick.getPosition());
        }

        /// <summary>
        /// Used for randomly choosing which power will be stored in the power up
        /// </summary>

        private void __generatePower()
        {
            Random random = new Random();

            int randNum = random.Next(0, 10);

            if (randNum <= 8)
            {
                this.__power = Power.ADD_BALL;
            }
            else
            {
                this.__power = Power.TELEPORT_BALL;
            }
        }

        public bool hasBoundCollided()
        {
            return this.__boundCollided;
        }

        public bool hasPaddleCollided()
        {
            return this.__paddleCollided;
        }

        public void bottomActorCollision(IPhysicsObject p_physicsObject)
        {
            this.__paddleHit(p_physicsObject);
        }

        public void topActorCollision(IPhysicsObject p_physicsObject)
        {
            this.__paddleHit(p_physicsObject);
        }

        public void leftActorCollision(IPhysicsObject p_physicsObject)
        {
            this.__paddleHit(p_physicsObject);
        }

        public void rightActorCollision(IPhysicsObject p_physicsObject)
        {
            this.__paddleHit(p_physicsObject);
        }

        private void __paddleHit(IPhysicsObject p_physicsObject)
        {
            bool isPaddle = p_physicsObject is Paddle;

            if (!isPaddle)
            {
                return;
            }

            this.__paddleCollided = true;
        }

        public void bottomBoundCollision()
        {
            this.__boundCollided = true;
        }

        public void topBoundCollision()
        {
            this.__boundCollided = true;
        }

        public void moveDown()
        {
            this.__actor.moveDown();
        }

        public void decelerate()
        {
            this.__actor.decelerate();
        }

        public Power getPower()
        {
            return this.__power;
        }

        public Vector2 getPosition()
        {
            Vector2 position = new Vector2();

            float x = this.__actor.getHitbox().getX();
            float y = this.__actor.getHitbox().getY();

            position.x = x;
            position.y = y;

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

        public void updatePosition(double p_deltaTime)
        {
            this.__actor.updatePosition(p_deltaTime);
        }

        public Control getRenderObject()
        {
            return this.__actor.getRenderObject();
        }
    }

    //The powers
    public enum Power : byte
    {
        ADD_BALL,
        TELEPORT_BALL
    }
}
