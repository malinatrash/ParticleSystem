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
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
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
            this.picDisplay.Size = new System.Drawing.Size(808, 450);
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
            this.ChooseGifButton.Location = new System.Drawing.Point(710, 6);
            this.ChooseGifButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ChooseGifButton.Name = "ChooseGifButton";
            this.ChooseGifButton.Size = new System.Drawing.Size(91, 42);
            this.ChooseGifButton.TabIndex = 1;
            this.ChooseGifButton.Text = "Выбрать гифку";
            this.ChooseGifButton.UseVisualStyleBackColor = true;
            this.ChooseGifButton.Click += new System.EventHandler(this.ChooseGifButtonPressed);
            // 
            // ChooseMusicButton
            // 
            this.ChooseMusicButton.Location = new System.Drawing.Point(710, 50);
            this.ChooseMusicButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ChooseMusicButton.Name = "ChooseMusicButton";
            this.ChooseMusicButton.Size = new System.Drawing.Size(91, 42);
            this.ChooseMusicButton.TabIndex = 2;
            this.ChooseMusicButton.Text = "Выбрать музыку";
            this.ChooseMusicButton.UseVisualStyleBackColor = true;
            this.ChooseMusicButton.Click += new System.EventHandler(this.ChooseMusicButtonPressed);
            // 
            // backgroudList
            // 
            this.backgroudList.FormattingEnabled = true;
            this.backgroudList.Location = new System.Drawing.Point(710, 96);
            this.backgroudList.Name = "backgroudList";
            this.backgroudList.Size = new System.Drawing.Size(91, 23);
            this.backgroudList.TabIndex = 3;
            this.backgroudList.SelectedIndexChanged += new System.EventHandler(this.BackgroudListSelectedIndexChanged);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.backgroudList);
            this.Controls.Add(this.ChooseMusicButton);
            this.Controls.Add(this.ChooseGifButton);
            this.Controls.Add(this.picDisplay);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "View";
            this.Text = "ParticleSystem";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer;
        private Button ChooseGifButton;
        private Button ChooseMusicButton;
        private ComboBox backgroudList;
    }
}