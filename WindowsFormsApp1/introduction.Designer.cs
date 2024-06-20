namespace GameForm
{
    partial class introduction
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Introd1 = new System.Windows.Forms.Label();
            this.Introd2 = new System.Windows.Forms.Label();
            this.Introd4 = new System.Windows.Forms.Label();
            this.Introd3 = new System.Windows.Forms.Label();
            this.Introd5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(1780, 978);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = " -->";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Introd1
            // 
            this.Introd1.AutoSize = true;
            this.Introd1.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Introd1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Introd1.Location = new System.Drawing.Point(708, 326);
            this.Introd1.Name = "Introd1";
            this.Introd1.Size = new System.Drawing.Size(660, 30);
            this.Introd1.TabIndex = 12;
            this.Introd1.Text = "Мир встает на ноги, отряхивая себя, после недавних войн. ";
            // 
            // Introd2
            // 
            this.Introd2.AutoSize = true;
            this.Introd2.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Introd2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Introd2.Location = new System.Drawing.Point(526, 356);
            this.Introd2.Name = "Introd2";
            this.Introd2.Size = new System.Drawing.Size(989, 30);
            this.Introd2.TabIndex = 13;
            this.Introd2.Text = "Наш мир давно разрушен, в моих глазах каждодневно отражается тлен и безысходность" +
    ".";
            // 
            // Introd4
            // 
            this.Introd4.AutoSize = true;
            this.Introd4.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Introd4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Introd4.Location = new System.Drawing.Point(734, 481);
            this.Introd4.Name = "Introd4";
            this.Introd4.Size = new System.Drawing.Size(569, 30);
            this.Introd4.TabIndex = 14;
            this.Introd4.Text = "Через несколько дней, моя мама оставила записку:";
            // 
            // Introd3
            // 
            this.Introd3.AutoSize = true;
            this.Introd3.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Introd3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Introd3.Location = new System.Drawing.Point(507, 405);
            this.Introd3.Name = "Introd3";
            this.Introd3.Size = new System.Drawing.Size(1032, 30);
            this.Introd3.TabIndex = 15;
            this.Introd3.Text = "Отца забрали на войну. Позже, в наш дом пришло извещание, что отец безвести пропа" +
    "вший.";
            // 
            // Introd5
            // 
            this.Introd5.AutoSize = true;
            this.Introd5.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Introd5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Introd5.Location = new System.Drawing.Point(909, 617);
            this.Introd5.Name = "Introd5";
            this.Introd5.Size = new System.Drawing.Size(243, 30);
            this.Introd5.TabIndex = 16;
            this.Introd5.Text = "\"Позаботься об Олесе.\"";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1780, 978);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 17;
            this.button2.Text = " -->";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // introduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Introd5);
            this.Controls.Add(this.Introd3);
            this.Controls.Add(this.Introd4);
            this.Controls.Add(this.Introd2);
            this.Controls.Add(this.Introd1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "introduction";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Introd1;
        private System.Windows.Forms.Label Introd2;
        private System.Windows.Forms.Label Introd4;
        private System.Windows.Forms.Label Introd3;
        private System.Windows.Forms.Label Introd5;
        private System.Windows.Forms.Button button2;
    }
}

