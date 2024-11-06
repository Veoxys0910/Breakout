using Breakout.Components.Entities;
using Breakout.Interfaces;

namespace Breakout.Core.Update
{
    public class UpdateManager
    {

        /// <summary>
        /// Main update loop
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <returns></returns>

        public bool updateLoop(GameWorld p_gameWorld)
        {
            bool noMoreBalls = false;

            IRenderObject renderObject = null;

            for (int i = 0; i < p_gameWorld.getRenderObjectsSize(); i++)
            {
                renderObject = p_gameWorld.getRenderObject(i);

                noMoreBalls = this.__deleteBall(p_gameWorld, renderObject);
                this.__deleteBrick(p_gameWorld, renderObject);
                this.__deletePowerUpPaddle(p_gameWorld, renderObject);
                this.__deletePowerUpBound(p_gameWorld, renderObject);
                
                if (this.__endGame(p_gameWorld) || noMoreBalls)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Used for deleting bricks that have been hit
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <param name="p_renderObject"></param>

        private void __deleteBrick(GameWorld p_gameWorld, IRenderObject p_renderObject)
        {
            bool isBrick = p_renderObject is Brick;

            if (!isBrick)
            {
                return;
            }

            Brick brick = p_renderObject as Brick;

            bool hasBeenHitEnough = brick.getHitPoints() <= 0;

            if (!hasBeenHitEnough)
            {
                return;
            }

            p_gameWorld.removeBrick(brick);
        }

        /// <summary>
        /// Used for deleting and activating power ups
        /// that have collided with paddles
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <param name="p_renderObject"></param>

        private void __deletePowerUpPaddle(GameWorld p_gameWorld, IRenderObject p_renderObject)
        {
            bool isPowerUp = p_renderObject is PowerUp;

            if (!isPowerUp)
            {
                return;
            }

            PowerUp powerUp = p_renderObject as PowerUp;

            if (!powerUp.hasPaddleCollided())
            {
                return;
            }

            powerUp.activatePowerUp(p_gameWorld, powerUp);
        }

        /// <summary>
        /// Used for deleting power ups that collide with the bottom
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <param name="p_renderObject"></param>

        private void __deletePowerUpBound(GameWorld p_gameWorld, IRenderObject p_renderObject)
        {
            bool isPowerUp = p_renderObject is PowerUp;

            if (!isPowerUp)
            {
                return;
            }

            PowerUp powerUp = p_renderObject as PowerUp;

            if (!powerUp.hasBoundCollided())
            {
                return;
            }

            p_gameWorld.removePowerUp(powerUp);
        }

        /// <summary>
        /// Deletes balls that go to the bottom
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <param name="p_renderObject"></param>
        /// <returns></returns>
        private bool __deleteBall(GameWorld p_gameWorld, IRenderObject p_renderObject)
        {
            bool isBall = p_renderObject is Ball;

            if (!isBall)
            {
                return false;
            }

            Ball ball = p_renderObject as Ball;

            if (!ball.hasHitBottom())
            {
                return false;
            }

            p_gameWorld.removeBall(ball);

            if (p_gameWorld.getBallsSize() <= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if there are no more bricks,
        /// to end the game
        /// </summary>
        /// <param name="p_gameWorld"></param>
        /// <returns></returns>

        private bool __endGame(GameWorld p_gameWorld)
        {
            if (p_gameWorld.getBrickSize() <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
