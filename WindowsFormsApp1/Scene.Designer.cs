namespace WindowsFormsApp1
{
    partial class Scene
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
            this.Player = new System.Windows.Forms.PictureBox();
            this.Col1 = new System.Windows.Forms.PictureBox();
            this.Col4 = new System.Windows.Forms.PictureBox();
            this.Col2 = new System.Windows.Forms.PictureBox();
            this.Col3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Col5 = new System.Windows.Forms.PictureBox();
            this.Col6 = new System.Windows.Forms.PictureBox();
            this.inputTriger1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.MovementTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTriger1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = global::WindowsFormsApp1.Properties.Resources.PHIFront;
            this.Player.Location = new System.Drawing.Point(1244, 561);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(77, 110);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // Col1
            // 
            this.Col1.Location = new System.Drawing.Point(-23, -46);
            this.Col1.Name = "Col1";
            this.Col1.Size = new System.Drawing.Size(100, 50);
            this.Col1.TabIndex = 1;
            this.Col1.TabStop = false;
            // 
            // Col4
            // 
            this.Col4.BackColor = System.Drawing.Color.Transparent;
            this.Col4.Location = new System.Drawing.Point(801, 872);
            this.Col4.Name = "Col4";
            this.Col4.Size = new System.Drawing.Size(532, 23);
            this.Col4.TabIndex = 2;
            this.Col4.TabStop = false;
            // 
            // Col2
            // 
            this.Col2.BackColor = System.Drawing.Color.Transparent;
            this.Col2.Location = new System.Drawing.Point(801, 161);
            this.Col2.Name = "Col2";
            this.Col2.Size = new System.Drawing.Size(27, 705);
            this.Col2.TabIndex = 3;
            this.Col2.TabStop = false;
            // 
            // Col3
            // 
            this.Col3.BackColor = System.Drawing.Color.Transparent;
            this.Col3.Location = new System.Drawing.Point(813, 361);
            this.Col3.Name = "Col3";
            this.Col3.Size = new System.Drawing.Size(520, 28);
            this.Col3.TabIndex = 4;
            this.Col3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1318, 379);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 157);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Col5
            // 
            this.Col5.BackColor = System.Drawing.Color.Transparent;
            this.Col5.Location = new System.Drawing.Point(1318, 692);
            this.Col5.Name = "Col5";
            this.Col5.Size = new System.Drawing.Size(40, 174);
            this.Col5.TabIndex = 6;
            this.Col5.TabStop = false;
            // 
            // Col6
            // 
            this.Col6.BackColor = System.Drawing.Color.Transparent;
            this.Col6.Location = new System.Drawing.Point(849, 749);
            this.Col6.Name = "Col6";
            this.Col6.Size = new System.Drawing.Size(280, 104);
            this.Col6.TabIndex = 7;
            this.Col6.TabStop = false;
            // 
            // inputTriger1
            // 
            this.inputTriger1.BackColor = System.Drawing.Color.Transparent;
            this.inputTriger1.Location = new System.Drawing.Point(1318, 590);
            this.inputTriger1.Name = "inputTriger1";
            this.inputTriger1.Size = new System.Drawing.Size(31, 50);
            this.inputTriger1.TabIndex = 8;
            this.inputTriger1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(1364, 539);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 161);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // MovementTimer
            // 
            this.MovementTimer.Interval = 1;
            this.MovementTimer.Tick += new System.EventHandler(this.MovementTimer_Tick);
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.ToiletTest;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.inputTriger1);
            this.Controls.Add(this.Col6);
            this.Controls.Add(this.Col5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Col3);
            this.Controls.Add(this.Col2);
            this.Controls.Add(this.Col4);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.Col1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "Scene";
            this.Text = "Col4";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Игра_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Игра_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Col6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTriger1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.PictureBox Col1;
        private System.Windows.Forms.PictureBox Col4;
        private System.Windows.Forms.PictureBox Col2;
        private System.Windows.Forms.PictureBox Col3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Col5;
        private System.Windows.Forms.PictureBox Col6;
        private System.Windows.Forms.PictureBox inputTriger1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer MovementTimer;
    }
}