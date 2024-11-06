using System;
using System.Windows.Forms;
using Breakout.Core.Input;
using Breakout.Core.Timing;
using Breakout.Interfaces;
using Breakout.Core.Physics;
using Breakout.Core.Update;
using System.Drawing;
using System.IO;

namespace Breakout.Core
{
    public class GameManager
    {
        private GameWorld __gameWorld;
        private TimerManager __timerManager;
        private InputManager __inputManager;
        private PhysicsManager __physicsManager;
        private UpdateManager __updateManager;

        private GameWindow __gameWindow;
        private Label __scoreNumLabel;
        private Label __highScoreNumLabel;

        private int __level;

        public GameManager(Managers p_managers, GameWindow p_gameWindow, Label p_scoreNumLabel, Label p_highScoreNumLabel)
        {
            this.__gameWorld = p_managers.gameWorld;
            this.__timerManager = p_managers.timerManager;
            this.__inputManager = p_managers.inputManager;
            this.__physicsManager = p_managers.physicsManager;
            this.__updateManager = p_managers.updateManager;

            this.__gameWindow = p_gameWindow;
            this.__scoreNumLabel = p_scoreNumLabel;
            this.__highScoreNumLabel = p_highScoreNumLabel;

            this.__level = 1;

            this.__inputManager.pauseRequested += this.__onPauseRequest;

            this.__initGameLoop();
        }

        /// <summary>
        /// For initializing the bricks, ball, and paddle
        /// </summary>
        /// <param name="p_controls"></param>

        public void initRenderObjects(Control.ControlCollection p_controls)
        {
            int size = this.__gameWorld.getRenderObjectsSize();
            IRenderObject renderObjects = null;
            Control renderObject = null;

            for (int i = 0; i < size; i++)
            {
                renderObjects = this.__gameWorld.getRenderObject(i);
                renderObject = renderObjects.getRenderObject();

                p_controls.Add(renderObject);
            }
        }

        public void startGame()
        {
            this.__initGameWorld();
            this.__timerManager.startTimer();
        }

        /// <summary>
        /// Used to subscribe to the timer's tick event
        /// </summary>

        private void __initGameLoop()
        {
            this.__timerManager.addTimerTickListener(this.__gameLoop);
        }

        /// <summary>
        /// Main game loop
        /// </summary>
        /// <param name="p_sender"></param>
        /// <param name="p_event"></param>

        private void __gameLoop(object p_sender, EventArgs p_event)
        {
            double deltaTime = 0.00f;

            deltaTime = this.__timerManager.getDeltaTime();

            this.__inputManager.inputLoop(this.__gameWorld);

            this.__physicsManager.physicsLoop(this.__gameWorld, deltaTime);

            if (!this.__updateManager.updateLoop(this.__gameWorld))
            {
                this.__endGame();
            }
        }

        private void __initGameWorld()
        {
            int resWidth = this.__gameWindow.Width;
            int resHeight = this.__gameWindow.Height;

            this.__physicsManager.updateRes(resWidth, resHeight);

            this.__gameWorld.initBall(resWidth, resHeight);
            this.__gameWorld.initBricks(resWidth, resHeight, this.__level);
            this.__gameWorld.initPlayer(resWidth, resHeight);

            this.initRenderObjects(this.__gameWindow.Controls);
        }

        /// <summary>
        /// Used for ending the game
        /// </summary>

        private void __endGame()
        {
            bool hasWon = this.__gameWorld.getBrickSize() <= 0;

            this.__updateHighScore();

            this.__gameWorld.disposeObjects();

            this.__timerManager.stopTimer();

            this.__newGame(hasWon);

            this.__inputManager.clearInput();
        }

        private void __newGame(bool p_hasWon)
        {
            string message = string.Empty;

            if (p_hasWon)
            {
                message = "Well Done! Next Level?";
            }
            else
            {
                message = "You got this! Try Again?";
            }

            if (MessageBox.Show(message, "Breakout", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                this.__backToStart();
                this.__gameWorld.resetScore();

                this.__level = 1;
                return;
            }

            if (p_hasWon)
            {
                this.__levelUp();
            }
            else
            {
                this.__gameWorld.resetScore();
                this.__restart();
            }

            this.__gameWindow.Invalidate();

            this.initRenderObjects(this.__gameWindow.Controls);

            this.startGame();

            this.__gameWindow.Focus();
        }

        private void __levelUp()
        {
            int width = this.__gameWindow.Width + 100;
            int height = 550;

            this.__resizeWindow(width, height);

            this.__level++;
        }

        private void __restart()
        {
            int width = 516;
            int height = 516;

            this.__resizeWindow(width, height);

            this.__physicsManager.updateRes(width, height);

            this.__level = 1;
        }

        private void __backToStart()
        {
            int width = 516;
            int height = 516;

            this.__resizeWindow(width, height);

            this.__physicsManager.updateRes(width, height);

            this.__gameWindow.showMainMenu();
        }

        /// <summary>
        /// Used for resizing and centering the window
        /// </summary>
        /// <param name="p_width"></param>
        /// <param name="p_height"></param>

        private void __resizeWindow(int p_width, int p_height)
        {
            int totalWidth = p_width + SystemInformation.FrameBorderSize.Width * 2 + 26;

            bool biggerThanScreen = totalWidth > Screen.PrimaryScreen.WorkingArea.Width - 100;

            if (biggerThanScreen)
            {
                return;
            }

            int screenWidth = (Screen.PrimaryScreen.WorkingArea.Width - p_width) / 2;
            int screenHeight = (Screen.PrimaryScreen.WorkingArea.Height - p_height) / 2;

            this.__gameWindow.Size = new Size(totalWidth, p_height);

            this.__gameWindow.ClientSize = new System.Drawing.Size(totalWidth, p_height);
            this.__gameWindow.Location = new System.Drawing.Point(screenWidth, screenHeight);
        }

        private void __updateHighScore()
        {
            int highScore = Convert.ToInt32(this.__highScoreNumLabel.Text);
            int score = Convert.ToInt32(this.__scoreNumLabel.Text);

            if (score <= highScore)
            {
                return;
            }

            this.__highScoreNumLabel.Text = this.__scoreNumLabel.Text;

            string contentPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Content\High_Score.txt");
            string fullPath = Path.GetFullPath(contentPath);
            string content = score.ToString();

            File.WriteAllText(fullPath, content);
        }

        /// <summary>
        /// Used for pausing the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void __onPauseRequest(object sender, EventArgs e)
        {
            this.__timerManager.toggleTimer();

            this.__gameWindow.togglePauseLabel();
        }
    }
}
