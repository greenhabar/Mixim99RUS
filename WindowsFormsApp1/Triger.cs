﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
         
            id Действий:
            1 - ИзменениеСостоянияТригера
            2 - ЗагрузкаДиалога
         */
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
        /*
         * 
         * Кодификатор диалога:
         * |id Действия|ПутьДоФайлаДиалога|ПутьДоФайлаСВыбором
         * 
         */
        //DELETE
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
                //Переделать под кодификатор
                case 1: //загрузка локи
                    GlobalVariables.locationId = Convert.ToInt32(Code);
                    GlobalVariables.WorkWithJSON.LoadLocation(scene, GlobalVariables.locationId);
                    break;
                //case 2:
                //    MessageBox.Show("Всплывает диалог");
                //    break;
                //case 3:
                //    MessageBox.Show("Всплывает картинка");
                //    break;
                case 2:
                    CodifyInteraction();
                    break;
            }
        }
        public void CodifyInteraction()
        {
            string[] result = Code.Trim('|').Split('|');
            //Переделать Case1
            switch(result[0])
            {
                case "1":
                    if (result[2] == "INP")
                    {
                        changeActivity(GlobalVariables.locations[Convert.ToInt32(result[1])].TrigerInputs, result[3], result[4]);
                    }
                    else
                    {
                        changeActivity(GlobalVariables.locations[Convert.ToInt32(result[1])].TrigerCords, result[3], result[4]);
                    }
                    break;
                case "2":

                    //| id Действия | ПутьДоФайлаДиалога | ПутьДоФайлаСВыбором

                    while (true)
                    {

                        GlobalVariables.dialogForm.ReadJson(result[1]);
                        GlobalVariables.dialogForm.ShowDialog();

                        if (result[2] != "NULL")
                        {
                            GlobalVariables.selectForm = new SelectForm(result[2]);
                            GlobalVariables.selectForm.ShowDialog();
                            result[1] = GlobalVariables.Temp;
                            result[2] = "NULL";
                        }
                        else
                        {
                            break;
                        }
                     }


                    break;
            }

        }
        private void changeActivity(List<TrigerData> trigList, string PBname, string active)
        {
            foreach (TrigerData data in trigList)
            {
                if (data.PictureBoxData.Name == PBname)
                {
                    data.active = active == "0" ? false : true;
                    break;
                }
            }
        }
    }
}
