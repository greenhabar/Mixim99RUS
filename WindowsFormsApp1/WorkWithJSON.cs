using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace WindowsFormsApp1
{
    public class WorkWithJSON
    {
        private void DeleteAllPBox(Scene form)
        {
            form.Colissions.Clear();
            form.TrigerCords.Clear();
            form.TrigerInput.Clear();
            foreach(Control control in form.Controls)
            {
                if(control is PictureBox && control.Name != "Player")
                {
                    form.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }
        public void LocalSave(Scene form) //Локальное сохранение, текущей сессии, т.е сохраняются состояния тригеров в ТЕКУЩЕЙ сессии без возможности загрузки из файла
        {
            PictureBoxData playerData = new PictureBoxData();
            var trigersInputData = new List<TrigerData>();
            var trigersCordsData = new List<TrigerData>();
            var pictureBoxesData = new List<PictureBoxData>();

            foreach (PictureBox pb in form.Controls)
            {
                if (pb.Name == "Player")
                {
                    playerData.LocationX = pb.Location.X;
                    playerData.LocationY = pb.Location.Y;
                    playerData.Width = pb.Width;
                    playerData.Height = pb.Height;
                    break;
                }
            }
            
            foreach (PictureBox pb in form.Colissions)
            {
                pictureBoxesData.Add(new PictureBoxData
                {
                    Name = pb.Name,
                    LocationX = pb.Location.X,
                    LocationY = pb.Location.Y,
                    Width = pb.Width,
                    Height = pb.Height,
                    Image = pb.ImageLocation,
                    ArrayName = "Colissions"
                });
            }
            GlobalVariables.locations[GlobalVariables.locationId].Player = playerData;
            foreach (Triger pb in form.TrigerInput)
            {
                trigersInputData.Add(new TrigerData());
                trigersInputData[trigersInputData.Count - 1].PictureBoxData = new PictureBoxData
                {
                    Name = pb.pic.Name,
                    LocationX = pb.pic.Location.X,
                    LocationY = pb.pic.Location.Y,
                    Width = pb.pic.Width,
                    Height = pb.pic.Height,
                    Image = pb.pic.ImageLocation,
                    ArrayName = "TrigerInput"
                };
                trigersInputData[trigersInputData.Count - 1].active = pb.active;
                trigersInputData[trigersInputData.Count - 1].type = pb.type;
                trigersInputData[trigersInputData.Count - 1].Code = pb.Code;
            };
            foreach (Triger pb in form.TrigerCords)
            {
                trigersCordsData.Add(new TrigerData());
                trigersCordsData[trigersCordsData.Count - 1].PictureBoxData = new PictureBoxData
                {
                    Name = pb.pic.Name,
                    LocationX = pb.pic.Location.X,
                    LocationY = pb.pic.Location.Y,
                    Width = pb.pic.Width,
                    Height = pb.pic.Height,
                    Image = pb.pic.ImageLocation,
                    ArrayName = "TrigerCords"
                };
                trigersCordsData[trigersCordsData.Count - 1].active = pb.active;
                trigersCordsData[trigersCordsData.Count - 1].type = pb.type;
                trigersCordsData[trigersCordsData.Count - 1].Code = pb.Code;
            }

            GlobalVariables.locations[GlobalVariables.locationId].TrigerInputs = trigersInputData;
            GlobalVariables.locations[GlobalVariables.locationId].TrigerCords = trigersCordsData;
            GlobalVariables.locations[GlobalVariables.locationId].Colissions = pictureBoxesData;


        }
        public void Save(Scene form,string FileName) //Глобальное сохранение всей игровой информации в sfd файл
        {
            LocalSave(form);

            var PlayerData = new
            {
                locationId = GlobalVariables.locationId,
                inventory = GlobalVariables.inventory,
            };

            var SaveData = new
            {
                playerData = PlayerData,
                locations = GlobalVariables.locations,
            };

            string json = JsonConvert.SerializeObject(SaveData, Formatting.Indented);
            File.WriteAllText((GlobalVariables.defaultpath +"\\Saves\\"+ FileName + ".sfd"), json); //.sfd - Save File Data
        }
        public void Read(Scene form,string FileName) //здесь уже используется расширение(т.е sfd или dsdf для загрузки или новой игры, или уже начатой)
        {
            var FileData = File.ReadAllText(FileName);
            var Data = JsonConvert.DeserializeObject<jsonDataRead>(FileData);
            GlobalVariables.locations = Data.locations;
            GlobalVariables.inventory = Data.playerData.inventory;
            GlobalVariables.locationId = Data.playerData.locationId;

            LoadLocation(form, GlobalVariables.locationId);
        }
        public void LoadLocation(Scene form, int index)
        {
            DeleteAllPBox(form);
            foreach (Control control in form.Controls) //Загрузка позиции игрока
            {
                if (control is PictureBox && control.Name == "Player")
                {
                    control.Width = GlobalVariables.locations[index].Player.Width;
                    control.Height = GlobalVariables.locations[index].Player.Height;
                    control.Location = new Point(Convert.ToInt32(GlobalVariables.locations[index].Player.LocationX), Convert.ToInt32(GlobalVariables.locations[index].Player.LocationY));
                    break;
                }
            }
            foreach (var Col in GlobalVariables.locations[index].Colissions)
            {
                PictureBox pb = new PictureBox();
                pb.Name = Col.Name;
                pb.Location = new System.Drawing.Point(Convert.ToInt32(Col.LocationX), Convert.ToInt32(Col.LocationY));
                pb.Width = Col.Width;
                pb.Height = Col.Height;
                pb.Image = Properties.Resources.Empty;
                pb.BackColor = Color.Transparent;
                form.Controls.Add(pb);
                form.Colissions.Add(pb);
            }
            foreach (var Trig in GlobalVariables.locations[index].TrigerInputs)
            {
                Triger tr = new Triger(new PictureBox(), Convert.ToInt32(Trig.type), Convert.ToBoolean(Trig.active), Convert.ToString(Trig.Code));
                tr.pic.Name = Trig.PictureBoxData.Name;
                tr.pic.Location = new System.Drawing.Point(Convert.ToInt32(Trig.PictureBoxData.LocationX), Convert.ToInt32(Trig.PictureBoxData.LocationY));
                tr.pic.Width = Trig.PictureBoxData.Width;
                tr.pic.Height = Trig.PictureBoxData.Height;
                tr.pic.Image = Properties.Resources.Empty;
                tr.pic.BackColor = Color.Transparent;

                form.Controls.Add(tr.pic);
                form.TrigerInput.Add(tr);
            }
            foreach(var Trig in GlobalVariables.locations[index].TrigerCords)
            {
                Triger tr = new Triger(new PictureBox(), Convert.ToInt32(Trig.type), Convert.ToBoolean(Trig.active), Convert.ToString(Trig.Code));
                tr.pic.Name = Trig.PictureBoxData.Name;
                tr.pic.Location = new System.Drawing.Point(Convert.ToInt32(Trig.PictureBoxData.LocationX), Convert.ToInt32(Trig.PictureBoxData.LocationY));
                tr.pic.Width = Trig.PictureBoxData.Width;
                tr.pic.Height = Trig.PictureBoxData.Height;
                tr.pic.Image = Properties.Resources.CmT1;
                tr.pic.BackColor = Color.Transparent;

                form.Controls.Add(tr.pic);
                form.TrigerCords.Add(tr);
            }

            form.BackgroundImage = Image.FromFile(Convert.ToString(GlobalVariables.locations[index].BackGround));
            GlobalVariables.locationId = index;
            if (GlobalVariables.locations[index].AudioPath[GlobalVariables.locations[index].AudioPath.Length - 1] != '!') //ПЛОХО ОЧЕНЬ!!!!
            {
                GlobalVariables.player.Play(GlobalVariables.locations[index].AudioPath);
            }
        }

    }

    public class jsonDataRead
    {
        public PlayerData playerData { get; set; }
        public List<LocationData> locations { get; set; }
    }
    public class PlayerData
    {
        public int locationId { get; set; }
        public List<string> inventory { get; set; }
    }
    public class LocationData
    {
        public string BackGround {  get; set; } //сделать сохранение back'а
        public PictureBoxData Player { get; set; }
        public List<PictureBoxData> Colissions { get; set; }
        public List<TrigerData> TrigerCords { get; set; }
        public List<TrigerData> TrigerInputs { get; set; }
        public string AudioPath { get; set; }
    }
    public class PictureBoxData
    {
        public string Name { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Image { get; set; }
        public string ArrayName { get; set; }
    }
    public class TrigerData
    {
        public PictureBoxData PictureBoxData { get; set; }
        public bool active { get; set; }
        public int type { get; set; }
        public string Code { get; set; }
    }
    //Delete
}
