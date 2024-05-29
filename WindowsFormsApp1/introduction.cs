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
        private WaveOutEvent waveOut; // непосредственно инициализирует воспроизведение мелодию 
        private AudioFileReader audioFileReader; // для считывания аудиофайла
        int volume;
        Game game;

        byte[] audioBytesMainMenu = WindowsFormsApp1.Properties.Resources.Introduction;
        MemoryStream audioStreamMainMenu;
        Mp3FileReader mp3FileReader;


        public introduction(int volume)
        {
            InitializeComponent();
            labels.Add(Introd1);
            labels.Add(Introd2);
            labels.Add(Introd3);
            labels.Add(Introd4);
            labels.Add(Introd5);
            this.volume = volume;
            MusicPlay();
            button2.Hide();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            Thread thread;
            foreach (Label label in labels)
            {
                thread = new Thread(new ParameterizedThreadStart(ShowTitle));
                thread.Start(label);
                //thread.Join();
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
        private void MusicPlay()
        {
            if (waveOut == null)
            {
                audioStreamMainMenu = new MemoryStream(audioBytesMainMenu);

                mp3FileReader = new Mp3FileReader(audioStreamMainMenu);
                waveOut = new WaveOutEvent();
                waveOut.Init(mp3FileReader);

                waveOut.Volume = (float)volume / 100f; // чтобы воспроизводил громкость по умолчанию 
                // (1)waveOut.PlaybackStopped += (2)WaveOut_PlaybackStoppeed; - (1) событие остановки музыки (2) метод для повторного произведения
                waveOut.Play();
            }
            else
            {
                waveOut.Play();
            }

        }

        private void FormClose(object sender, FormClosedEventArgs e)
        {
            waveOut.Stop();
            waveOut.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game = new Game(volume);
            waveOut.Stop();
            waveOut.Dispose();
            game.ShowDialog();
            this.Close();
        }
    }
}
