using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
    public partial class Главноеменю : Form
    {
        Настройки sett;
        Вступление game;
        
        
        //Запуск begin;

        //Introduction nt;

        public int volume = 50; // громкость музыки
        public int volumecharacter = 50; // громкость персонажа
        public int volumesounds = 50; // громкость звуков
        private WaveOutEvent waveOut; // непосредственно инициализирует воспроизведение мелодию
        public WaveOutEvent waveOut2;                              // 
        private AudioFileReader audioFileReader; // для считывания аудиофайла
        public Главноеменю()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    // Загрузка изображения персонажа
        //    Bitmap bitmap = new Bitmap("path_to_character_image.jpg");
             
        //    // Отображение изображения в PictureBox
        //    pictureBox1.Image = bitmap;
        //}

        private void Button1_Click(object sender, EventArgs e) // переход на форму запуска игры 
        {
            DoClick();
            this.Hide();
            waveOut.Stop();
            game = new Вступление(volume,volumesounds,volumecharacter);
            game.ShowDialog();
            this.Show();
            waveOut.Play();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            DoClick();
            this.Hide(); // скрывает главное меню 
            sett = new Настройки(volume,volumecharacter,volumesounds);
            sett.MusicChanged += TrackChange;
            sett.SoundChanged += SoundChange;
            sett.VoiceChanged += VoiceChange;
            sett.ShowDialog();
            this.Show();
            
        }
        private void TrackChange(int Mus) // используем для отслеживания и изменения громесоти или подписка на изменения
        {
            volume = Mus;
            if (waveOut != null)
            {
                waveOut.Volume = (float)volume / 100f; //  waveOut.Volume  воспринимает от 0 до 1 float - делает одно число дробным делим на 100, чтобы не нарушать условия (от 0 до 1)
            }
        }

        private void SoundChange (int Sou)
        {
            volumesounds = Sou;
            if (waveOut2 != null)
            {
                waveOut2.Volume = (float)volume / 100f;
            }
        }

        private void VoiceChange (int Charac)
        {
            volumecharacter = Charac;
        }

        private void MusicPlay(object sender, EventArgs e)
        {
            if (waveOut == null)
            {
                //waveOut = new WaveOutEvent();

                //------------------------

                byte[] audioBytesMainMenu = Properties.Resources.MainMenu;
                
                MemoryStream audioStreamMainMenu = new MemoryStream(audioBytesMainMenu);
                
                Mp3FileReader mp3FileReader = new Mp3FileReader(audioStreamMainMenu);
                waveOut = new WaveOutEvent();
                waveOut.Init(mp3FileReader);

                waveOut.Play();

                waveOut.Volume =(float) volume / 100f;
            }
            else
            {
                waveOut.Play();
            }

        }

        private void button5_Click(object sender, EventArgs e) // выход из игры 
        {
            DoClick();
            Thread.Sleep(100);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DoClick();
        }

        private void DoClick()
        {
            byte[] audioBytesClick = Properties.Resources.ButtonClick;
            MemoryStream audioStreamClick = new MemoryStream(audioBytesClick);
            Mp3FileReader mp3FileReader = new Mp3FileReader(audioStreamClick);
            waveOut2 = new WaveOutEvent();
            waveOut2.Init(mp3FileReader);
            waveOut2.Volume = (float)volumesounds / 100f;
            waveOut2.Play();
        }

    }
}
