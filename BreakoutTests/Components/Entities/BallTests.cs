using Microsoft.VisualStudio.TestTools.UnitTesting;
using Breakout.Components.Motion;
using Breakout.Components.Collision;
using Breakout.Components.Sprite;

namespace Breakout.Components.Entities.Tests
{
    [TestClass()]
    public class BallTests
    {
        [TestMethod()]
        public void getPositionTestEqual()
        {
            Hitbox hitbox = new Hitbox(new Rectangle(10, 10, 10, 10));
            SpriteManager spriteManager = new SpriteManager("Paddle_2");
            Movement movement = new Movement(new Vector2(10, 0), 10, 5);

            Actor actor = new Actor(hitbox, spriteManager, movement);

            Ball ball = new Ball(actor);

            Vector2 actualPos = new Vector2(10, 10);

            Assert.AreEqual(ball.getPosition(), actualPos);
        }

        [TestMethod()]
        public void getPositionTestNotEqual()
        {
            Hitbox hitbox = new Hitbox(new Rectangle(0, 0, 10, 10));
            SpriteManager spriteManager = new SpriteManager("Paddle_2");
            Movement movement = new Movement(new Vector2(10, 0), 10, 5);

            Actor actor = new Actor(hitbox, spriteManager, movement);

            Ball ball = new Ball(actor);

            Vector2 actualPos = new Vector2(11, 11);

            Assert.AreNotEqual(ball.getPosition(), actualPos);
        }

        [TestMethod()]
        public void getVelocityEqual()
        {
            Hitbox hitbox = new Hitbox(new Rectangle(0, 0, 10, 10));
            SpriteManager spriteManager = new SpriteManager("Paddle_2");
            Movement movement = new Movement(new Vector2(10, 0), 10, 5);

            Actor actor = new Actor(hitbox, spriteManager, movement);

            Ball ball = new Ball(actor);

            Vector2 actualVelocity = new Vector2(10, 0);

            Assert.AreEqual(ball.getVelocity(), actualVelocity);
        }

        [TestMethod()]
        public void getVelocityNotEqual()
        {
            Hitbox hitbox = new Hitbox(new Rectangle(0, 0, 10, 10));
            SpriteManager spriteManager = new SpriteManager("Paddle_2");
            Movement movement = new Movement(new Vector2(10, 0), 10, 5);

            Actor actor = new Actor(hitbox, spriteManager, movement);

            Ball ball = new Ball(actor);

            Vector2 actualVelocity = new Vector2(0, 10);

            Assert.AreNotEqual(ball.getVelocity(), actualVelocity);
        }

        [TestMethod()]
        public void getBrickHitPointsTrue()
        {
            Hitbox hitbox = new Hitbox(new Rectangle(0, 0, 10, 10));
            SpriteManager spriteManager = new SpriteManager("Paddle_2");

            Immovable immovable = new Immovable(hitbox, spriteManager);

            Brick brick = new Brick(immovable, 10);

            Assert.IsTrue(brick.getHitPoints() > 0);
        }

        [TestMethod()]
        public void getVelocityXPaddle()
        {
            Hitbox hitbox = new Hitbox(new Rectangle(0, 0, 10, 10));
            SpriteManager spriteManager = new SpriteManager("Paddle_2");
            Movement movement = new Movement(new Vector2(), 10, 5);

            Actor actor = new Actor(hitbox, spriteManager, movement);

            Paddle paddle = new Paddle(actor);

            Assert.AreEqual(paddle.getVelocity().x, 0);
        }

        public void getPositionXPaddle()
        {
            Hitbox hitbox = new Hitbox(new Rectangle(0, 0, 10, 10));
            SpriteManager spriteManager = new SpriteManager("Paddle_2");
            Movement movement = new Movement(new Vector2(), 10, 5);

            Actor actor = new Actor(hitbox, spriteManager, movement);

            Paddle paddle = new Paddle(actor);

            Assert.AreEqual(paddle.getPosition().x, 0);
        }
    }
}