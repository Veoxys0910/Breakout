using Breakout.Components.Motion;

//The Hitbox used for collision detection and positioning
namespace Breakout.Components.Collision
{
    public class Hitbox
    {
        private Rectangle __rect;

        public Hitbox(Rectangle p_rect)
        {
            this.__rect = new Rectangle();

            this.__rect.x = p_rect.x;
            this.__rect.y = p_rect.y;
            this.__rect.width = p_rect.width;
            this.__rect.height = p_rect.height;
        }

        public Hitbox(float p_x, float p_y, int p_width, int p_height)
        {
            this.__rect = new Rectangle();

            this.__rect.x = p_x;
            this.__rect.y = p_y;
            this.__rect.width = p_width;
            this.__rect.height = p_height;
        }

        /// <summary>
        /// Updates position based on the velocity given
        /// </summary>
        /// <param name="p_velocity"></param>
        /// <param name="p_deltaTime"></param>

        public void updatePosition(Vector2 p_velocity, double p_deltaTime)
        {
            this.__rect.x += p_velocity.x * (float) p_deltaTime;
            this.__rect.y += p_velocity.y * (float) p_deltaTime;
        }

        public void setX(float p_x)
        {
            this.__rect.x = p_x;
        }

        public void setY(float p_y)
        {
            this.__rect.y= p_y;
        }

        public float getX()
        {
            return this.__rect.x;
        }

        public float getY()
        {
            return this.__rect.y;
        }

        public int getWidth()
        {
            return this.__rect.width;
        }

        public int getHeight()
        {
            return this.__rect.height;
        }
    }
}
