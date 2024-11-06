//Struct used for Hitbox
namespace Breakout.Components.Collision
{
    public struct Rectangle
    {
        public float x;
        public float y;

        public int width;
        public int height;

        public Rectangle(Rectangle p_rect)
        {
            this.x = p_rect.x;
            this.y = p_rect.y;
            this.width = p_rect.width;
            this.height = p_rect.height;
        }

        public Rectangle(int p_x, int p_y, int p_width, int p_height)
        {
            this.x = p_x;
            this.y = p_y;
            this.width = p_width;
            this.height = p_height;
        }
    }
}
