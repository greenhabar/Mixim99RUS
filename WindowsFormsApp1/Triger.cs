using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Triger
    {
        public PictureBox pic; //get set
        public bool active; // get set
        public int type; // get set
        public string pathToInt;

        public Triger(PictureBox pic, int type)
        {
            this.pic = pic;
            this.type = type;
            active = true;
        }
        public Triger(PictureBox pic, int type,bool active,string path)
        {
            this.pic = pic;
            this.type = type;
            this.active = active;
            this.pathToInt = path;
        }

        public void ShowEvent(Scene scene)
        {
            if(!active)
            {
                return;
            }
            switch (type)
            {
                case 1:
                    MessageBox.Show("Смена локации");
                    if(this.active)
                    {
                        GlobalVariables.WorkWithJSON.ReadScene(scene, pathToInt);
                    }
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
