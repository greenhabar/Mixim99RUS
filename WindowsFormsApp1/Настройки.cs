using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Настройки : Form
    {
        int height;
        int width;
        List<int> resolution = new List<int> // Высота и ширина 
        {
            640,360,
            1280, 720,
            1920, 1080
            
        };
        
        public event Action<int> MusicChanged;
        public event Action<int> SoundChanged;
        public event Action<int> VoiceChanged;
        public Настройки(int volume, int volumecharacter, int volumesounds)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width; // экран настроек был изначально в нужном положении
            trackBar5.Value = volume; // для того, чтобы не начинался с ноля
            trackBar3.Value = volumesounds;
            trackBar4.Value = volumecharacter;
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

       

        
        private void tabPage2_Click(object sender, EventArgs e) // настройка звука
        {

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
    }
}

// ? - проверка ивента (изменилось ли?) Invoke - связь между окнами и передача значения TrackBar