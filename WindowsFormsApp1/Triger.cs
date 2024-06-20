using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Triger
    {
        public PictureBox pic; //get set
        public bool active; // get set
        public int type; // get set
        public string path;

        public Triger(PictureBox pic, int type)
        {
            this.pic = pic;
            this.type = type;
            //this.path = path;
            active = true;
            //pic.Image = Image.FromFile(path);
            //pic.Top = 700;
            //pic.Left = 1000;
        }

        public void ShowEvent()
        {
            if(!active)
            {
                return;
            }
            switch (type)
            {
                case 1:
                    MessageBox.Show("Смена локации");
                    // вызов функции ReadJson()
                    break;
                case 2:
                    active = false;
                    MessageBox.Show("Всплывает диалог");
                    // вызов функции ReadJson()
                    break;
                case 3:
                    active = false;
                    MessageBox.Show("Всплывает картинка");
                    // вызов функции ReadJson()
                    break;
            }
        }
    }
}
