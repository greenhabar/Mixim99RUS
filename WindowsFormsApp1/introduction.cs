using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using Newtonsoft.Json;
using WindowsFormsApp1;

namespace GameForm
{
    public partial class introduction : Form
    {
        public List<string> DEPO = new List<string>();
        public introduction() : this("defaultPath") { }
        public introduction(string path)
        {
            InitializeComponent();
            InitializeWindow();
            InitializeParams(path);
            InitializeLabels();
        }
        private void InitializeWindow()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void InitializeLabels() // изменение координаты Y
        {
            int x = 20, y = 20, labelHeight = 30, spacing = 10;
            foreach (string depo in DEPO)
            {
                Label label = new Label();
                label.Text = depo;
                label.Location = new Point(x, y);
                label.Size = new Size(660, labelHeight);
                label.ForeColor = Color.Black;
                y += labelHeight + spacing;
                label.Font = new Font("Segoe Script", 14);
                this.Controls.Add(label);
            }
        }
        // Чтобы label координату задать label.Location = New System.Drawing.Pont( x; y );
        //Добавлять дополнительны координаты для Y
        private void InitializeParams(string path)
        {
            button2.Hide();
            GlobalVariables.player.Play("C:\\Users\\User\\source\\repos\\Mixim99RUS\\WindowsFormsApp1\\Music\\MainMenu.wav");
            //string json = File.ReadAllText(path);
            //DEPO = JsonConvert.DeserializeObject<List<string>>(json);

            DEPO = new List<string>();
            DEPO.Add("Типа что-то");
            DEPO.Add("Тото");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            Thread thread;
            foreach (Control depo in this.Controls)
            {
                if(!(depo is Label))
                {
                    continue;
                }
                thread = new Thread(new ParameterizedThreadStart(ShowTitle));
                thread.Start(depo);
            }
            button2.Show();
        }
        private void ShowTitle(object o)
        {
            Label nowLab = (Label)o;

            for (int i = 0; i < 255; i++)
            {
                nowLab.ForeColor = Color.FromArgb(i, i, i);
                Thread.Sleep(13);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }





}
