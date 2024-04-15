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
        Settings sett;
        introduction game;
        
        
        //Запуск begin;

        //Introduction nt;

        public int volume = 50; // громкость музыки
        public int volumecharacter = 50; // громкость персонажа
        public int volumesounds = 50; // громкость звуков

        private WaveOutEvent waveOut; // непосредственно инициализирует воспроизведение мелодию
        private WaveOutEvent waveOut2; // непосредственно инициализирует воспроизведение мелодию



        public MainMenu()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e) // переход на форму запуска игры 
        {
           // DoClick();
            this.Hide();
            waveOut.Stop();
            game = new introduction(volume,volumesounds,volumecharacter);
            game.ShowDialog();
            this.Show();
            waveOut.Play();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            //DoClick();
            this.Hide(); // скрывает главное меню 
            sett = new Settings(volume, volumecharacter, volumesounds);
            sett.MusicChanged += TrackChange;
            sett.SoundChanged += SoundChange;
            sett.VoiceChanged += VoiceChange;
            sett.ShowDialog();
        }
        private void TrackChange(int Mus) // используем для отслеживания и изменения громесоти или подписка на изменения
        {
            volume = Mus;
            if(waveOut != null)
            {
                waveOut.Volume = (float)volume / 100f;
            }
        }

        private void SoundChange(int Sou)
        {
            volumesounds = Sou;
        }

        private void VoiceChange (int Charac)
        {
            volumecharacter = Charac;
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
            {
                waveOut.Play();
            }

        }

        private void button5_Click(object sender, EventArgs e) // выход из игры 
        {
            //DoClick();
            Thread.Sleep(100);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DoClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DoClick();
        }

        //private void DoClick()
        //{
        //    byte[] mainmusicByte = Properties.Resources.ButtonClick;
        //    MemoryStream memoryStream = new MemoryStream(mainmusicByte);
        //    Mp3FileReader readerBase = new Mp3FileReader(memoryStream);

        //    waveOut2 = new WaveOutEvent();
        //    waveOut2.Init(readerBase);

        //    waveOut2.PlaybackStopped += (s, args) =>
        //    {
        //        readerBase.Position = 0;
        //    };
        //    waveOut2.Play();
        //}

    }
}
