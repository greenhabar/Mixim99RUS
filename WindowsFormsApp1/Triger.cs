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
        public string Code;

        /*
            Кодификатор тригеров:
        |(id действия)|(id локации)|(Тип Тригера)|(Название тригера)|(состояние (1 или 0))|


            Типы тригеров:
            Inp - по нажатию
            Cor - по координате

            Пример:

            |1|Inp|InpTrig1|0

            Таким образом мы на локации 1 изменяем состояние тригера 
            по нажатию InpTrig1 на выставленное 0
         */
        /*
         
        == -

         */
        /*
          Player
          Col1,Col2...
          TrigInp1,...
          TrigCor1....
         */
        public Triger(PictureBox pic, int type)
        {
            this.pic = pic;
            this.type = type;
            active = true;
        }
        public Triger(PictureBox pic, int type,bool active,string Code)
        {
            this.pic = pic;
            this.type = type;
            this.active = active;
            this.Code = Code;
        }

        public void ShowEvent(Scene scene)
        {
            if(!active)
            {
                return;
            }
            switch (type)
            {
                case 1: //загрузка локи
                    GlobalVariables.locationId = Convert.ToInt32(Code);
                    GlobalVariables.WorkWithJSON.LoadLocation(scene, GlobalVariables.locationId);
                    break;
                case 2:
                    MessageBox.Show("Всплывает диалог");
                    break;
                case 3:
                    MessageBox.Show("Всплывает картинка");
                    break;
                case 4:
                    CodifyInteraction();
                    break;
            }
        }
        public void CodifyInteraction()
        {
            string[] result = Code.Trim('|').Split('|');

            switch(result[0])
            {
                case "1":
                    if (result[2] == "INP")
                    {
                        foreach (TrigerData data in GlobalVariables.locations[Convert.ToInt32(result[1])].TrigerInputs)
                        {
                            if(data.PictureBoxData.Name == result[3])
                            {
                                data.active = result[4] == "0" ? false : true;
                                break;
                            }
                        }
                        return;
                    }
                    else
                    {
                        foreach (TrigerData data in GlobalVariables.locations[Convert.ToInt32(result[1])].TrigerCords)
                        {
                            if (data.PictureBoxData.Name == result[3])
                            {
                                data.active = result[4] == "0" ? false : true;
                                break;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
