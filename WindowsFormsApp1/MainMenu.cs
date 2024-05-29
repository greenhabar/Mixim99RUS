using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameForm;
using NAudio.Wave;


namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        introduction game;
        public int volume = 100; // громкость музыки

        private WaveOutEvent waveOut; // непосредственно инициализирует воспроизведение мелодию

        public MainMenu()
        {
            InitializeComponent();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void Button1_Click(object sender, EventArgs e) // переход на форму запуска игры 
        {
            this.Hide();
            waveOut.Stop();
            game = new introduction(volume);
            game.ShowDialog();
            this.Show();
            waveOut.Play();
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            if(volume == 100)
                volume = 0;
            else
                volume = 100;
            if (waveOut != null)
                waveOut.Volume = (float)volume / 100f;
        }
        private void MusicPlay(object sender, EventArgs e)
        {
            if (waveOut == null)
            {
                byte[] mainmusicByte = Properties.Resources.MainMenu;
                MemoryStream memoryStream = new MemoryStream(mainmusicByte);
                Mp3FileReader readerBase = new Mp3FileReader(memoryStream);

                waveOut = new WaveOutEvent();
                waveOut.Init(readerBase);

                waveOut.Play();
            }
            else
                waveOut.Play();
        }

        private void button5_Click(object sender, EventArgs e) // выход из игры 
        {
            Thread.Sleep(100);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //LoadGame
        {
            
        }

        private void button4_Click(object sender, EventArgs e) // Authors
        {
            
        }

    }
}
