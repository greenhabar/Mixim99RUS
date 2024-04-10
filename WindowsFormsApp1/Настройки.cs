using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Настройки : Form
    {
        public WaveOutEvent waveOut2;
        public event Action<int> MusicChanged;
        public event Action<int> SoundChanged;
        public event Action<int> VoiceChanged;
        public Настройки(int volume, int volumecharacter, int volumesounds)
        {
            InitializeComponent();
            trackBar5.Value = volume; // для того, чтобы не начинался с ноля
            trackBar3.Value = volumesounds;
            trackBar4.Value = volumecharacter;
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {
            DoClick();
        }
        
        private void tabPage2_Click(object sender, EventArgs e) // настройка звука
        {
            DoClick();
        }

        private void trackBar4_Scroll(object sender, EventArgs e) // громкость персонажей
        {
            VoiceChanged?.Invoke(trackBar4.Value); 
        }

        private void trackBar3_Scroll(object sender, EventArgs e) // громкость звука 
        {
            SoundChanged?.Invoke(trackBar3.Value);
        }
        private void TrackBar5_Scroll(object sender, EventArgs e) // громкость музыки
        {
            MusicChanged?.Invoke(trackBar5.Value); // Invoke - связующее между двумя процессами
        }
        private void Button1_Click(object sender, EventArgs e) // кнопка возвращения в главное меню 
        {
            DoClick();
            this.Hide();
            Главноеменю главноеменю = (Главноеменю)Application.OpenForms[0];
            главноеменю.Show();
        }

        private void ResolutionDown_Click(object sender, EventArgs e)
        {

        }

        private void ResolutionUp_Click(object sender, EventArgs e)
        {

        }

        private void ScreenResolution_TextChanged(object sender, EventArgs e)
        {

        }


        private void DoClick()
        {
            byte[] audioBytesClick = Properties.Resources.ButtonClick;
            MemoryStream audioStreamClick = new MemoryStream(audioBytesClick);
            Mp3FileReader mp3FileReader = new Mp3FileReader(audioStreamClick);
            waveOut2 = new WaveOutEvent();
            waveOut2.Init(mp3FileReader);
            waveOut2.Volume = (float)trackBar3.Value / 100f;
            waveOut2.Play();
        }

    }
}

// ? - проверка ивента (изменилось ли?) Invoke - связь между окнами и передача значения TrackBar