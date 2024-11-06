using Breakout.Components.Motion;
using Breakout.Interfaces;
using Breakout.Interfaces.Physics;
using System.Windows.Forms;

namespace Breakout.Components.Entities
{
    public class Brick : IRenderObject, IActorCollidable
    {
        private Immovable __immovable;
        private int __hitPoints;

        public Brick(Immovable p_immovable, int p_hitPoints)
        {
            this.__immovable = p_immovable;
            this.__hitPoints = p_hitPoints;
        }

        /// <summary>
        /// For updating the sprite based on the hitpoints
        /// </summary>

        private void __updateSprite()
        {
            if (this.__hitPoints <= 1)
            {
                this.__immovable.getSpriteManager().getPictureBox().Image = Properties.Resources.Brick_Yellow;
                return;
            }

            if (this.__hitPoints <= 2)
            {
                this.__immovable.getSpriteManager().getPictureBox().Image= Properties.Resources.Brick_Green;
                return;
            }

            if (this.__hitPoints <= 3)
            {
                this.__immovable.getSpriteManager().getPictureBox().Image = Properties.Resources.Brick_Blue_2;
                return;
            }

            if (this.__hitPoints <= 4)
            {
                this.__immovable.getSpriteManager().getPictureBox().Image = Properties.Resources.Brick_Pink;
                return;
            }

            this.__immovable.getSpriteManager().getPictureBox().Image = Properties.Resources.Brick_Red_2;
        }

        public void bottomActorCollision(IPhysicsObject p_physicsObject)
        {
            if (!__checkIfBallCollision(p_physicsObject))
            {
                return;
            }

            this.__isHit();
        }

        public void topActorCollision(IPhysicsObject p_physicsObject)
        {
            if (!__checkIfBallCollision(p_physicsObject))
            {
                return;
            }

            this.__isHit();
        }

        public void leftActorCollision(IPhysicsObject p_physicsObject)
        {
            if (!__checkIfBallCollision(p_physicsObject))
            {
                return;
            }

            this.__isHit();
        }

        public void rightActorCollision(IPhysicsObject p_physicsObject)
        {
            if (!__checkIfBallCollision(p_physicsObject))
            {
                return;
            }

            this.__isHit();
        }

        public int getHitPoints()
        {
            return this.__hitPoints;
        }

        public int getHeight()
        {
            return this.__immovable.getHitbox().getHeight();
        }

        public Vector2 getPosition()
        {
            float x = this.__immovable.getHitbox().getX();
            float y = this.__immovable.getHitbox().getY();

            Vector2 position = new Vector2(x, y);

            return position;
        }

        public int getWidth()
        {
            return this.__immovable.getHitbox().getWidth();
        }

        public Control getRenderObject()
        {
            return this.__immovable.getRenderObject();
        }

        /// <summary>
        /// When hit, it will minus the hitpoints of the brick
        /// </summary>

        private void __isHit()
        {
            this.__hitPoints--;

            this.__updateSprite();
        }

        private bool __checkIfBallCollision(IPhysicsObject p_physicsObject)
        {
            bool isBall = p_physicsObject is Ball;

            return isBall;
        }
    }
}
