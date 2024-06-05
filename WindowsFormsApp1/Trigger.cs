using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Trigger
    {
        public PictureBox pic;
        public bool active;
        public int type;
        public string path;

        public Trigger(PictureBox pic, int type, string path)
        {
            this.pic = pic;
            this.type = type;
            this.path = path;
        }

        public void ShowEvent()
        {
            switch (type)
            {
                case 1:
                    Console.WriteLine("Смена локации");
                    // вызов функции ReadJson()
                    break;
                case 2:
                    Console.WriteLine("Всплывает диалог");
                    // вызов функции ReadJson()
                    break;
                case 3:
                    Console.WriteLine("Всплывает картинка");
                    // вызов функции ReadJson()
                    break;
            }
        }

    }
}
