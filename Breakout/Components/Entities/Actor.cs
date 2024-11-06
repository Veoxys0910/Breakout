using Breakout.Components.Collision;
using Breakout.Components.Motion;
using Breakout.Components.Sprite;
using System.Windows.Forms;

//The Actor class is used for actors that need to be able to move
namespace Breakout.Components.Entities
{
    public class Actor
    {
        private Hitbox __hitbox;
        private SpriteManager __spriteManager;
        private Movement __movement;

        public Actor(Hitbox p_hitbox,  SpriteManager p_spriteManager, Movement p_movement)
        {
            this.__hitbox = p_hitbox;
            this.__spriteManager = p_spriteManager;
            this.__movement = p_movement;
        }

        public void moveLeft()
        {
            this.__movement.moveLeft();
        }

        public void moveRight()
        {
            this.__movement.moveRight();
        }

        public void moveUp()
        {
            this.__movement.moveUp();
        }

        public void moveDown()
        {
            this.__movement.moveDown();
        }

        public void decelerate()
        {
            this.__movement.decelerate();
        }

        public void updatePosition(double p_deltaTime)
        {
            Vector2 velocity = this.__movement.getVelocity();
            Vector2 position = new Vector2();

            this.__hitbox.updatePosition(velocity, p_deltaTime);

            position.x = this.__hitbox.getX();
            position.y = this.__hitbox.getY();

            this.__spriteManager.updatePosition(position);
        }

        /// <summary>
        /// Used for rendering
        /// </summary>
        /// <returns></returns>
        public Control getRenderObject()
        {
            return this.__spriteManager.getPictureBox();
        }

        public Hitbox getHitbox()
        {
            return this.__hitbox;
        }

        public SpriteManager getSpriteManager()
        {
            return this.__spriteManager;
        }

        public Movement getMovement()
        {
            return this.__movement;
        }
    }
}
