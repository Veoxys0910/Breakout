using Breakout.Components.Collision;
using Breakout.Components.Entities;
using Breakout.Components.Motion;
using Breakout.Components.Sprite;
using Breakout.Interfaces;
using Breakout.Interfaces.Physics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Breakout.Core
{
    public class GameWorld
    {
        private Control.ControlCollection __controls;
        private Label __scoreNumLabel;

        private Paddle __player1;
        private Paddle __player2;

        private List<Ball> __balls;

        private List<Brick> __bricks;
        private List<PowerUp> __powerups;

        private List<IRenderObject> __renderObjects;
        private List<IPhysicsObject> __physicsObjects;

        public GameWorld(Control.ControlCollection p_controls, Label p_scoreNumLabel)
        {
            this.__controls = p_controls;
            this.__scoreNumLabel = p_scoreNumLabel;

            this.__renderObjects = new List<IRenderObject>();
            this.__physicsObjects = new List<IPhysicsObject>();
            this.__balls = new List<Ball>();
            this.__bricks = new List<Brick>();
            this.__powerups = new List<PowerUp>();
        }

        public void removeBrick(Brick p_brick)
        {
            this.__spawnPowerUp(p_brick);

            this.__bricks.Remove(p_brick);
            this.__physicsObjects.Remove(p_brick);
            this.__renderObjects.Remove(p_brick);

            p_brick.getRenderObject().Dispose();

            this.__addScore();

            System.Diagnostics.Debug.WriteLine($"Amount Of Bricks :: {this.getBrickSize()}");
        }

        private void __addScore()
        {
            int score = Convert.ToInt32(this.__scoreNumLabel.Text);

            score += 10;

            this.__scoreNumLabel.Text = score.ToString();
        }

        public void removePowerUp(PowerUp p_powerUp)
        {
            this.__powerups.Remove(p_powerUp);
            this.__physicsObjects.Remove(p_powerUp);
            this.__renderObjects.Remove(p_powerUp);

            p_powerUp.getRenderObject().Dispose();
        }

        public void removeBall(Ball p_ball)
        {
            this.__balls.Remove(p_ball);
            this.__physicsObjects.Remove(p_ball);
            this.__renderObjects.Remove(p_ball);

            p_ball.getRenderObject().Dispose();
        }
        
        public int getBrickSize()
        {
            return this.__bricks.Count;
        }

        public Brick getBrick(int p_index)
        {
            return this.__bricks[p_index];
        }

        public IRenderObject getRenderObject(int p_index)
        {
            return this.__renderObjects[p_index];
        }

        public int getRenderObjectsSize()
        {
            return this.__renderObjects.Count;
        }

        public void addRenderObject(IRenderObject p_renderObject)
        {
            this.__renderObjects.Add(p_renderObject);
        }

        public IPhysicsObject getPhysicsObject(int p_index)
        {
            return this.__physicsObjects[p_index];
        }

        public int getPhysicsObjectsSize()
        {
            return this.__physicsObjects.Count;
        }

        public void addPhysicsObject(IPhysicsObject p_physicsObject)
        {
            this.__physicsObjects.Add(p_physicsObject);
        }

        public void addControl(Control p_control)
        {
            this.__controls.Add(p_control);
        }

        public Paddle getPlayer1()
        {
            return this.__player1;
        }

        public int getBallsSize()
        {
            return this.__balls.Count;
        }

        public Ball getBall(int p_index)
        {
            return this.__balls[p_index];
        }

        public void addBall(Ball p_ball)
        {
            this.__balls.Add(p_ball);
        }

        public void initPlayer(int p_resW, int p_resH)
        {
            int width = 100;
            int height = 10;

            int x = p_resW / 2 - (width / 2);
            int y = p_resH - 100;

            string imageName = "Paddle_2";

            int moveSpeed = 10;
            int decelerationSpeed = 5;

            Rectangle rect = new Rectangle(x, y, width, height);
            Vector2 position = new Vector2(x, y);
            Vector2 velocity = new Vector2(0, 0);

            Hitbox hitbox = new Hitbox(rect);
            SpriteManager spriteManager = new SpriteManager(imageName);
            Movement movement = new Movement(velocity, moveSpeed, decelerationSpeed);

            spriteManager.updatePosition(position);

            Actor actor = new Actor(hitbox, spriteManager, movement);

            this.__player1 = new Paddle(actor);

            this.__renderObjects.Add(this.__player1);
            this.__physicsObjects.Add(this.__player1);
        }

        public void initBall(int p_resW, int p_resH)
        {
            int width = 20;
            int height = 20;

            int x = p_resW / 2 - (width / 2);
            int y = p_resH / 2 - (height / 2);

            string imageName = "Ball_1";

            int moveSpeed = 3;
            int decelerationSpeed = 0;

            Rectangle rect = new Rectangle(x, y, width, height);
            Vector2 position = new Vector2(x, y);
            Vector2 velocity = new Vector2(0, moveSpeed);

            Hitbox hitbox = new Hitbox(rect);
            SpriteManager spriteManager = new SpriteManager(imageName);
            Movement movement = new Movement(velocity, moveSpeed, decelerationSpeed);

            spriteManager.updatePosition(position);

            Actor actor = new Actor(hitbox, spriteManager, movement);
            Ball ball = new Ball(actor);

            this.__balls.Add(ball);

            this.__renderObjects.Add(ball);
            this.__physicsObjects.Add(ball);
        }

        /// <summary>
        /// Initialize bricks based on the width of the screen
        /// </summary>
        /// <param name="p_resW"></param>
        /// <param name="p_resH"></param>
        /// <param name="p_level"></param>

        public void initBricks(int p_resW, int p_resH, int p_level)
        {
            int width = 50;
            int height = 30;

            int x = 0;
            int y = p_resH / 10 - (height / 2);

            string imageName;

            int rows = 5;
            int columns = p_resW / width;

            int hitPoints = 1;

            if (rows > 5)
            {
                rows = 5;
            }

            for (int i = 0; i < rows; i++)
            {
                hitPoints = 1;

                if (i + 1 < p_level)
                {
                    hitPoints = p_level - i;
                } 
                else if (hitPoints > 1)
                {
                    hitPoints--;
                }

                imageName = this.__selectBrickImage(hitPoints - 1);

                for (int k = 0; k < columns; k++)
                {
                    Rectangle rect = new Rectangle(x, y, width, height);
                    Vector2 position = new Vector2(x, y);

                    Hitbox hitbox = new Hitbox(rect);
                    SpriteManager spriteManager = new SpriteManager(imageName);

                    spriteManager.updatePosition(position);

                    Immovable immovable = new Immovable(hitbox, spriteManager);
                    Brick brick = new Brick(immovable, hitPoints);

                    this.__bricks.Add(brick);

                    this.__renderObjects.Add(brick);
                    this.__physicsObjects.Add(brick);

                    x += width;
                }
                x = 0;
                y += height;
            }
        }

        private void __spawnPowerUp(Brick p_brick)
        {
            Random rand = new Random();

            bool spawnPowerUp = rand.Next(0, 10) > 5;

            if (!spawnPowerUp)
            {
                return;
            }

            int width = 20;
            int height = 20;

            int x = (int) p_brick.getPosition().x + (width / 2);
            int y = (int ) p_brick.getPosition().y - (height / 2);

            string imageName = "Power_Up_1";

            int moveSpeed = 2;
            int decelerationSpeed = 0;

            Rectangle rect = new Rectangle(x, y, width, height);
            Vector2 position = new Vector2(x, y);
            Vector2 velocity = new Vector2(0, moveSpeed);

            Hitbox hitbox = new Hitbox(rect);
            SpriteManager spriteManager = new SpriteManager(imageName);
            Movement movement = new Movement(velocity, moveSpeed, decelerationSpeed);

            spriteManager.updatePosition(position);

            Actor actor = new Actor(hitbox, spriteManager, movement);
            PowerUp powerUp = new PowerUp(actor);

            this.__powerups.Add(powerUp);
            this.__physicsObjects.Add(powerUp);
            this.__renderObjects.Add(powerUp);
            this.__controls.Add(powerUp.getRenderObject());
        }

        private string __selectBrickImage(int p_rowNumber)
        {
            string imageName = string.Empty;

            switch (p_rowNumber)
            {
                case 0:
                    imageName = "Brick_Yellow";
                    break;

                case 1:
                    imageName = "Brick_Green";
                    break;

                case 2:
                    imageName = "Brick_Blue_2";
                    break;

                case 3:
                    imageName = "Brick_Pink";
                    break;

                case 4:
                    imageName = "Brick_Red_2";
                    break;

                default:
                    imageName = "Brick_Red_2";
                    break;
            }

            return imageName;
        }

        public void disposeObjects()
        {
            for (int i = 0; i < this.__renderObjects.Count; i++)
            {
                this.__controls.Remove(this.__renderObjects[i].getRenderObject());
                this.__renderObjects[i].getRenderObject().Dispose();
            }

            this.__balls.Clear();
            this.__bricks.Clear();
            this.__physicsObjects.Clear();
            this.__renderObjects.Clear();
        }

        public void resetScore()
        {
            this.__scoreNumLabel.Text = "0";
        }
    }
}
