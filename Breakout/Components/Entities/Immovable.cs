using Breakout.Components.Collision;
using Breakout.Components.Sprite;
using System.Windows.Forms;

//Used for bricks, same as actor but without the movement
namespace Breakout.Components.Entities
{
    public class Immovable
    {
        private Hitbox __hitbox;
        private SpriteManager __spriteManager;

        public Immovable(Hitbox p_hitbox, SpriteManager p_spriteManager)
        {
            this.__hitbox = p_hitbox;
            this.__spriteManager = p_spriteManager;
        }

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
    }
}
