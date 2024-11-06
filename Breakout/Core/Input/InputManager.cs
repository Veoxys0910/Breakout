using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout.Core.Input
{
    public class InputManager
    {
        public event EventHandler pauseRequested;

        public KeyEventHandler keyPressed;
        public MouseEventHandler mouseMove;

        private Dictionary<Keys, bool> __keyStates;
        private Point __mousePosition;

        private Point __prevMousePosition;

        public InputManager()
        {
            this.__keyStates = new Dictionary<Keys, bool>();
        }

        /// <summary>
        /// Main input loop for mouse and key input
        /// </summary>
        /// <param name="p_gameWorld"></param>
        
        public void inputLoop(GameWorld p_gameWorld)
        {
            this.__keyInput(p_gameWorld);

            this.__mouseInput(p_gameWorld);
        }

        /// <summary>
        /// Clearing the input after the game ends
        /// </summary>

        public void clearInput()
        {
            this.__keyStates.Clear();
            this.__mousePosition = new Point();
            this.__prevMousePosition = new Point();
        }

        /// <summary>
        /// Used for checking if mouse has moved and if it has,
        /// it will move the paddle
        /// </summary>
        /// <param name="p_gameWorld"></param>

        private void __mouseInput(GameWorld p_gameWorld)
        {
            if (this.__keyStates.ContainsValue(true))
            {
                this.__prevMousePosition = this.__mousePosition;
                return;
            }

            if (this.__mouseHasMoved())
            {
                p_gameWorld.getPlayer1().moveXCentered(this.__mousePosition.X);
            }
        }

        /// <summary>
        /// Main key input loop
        /// </summary>
        /// <param name="p_gameWorld"></param>

        private void __keyInput(GameWorld p_gameWorld)
        {
            if (isKeyPressed(Keys.A) || isKeyPressed(Keys.Left))
            {
                p_gameWorld.getPlayer1().moveLeft();
            }

            if (isKeyPressed(Keys.D) || isKeyPressed(Keys.Right))
            {
                p_gameWorld.getPlayer1().moveRight();
            }

            if (isKeyPressed(Keys.Add))
            {
                for (int i = 0; i < p_gameWorld.getBrickSize(); i++)
                {
                    p_gameWorld.getBrick(i).bottomActorCollision(p_gameWorld.getBall(0));

                    p_gameWorld.resetScore();
                }

                p_gameWorld.resetScore();
            }
        }

        public bool isKeyPressed(Keys key)
        {
            return this.__keyStates.ContainsKey(key) && this.__keyStates[key];
        }

        public void onKeyDown(object sender, KeyEventArgs e)
        {
            if (!this.__keyStates.ContainsKey(e.KeyCode) || !this.__keyStates[e.KeyCode])
            {
                this.__keyStates[e.KeyCode] = true;
                this.onKeyPressed(e.KeyCode);
            }

            if (isKeyPressed(Keys.Escape))
            {
                pauseRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        public void onKeyUp(object sender, KeyEventArgs e)
        {
            if (this.__keyStates.ContainsKey(e.KeyCode))
            {
                this.__keyStates[e.KeyCode] = false;
            }
        }

        protected virtual void onKeyPressed(Keys key)
        {
            this.keyPressed?.Invoke(this, new KeyEventArgs(key));
        }

        public void onMouseMove(object sender, MouseEventArgs e)
        {
            this.__mousePosition = e.Location;
            this.onMouseMoved(e);
        }

        protected virtual void onMouseMoved(MouseEventArgs e)
        {
            this.mouseMove?.Invoke(this, e);
        }

        private bool __mouseHasMoved()
        {
            bool mouseXHasMoved = this.__prevMousePosition.X != this.__mousePosition.X;
            bool mouseYHasMoved = this.__prevMousePosition.Y != this.__mousePosition.Y;

            return mouseXHasMoved || mouseYHasMoved;
        }
    }
}
