namespace ParticleSystem
{
    partial class View
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ChooseGifButton = new System.Windows.Forms.Button();
            this.ChooseMusicButton = new System.Windows.Forms.Button();
            this.backgroudList = new System.Windows.Forms.ComboBox();
            this.trackBarDirection = new System.Windows.Forms.TrackBar();
            this.directionLabel = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.trackBarPower = new System.Windows.Forms.TrackBar();
            this.trackBarTimer = new System.Windows.Forms.TrackBar();
            this.timerInterval = new System.Windows.Forms.Label();
            this.trackBarParticlesPerTick = new System.Windows.Forms.TrackBar();
            this.particlesPerTickLabel = new System.Windows.Forms.Label();
            this.trackBarSpread = new System.Windows.Forms.TrackBar();
            this.spreadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarParticlesPerTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpread)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.picDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDisplay.Location = new System.Drawing.Point(0, 0);
            this.picDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(946, 502);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 16;
            this.timer.Tick += new System.EventHandler(this.DoTick);
            // 
            // ChooseGifButton
            // 
            this.ChooseGifButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseGifButton.Location = new System.Drawing.Point(788, 10);
            this.ChooseGifButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ChooseGifButton.Name = "ChooseGifButton";
            this.ChooseGifButton.Size = new System.Drawing.Size(145, 42);
            this.ChooseGifButton.TabIndex = 1;
            this.ChooseGifButton.Text = "Выбрать гифку";
            this.ChooseGifButton.UseVisualStyleBackColor = true;
            this.ChooseGifButton.Click += new System.EventHandler(this.ChooseGifButtonPressed);
            // 
            // ChooseMusicButton
            // 
            this.ChooseMusicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseMusicButton.Location = new System.Drawing.Point(788, 54);
            this.ChooseMusicButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ChooseMusicButton.Name = "ChooseMusicButton";
            this.ChooseMusicButton.Size = new System.Drawing.Size(145, 42);
            this.ChooseMusicButton.TabIndex = 2;
            this.ChooseMusicButton.Text = "Выбрать музыку";
            this.ChooseMusicButton.UseVisualStyleBackColor = true;
            this.ChooseMusicButton.Click += new System.EventHandler(this.ChooseMusicButtonPressed);
            // 
            // backgroudList
            // 
            this.backgroudList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroudList.FormattingEnabled = true;
            this.backgroudList.Location = new System.Drawing.Point(788, 100);
            this.backgroudList.Name = "backgroudList";
            this.backgroudList.Size = new System.Drawing.Size(145, 23);
            this.backgroudList.TabIndex = 3;
            this.backgroudList.SelectedIndexChanged += new System.EventHandler(this.BackgroudListSelectedIndexChanged);
            // 
            // trackBarDirection
            // 
            this.trackBarDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarDirection.Location = new System.Drawing.Point(0, 457);
            this.trackBarDirection.Maximum = 359;
            this.trackBarDirection.Name = "trackBarDirection";
            this.trackBarDirection.Size = new System.Drawing.Size(134, 45);
            this.trackBarDirection.TabIndex = 4;
            this.trackBarDirection.Scroll += new System.EventHandler(this.trackBarDirectionChange);
            // 
            // directionLabel
            // 
            this.directionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.directionLabel.AutoSize = true;
            this.directionLabel.BackColor = System.Drawing.Color.Transparent;
            this.directionLabel.Location = new System.Drawing.Point(9, 439);
            this.directionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(101, 15);
            this.directionLabel.TabIndex = 5;
            this.directionLabel.Text = "Направление : 0°";
            this.directionLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // powerLabel
            // 
            this.powerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.powerLabel.AutoSize = true;
            this.powerLabel.BackColor = System.Drawing.Color.Transparent;
            this.powerLabel.Location = new System.Drawing.Point(140, 439);
            this.powerLabel.Margin = new System.Windows.Forms.Padding(0);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(116, 15);
            this.powerLabel.TabIndex = 6;
            this.powerLabel.Text = "Сила гравитации : 0";
            // 
            // trackBarPower
            // 
            this.trackBarPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarPower.Location = new System.Drawing.Point(131, 457);
            this.trackBarPower.Maximum = 359;
            this.trackBarPower.Minimum = -359;
            this.trackBarPower.Name = "trackBarPower";
            this.trackBarPower.Size = new System.Drawing.Size(134, 45);
            this.trackBarPower.TabIndex = 7;
            this.trackBarPower.Scroll += new System.EventHandler(this.trackBarPower_Scroll);
            // 
            // trackBarTimer
            // 
            this.trackBarTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarTimer.Location = new System.Drawing.Point(812, 457);
            this.trackBarTimer.Maximum = 100;
            this.trackBarTimer.Minimum = 1;
            this.trackBarTimer.Name = "trackBarTimer";
            this.trackBarTimer.Size = new System.Drawing.Size(134, 45);
            this.trackBarTimer.TabIndex = 8;
            this.trackBarTimer.Value = 25;
            this.trackBarTimer.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // timerInterval
            // 
            this.timerInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timerInterval.AutoSize = true;
            this.timerInterval.BackColor = System.Drawing.Color.Transparent;
            this.timerInterval.Location = new System.Drawing.Point(805, 439);
            this.timerInterval.Margin = new System.Windows.Forms.Padding(0);
            this.timerInterval.Name = "timerInterval";
            this.timerInterval.Size = new System.Drawing.Size(141, 15);
            this.timerInterval.TabIndex = 9;
            this.timerInterval.Text = "Частота обновления : 25";
            // 
            // trackBarParticlesPerTick
            // 
            this.trackBarParticlesPerTick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarParticlesPerTick.Location = new System.Drawing.Point(262, 457);
            this.trackBarParticlesPerTick.Maximum = 100;
            this.trackBarParticlesPerTick.Name = "trackBarParticlesPerTick";
            this.trackBarParticlesPerTick.Size = new System.Drawing.Size(134, 45);
            this.trackBarParticlesPerTick.TabIndex = 10;
            this.trackBarParticlesPerTick.Value = 1;
            this.trackBarParticlesPerTick.Scroll += new System.EventHandler(this.trackBarParticlesPerTick_Scroll);
            // 
            // particlesPerTickLabel
            // 
            this.particlesPerTickLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.particlesPerTickLabel.AutoSize = true;
            this.particlesPerTickLabel.BackColor = System.Drawing.Color.Transparent;
            this.particlesPerTickLabel.Location = new System.Drawing.Point(280, 439);
            this.particlesPerTickLabel.Margin = new System.Windows.Forms.Padding(0);
            this.particlesPerTickLabel.Name = "particlesPerTickLabel";
            this.particlesPerTickLabel.Size = new System.Drawing.Size(96, 15);
            this.particlesPerTickLabel.TabIndex = 11;
            this.particlesPerTickLabel.Text = "Частиц за тик : 1";
            // 
            // trackBarSpread
            // 
            this.trackBarSpread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarSpread.Location = new System.Drawing.Point(392, 457);
            this.trackBarSpread.Maximum = 359;
            this.trackBarSpread.Name = "trackBarSpread";
            this.trackBarSpread.Size = new System.Drawing.Size(179, 45);
            this.trackBarSpread.TabIndex = 12;
            this.trackBarSpread.Value = 1;
            this.trackBarSpread.Scroll += new System.EventHandler(this.trackBarSpread_Scroll);
            // 
            // spreadLabel
            // 
            this.spreadLabel.AllowDrop = true;
            this.spreadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spreadLabel.AutoSize = true;
            this.spreadLabel.BackColor = System.Drawing.Color.Transparent;
            this.spreadLabel.Location = new System.Drawing.Point(392, 439);
            this.spreadLabel.Margin = new System.Windows.Forms.Padding(0);
            this.spreadLabel.Name = "spreadLabel";
            this.spreadLabel.Size = new System.Drawing.Size(179, 15);
            this.spreadLabel.TabIndex = 13;
            this.spreadLabel.Text = "Коэффицент распределения : 0";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.spreadLabel);
            this.Controls.Add(this.trackBarSpread);
            this.Controls.Add(this.particlesPerTickLabel);
            this.Controls.Add(this.trackBarParticlesPerTick);
            this.Controls.Add(this.timerInterval);
            this.Controls.Add(this.trackBarTimer);
            this.Controls.Add(this.trackBarPower);
            this.Controls.Add(this.powerLabel);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.trackBarDirection);
            this.Controls.Add(this.backgroudList);
            this.Controls.Add(this.ChooseMusicButton);
            this.Controls.Add(this.ChooseGifButton);
            this.Controls.Add(this.picDisplay);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "View";
            this.Text = "ParticleSystem";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarParticlesPerTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpread)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer;
        private Button ChooseGifButton;
        private Button ChooseMusicButton;
        private ComboBox backgroudList;
        private TrackBar trackBarDirection;
        private Label directionLabel;
        private Label powerLabel;
        private TrackBar trackBarPower;
        private TrackBar trackBarTimer;
        private Label timerInterval;
        private TrackBar trackBarParticlesPerTick;
        private Label particlesPerTickLabel;
        private TrackBar trackBarSpread;
        private Label spreadLabel;
    }
}