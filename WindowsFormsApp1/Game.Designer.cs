namespace WindowsFormsApp1
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.UpMov = new System.Windows.Forms.Timer(this.components);
            this.DownMov = new System.Windows.Forms.Timer(this.components);
            this.RightMov = new System.Windows.Forms.Timer(this.components);
            this.LeftMov = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // UpMov
            // 
            this.UpMov.Interval = 10;
            this.UpMov.Tick += new System.EventHandler(this.UpMov_Tick);
            // 
            // DownMov
            // 
            this.DownMov.Interval = 10;
            this.DownMov.Tick += new System.EventHandler(this.DownMov_Tick);
            // 
            // RightMov
            // 
            this.RightMov.Interval = 10;
            this.RightMov.Tick += new System.EventHandler(this.RightMov_Tick);
            // 
            // LeftMov
            // 
            this.LeftMov.Interval = 10;
            this.LeftMov.Tick += new System.EventHandler(this.LeftMov_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = global::WindowsFormsApp1.Properties.Resources.IdleSisterFront;
            this.Player.Location = new System.Drawing.Point(1119, 446);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(102, 110);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 1;
            this.Player.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Kitchen;
            this.pictureBox1.Location = new System.Drawing.Point(499, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(848, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(573, 284);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(705, 50);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Game";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Игра_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Игра_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer UpMov;
        private System.Windows.Forms.Timer DownMov;
        private System.Windows.Forms.Timer RightMov;
        private System.Windows.Forms.Timer LeftMov;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}