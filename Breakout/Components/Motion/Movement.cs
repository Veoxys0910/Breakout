namespace Breakout.Components.Motion
{
    public class Movement
    {
        private Vector2 __velocity;

        private float __moveSpeedX;
        private float __moveSpeedY;
        private float __decelerationSpeed;

        public Movement(Vector2 p_velocity, float p_moveSpeed, float p_decelerationSpeed)
        {
            this.__velocity = p_velocity;

            this.__moveSpeedX = p_moveSpeed;
            this.__moveSpeedY = p_moveSpeed;
            this.__decelerationSpeed = p_decelerationSpeed;
        }

        public Movement(Vector2 p_velocity, float p_moveSpeedX, float p_moveSpeedY, float p_decelerationSpeed)
        {
            this.__velocity = p_velocity;

            this.__moveSpeedX = p_moveSpeedX;
            this.__moveSpeedY = p_moveSpeedY;
            this.__decelerationSpeed = p_decelerationSpeed;
        }

        /// <summary>
        /// Used for mouse movement, to keep the paddle centered on the cursor
        /// </summary>
        /// <param name="p_currentX"></param>
        /// <param name="p_newX"></param>
        /// <param name="p_width"></param>
        public void setXCentered(float p_currentX, float p_newX, int p_width)
        {
            float desiredX = p_newX - (p_width / 2);

            int offsetAmount = (int) this.__moveSpeedX;

            bool newXInRange = desiredX - p_currentX <= offsetAmount && desiredX - p_currentX >= -offsetAmount;

            if (newXInRange)
            {
                return;
            }
            
            if (desiredX < p_currentX)
            {
                this.__velocity.x = -this.__moveSpeedX;
            }
            else
            {
                this.__velocity.x = this.__moveSpeedX;
            }
        }

        public void moveLeft()
        {
            this.__velocity.x = -this.__moveSpeedX;
        }

        public void moveRight()
        {
            this.__velocity.x = this.__moveSpeedX;
        }

        public void moveUp()
        {
            this.__velocity.y = -this.__moveSpeedY;
        }

        public void moveDown()
        {
            this.__velocity.y = this.__moveSpeedY;
        }

        public Vector2 getVelocity()
        {
            return this.__velocity;
        }

        public void setSpeedX(float p_speedX)
        {
            this.__moveSpeedX = p_speedX;
        }

        public void setSpeedY(float p_speedY)
        {
            this.__moveSpeedY = p_speedY;
        }

        public float getSpeedX()
        {
            return this.__moveSpeedX;
        }

        public float getSpeedY()
        {
            return this.__moveSpeedY;
        }

        public void decelerate()
        {
            this.__decelerateX();

            this.__decelerateY();
        }

        public void stopXVelocity()
        {
            this.__velocity.x = 0;
        }

        public void stopYVelocity()
        {
            this.__velocity.y = 0;
        }

        private void __decelerateX()
        {
            if (this.__velocity.x == 0)
            {
                return;
            }

            if (this.__velocity.x < 0)
            {
                this.__velocity.x += this.__decelerationSpeed;
            }

            else
            {
                this.__velocity.x -= this.__decelerationSpeed;
            }
        }

        private void __decelerateY()
        {
            if (this.__velocity.y == 0)
            {
                return;
            }

            if (this.__velocity.y < 0)
            {
                this.__velocity.y += this.__decelerationSpeed;
            }

            else
            {
                this.__velocity.y -= this.__decelerationSpeed;
            }
        }
    }
}
