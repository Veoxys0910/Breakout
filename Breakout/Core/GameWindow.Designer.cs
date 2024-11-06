namespace Breakout.Core
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.soundPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.mainMenuPanel = new System.Windows.Forms.Panel();
            this.highScoreNumLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.playButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.scorePanel = new System.Windows.Forms.Panel();
            this.scoreNumLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.soundPlayer)).BeginInit();
            this.mainMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // soundPlayer
            // 
            this.soundPlayer.Enabled = true;
            this.soundPlayer.Location = new System.Drawing.Point(-1, 0);
            this.soundPlayer.Name = "soundPlayer";
            this.soundPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("soundPlayer.OcxState")));
            this.soundPlayer.Size = new System.Drawing.Size(10, 10);
            this.soundPlayer.TabIndex = 0;
            this.soundPlayer.Visible = false;
            // 
            // mainMenuPanel
            // 
            this.mainMenuPanel.BackColor = System.Drawing.Color.Black;
            this.mainMenuPanel.Controls.Add(this.highScoreNumLabel);
            this.mainMenuPanel.Controls.Add(this.highScoreLabel);
            this.mainMenuPanel.Controls.Add(this.pictureBox1);
            this.mainMenuPanel.Controls.Add(this.buttonPanel);
            this.mainMenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.mainMenuPanel.Name = "mainMenuPanel";
            this.mainMenuPanel.Size = new System.Drawing.Size(534, 511);
            this.mainMenuPanel.TabIndex = 1;
            // 
            // highScoreNumLabel
            // 
            this.highScoreNumLabel.AutoSize = true;
            this.highScoreNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreNumLabel.ForeColor = System.Drawing.Color.White;
            this.highScoreNumLabel.Location = new System.Drawing.Point(248, 391);
            this.highScoreNumLabel.Name = "highScoreNumLabel";
            this.highScoreNumLabel.Size = new System.Drawing.Size(20, 24);
            this.highScoreNumLabel.TabIndex = 5;
            this.highScoreNumLabel.Text = "0";
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.ForeColor = System.Drawing.Color.White;
            this.highScoreLabel.Location = new System.Drawing.Point(127, 391);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(115, 24);
            this.highScoreLabel.TabIndex = 4;
            this.highScoreLabel.Text = "High Score :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Breakout.Properties.Resources.Title_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 232);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.playButton);
            this.buttonPanel.Controls.Add(this.quitButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPanel.ForeColor = System.Drawing.Color.Black;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(121, 511);
            this.buttonPanel.TabIndex = 2;
            // 
            // playButton
            // 
            this.playButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.White;
            this.playButton.Location = new System.Drawing.Point(0, 366);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(121, 72);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.White;
            this.quitButton.Location = new System.Drawing.Point(-1, 439);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(121, 72);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // scorePanel
            // 
            this.scorePanel.AutoSize = true;
            this.scorePanel.BackColor = System.Drawing.Color.Black;
            this.scorePanel.Controls.Add(this.scoreNumLabel);
            this.scorePanel.Controls.Add(this.scoreLabel);
            this.scorePanel.Enabled = false;
            this.scorePanel.ForeColor = System.Drawing.Color.Black;
            this.scorePanel.Location = new System.Drawing.Point(0, 0);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(84, 39);
            this.scorePanel.TabIndex = 4;
            this.scorePanel.Visible = false;
            // 
            // scoreNumLabel
            // 
            this.scoreNumLabel.AutoSize = true;
            this.scoreNumLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreNumLabel.ForeColor = System.Drawing.Color.White;
            this.scoreNumLabel.Location = new System.Drawing.Point(58, 11);
            this.scoreNumLabel.Name = "scoreNumLabel";
            this.scoreNumLabel.Size = new System.Drawing.Size(18, 20);
            this.scoreNumLabel.TabIndex = 1;
            this.scoreNumLabel.Text = "0";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(3, 11);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(59, 20);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "Score :";
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Enabled = false;
            this.pauseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.ForeColor = System.Drawing.Color.White;
            this.pauseLabel.Location = new System.Drawing.Point(210, 243);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(288, 24);
            this.pauseLabel.TabIndex = 6;
            this.pauseLabel.Text = "Paused : Press ESC To Continue";
            this.pauseLabel.Visible = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.mainMenuPanel);
            this.Controls.Add(this.soundPlayer);
            this.Controls.Add(this.scorePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Breakout";
            ((System.ComponentModel.ISupportInitialize)(this.soundPlayer)).EndInit();
            this.mainMenuPanel.ResumeLayout(false);
            this.mainMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer soundPlayer;
        private System.Windows.Forms.Panel mainMenuPanel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreNumLabel;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label highScoreNumLabel;
        private System.Windows.Forms.Label pauseLabel;
    }
}

