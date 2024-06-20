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
using WindowsFormsApp1;

namespace GameForm
{
    public partial class introduction : Form
    {
        List<Label> labels = new List<Label>();
        Game game;
        public introduction()
        {
            InitializeComponent();
            InitializeWindow();
            InitializeParams();
        }
        private void InitializeWindow()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void InitializeParams()
        {
            labels.Add(Introd1);
            labels.Add(Introd2);
            labels.Add(Introd3);
            labels.Add(Introd4);
            labels.Add(Introd5);
            button2.Hide();
            GlobalVariables.player.Play(WindowsFormsApp1.Properties.Resources.Introduction1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            Thread thread;
            foreach (Label label in labels)
            {
                thread = new Thread(new ParameterizedThreadStart(ShowTitle));
                thread.Start(label);
            }
            button2.Show();
        }
        private void ShowTitle(object o)
        {
            Label nowLab = (Label)o;

            for(int i = 0; i<255; i++)
            {
                nowLab.ForeColor = Color.FromArgb(i,i,i);
                Thread.Sleep(13);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            game = new Game(GlobalVariables.volume ? 1:0);
            
            game.ShowDialog();
            this.Close();
        }
    }
}
