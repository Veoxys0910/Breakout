using Breakout.Core.Input;
using Breakout.Core.Update;
using Breakout.Core.Timing;
using System.Drawing;
using System.Windows.Forms;
using Breakout.Core.Physics;
using Breakout.Components.Collision;
using System.IO;

namespace Breakout.Core
{
    public partial class GameWindow : Form
    {
        private GameManager __gameManager;

        public GameWindow()
        {
            InitializeComponent();

            string contentPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Content\Game_theme_2.mp3");
            string fullPath = Path.GetFullPath(contentPath);

            soundPlayer.URL = fullPath;
            soundPlayer.settings.volume = 25;
            soundPlayer.Ctlcontrols.play();
            soundPlayer.settings.setMode("loop", true);

            this.__initWindow();
            this.initGame();
        }

        public void showMainMenu()
        {
            this.mainMenuPanel.Enabled = true;
            this.mainMenuPanel.Visible = true;

            this.scorePanel.Visible = false;
        }

        private void __initWindow()
        {
            this.ClientSize = new Size(this.Width, this.Height);

            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.DoubleBuffered = true;

            string highScore = Properties.Resources.High_Score;

            this.highScoreNumLabel.Text = highScore;
        }

        public void initGame()
        {
            Managers managers = new Managers();

            managers.gameWorld = this.__createGameWorld();
            managers.timerManager = this.__createTimerManager();
            managers.inputManager = this.__createInputManager();
            managers.updateManager = this.__createUpdateManager();
            managers.physicsManager = this.__createPhysicsManager();

            this.__gameManager = new GameManager(managers, this, this.scoreNumLabel, this.highScoreNumLabel);
        }

        private GameWorld __createGameWorld()
        {
            return new GameWorld(this.Controls, this.scoreNumLabel);
        }

        private TimerManager __createTimerManager()
        {
            int interval = 1;

            TimerManager timerManager = new TimerManager();
            timerManager.setTimerInterval(interval);

            return timerManager;
        }

        private InputManager __createInputManager()
        {
            InputManager inputManager = new InputManager();

            this.KeyDown += inputManager.onKeyDown;
            this.KeyUp += inputManager.onKeyUp;
            this.MouseMove += inputManager.onMouseMove;

            return inputManager;
        }

        private UpdateManager __createUpdateManager()
        {
            return new UpdateManager();
        }

        private PhysicsManager __createPhysicsManager()
        {
            CollisionDetection collisionDetection = new CollisionDetection();

            return new PhysicsManager(collisionDetection, this.Width, this.Height);
        }

        public void togglePauseLabel()
        {
            int centerX = (this.Width - this.pauseLabel.Width) / 2;
            int centerY = (this.Height - this.pauseLabel.Height) / 2;

            this.pauseLabel.Location = new Point(centerX, centerY);

            this.pauseLabel.Visible = (!this.pauseLabel.Visible) ? true : false;
        }

        private void playButton_Click(object sender, System.EventArgs e)
        {
            this.__gameManager.startGame();

            this.mainMenuPanel.Enabled = false;
            this.mainMenuPanel.Visible = false;

            this.scorePanel.Visible = true;

            this.Invalidate();

            this.Focus();
        }

        private void quitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
