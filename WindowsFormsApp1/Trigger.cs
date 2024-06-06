using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Trigger(PictureBox pic, int type, int x, int y, string path)
        {
            this.pic = pic;
            this.type = type;
            this.path = path;
            active = true;
            pic.Image = Image.FromFile(path);
            pic.Top = y;
            pic.Left = x;
        }

        public void ShowEvent()
        {
            switch (type)
            {
                case 1:
                    MessageBox.Show("Смена локации");
                    active = false;
                    // вызов функции ReadJson()
                    break;
                case 2:
                    MessageBox.Show("Всплывает диалог");
                    active = false;
                    // вызов функции ReadJson()
                    break;
                case 3:
                    MessageBox.Show("Всплывает картинка");
                    active = false;
                    // вызов функции ReadJson()
                    break;
            }
        }

    }
}
