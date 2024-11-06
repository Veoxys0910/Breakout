using Breakout.Components.Motion;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout.Components.Sprite
{
    public class SpriteManager
    {
        private PictureBox __pictureBox;
        private Image __image;

        public SpriteManager(string p_imageName)
        {
            this.__pictureBox = new PictureBox();
            this.__image = (Bitmap) Properties.Resources.ResourceManager.GetObject(p_imageName);

            this.__pictureBox.Image = this.__image;

            this.__pictureBox.Enabled = false;
            this.__pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.__pictureBox.ClientSize = this.__image.Size;
        }

        public void updatePosition(Vector2 p_position)
        {
            Point point = new Point();

            point.X = (int) p_position.x;
            point.Y = (int) p_position.y;

            this.__pictureBox.Location = point;
        }

        public PictureBox getPictureBox()
        {
            return this.__pictureBox;
        }
    }
}
