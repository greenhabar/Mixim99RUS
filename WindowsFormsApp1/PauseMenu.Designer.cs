namespace WindowsFormsApp1
{
    partial class PauseMenu
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
            this.Resume = new System.Windows.Forms.Button();
            this.MusicSwitch = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentTask = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Resume
            // 
            this.Resume.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Resume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Resume.Location = new System.Drawing.Point(12, 95);
            this.Resume.Name = "Resume";
            this.Resume.Size = new System.Drawing.Size(360, 55);
            this.Resume.TabIndex = 0;
            this.Resume.Text = "Продолжить";
            this.Resume.UseVisualStyleBackColor = false;
            this.Resume.Click += new System.EventHandler(this.Resume_Click);
            // 
            // MusicSwitch
            // 
            this.MusicSwitch.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MusicSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MusicSwitch.Location = new System.Drawing.Point(12, 156);
            this.MusicSwitch.Name = "MusicSwitch";
            this.MusicSwitch.Size = new System.Drawing.Size(360, 55);
            this.MusicSwitch.TabIndex = 1;
            this.MusicSwitch.Text = "Музыка ON/OFF";
            this.MusicSwitch.UseVisualStyleBackColor = false;
            this.MusicSwitch.Click += new System.EventHandler(this.MusicSwitch_Click);
            // 
            // Load
            // 
            this.Load.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load.Location = new System.Drawing.Point(12, 217);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(360, 55);
            this.Load.TabIndex = 2;
            this.Load.Text = "Загрузка";
            this.Load.UseVisualStyleBackColor = false;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Location = new System.Drawing.Point(12, 278);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(360, 55);
            this.Save.TabIndex = 3;
            this.Save.Text = "Сохранение";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Location = new System.Drawing.Point(12, 974);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(360, 55);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Выход в гланое меню";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Меню Паузы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Текущая задача : ";
            // 
            // CurrentTask
            // 
            this.CurrentTask.AutoSize = true;
            this.CurrentTask.BackColor = System.Drawing.Color.DarkGray;
            this.CurrentTask.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Italic);
            this.CurrentTask.ForeColor = System.Drawing.Color.DarkRed;
            this.CurrentTask.Location = new System.Drawing.Point(12, 65);
            this.CurrentTask.Name = "CurrentTask";
            this.CurrentTask.Size = new System.Drawing.Size(210, 23);
            this.CurrentTask.TabIndex = 7;
            this.CurrentTask.Text = "Пойти в магазин за молоком";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox2.Location = new System.Drawing.Point(12, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(360, 80);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.ImageForBackgroud;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 1041);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.CurrentTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.MusicSwitch);
            this.Controls.Add(this.Resume);
            this.Name = "PauseMenu";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Resume;
        private System.Windows.Forms.Button MusicSwitch;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CurrentTask;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}