using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public void SaveData(Scene form,string FileName)
        {
            MessageBox.Show("Saving");
            var pictureBoxesData = new List<PictureBoxData>();
            var trigersCordsData = new List<TrigerData>();
            var trigersInputData = new List<TrigerData>();
            PictureBoxData playerData = new PictureBoxData();

            foreach (PictureBox pb in form.Controls)
            {
                if( pb.Name == "Player")
                {
                    playerData.LocationX = pb.Location.X;
                    playerData.LocationY = pb.Location.Y;
                    playerData.Width = pb.Width;
                    playerData.Height = pb.Height;
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
                }) ;
            }
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
                trigersCordsData[trigersCordsData.Count - 1].pathToInt = pb.pathToInt;
            }
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
                trigersInputData[trigersInputData.Count - 1].pathToInt = pb.pathToInt;
            };

            var Data = new
            {
                player = playerData,
                PictureBoxes = pictureBoxesData,
                InputTrigers = trigersInputData,
                CordsTrigers = trigersCordsData,
                BackgroundImage = form.BackGroundPath
            };

            string json = JsonConvert.SerializeObject(Data);
            File.WriteAllText((FileName + "Data.txt"), json);
        }

        public void ReadScene(Scene form, string FileName)
        {
            DeleteAllPBox(form);
            string json = File.ReadAllText(FileName + "Data.txt");
            var Data = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (var pictureBox in Data.PictureBoxes)
            {
                PictureBox pb = new PictureBox();
                pb.Name = pictureBox.Name;
                pb.Location = new System.Drawing.Point(Convert.ToInt32(pictureBox.LocationX), Convert.ToInt32(pictureBox.LocationY));
                pb.Width = pictureBox.Width;
                pb.Height = pictureBox.Height;
                pb.Image = Properties.Resources.Empty;
                pb.BackColor = Color.Transparent;
                form.Controls.Add(pb);
                form.Colissions.Add(pb);
            }
            foreach(var Trig in Data.InputTrigers)
            {
                Triger tr = new Triger(new PictureBox(), Convert.ToInt32(Trig.type), Convert.ToBoolean(Trig.active), Convert.ToString(Trig.pathToInt));
                tr.pic.Name = Trig.PictureBoxData.Name;
                tr.pic.Location = new System.Drawing.Point(Convert.ToInt32(Trig.PictureBoxData.LocationX), Convert.ToInt32(Trig.PictureBoxData.LocationY));
                tr.pic.Width = Trig.PictureBoxData.Width;
                tr.pic.Height = Trig.PictureBoxData.Height;
                tr.pic.Image = Properties.Resources.Empty;
                tr.pic.BackColor = Color.Transparent;

                form.Controls.Add(tr.pic);
                form.TrigerInput.Add(tr);
            }

            foreach (var Trig in Data.CordsTrigers)
            {
                Triger tr = new Triger(new PictureBox(), Convert.ToInt32(Trig.type), Convert.ToBoolean(Trig.active), Convert.ToString(Trig.pathToInt));
                tr.pic.Name = Trig.PictureBoxData.Name;
                tr.pic.Location = new System.Drawing.Point(Convert.ToInt32(Trig.PictureBoxData.LocationX), Convert.ToInt32(Trig.PictureBoxData.LocationY));
                tr.pic.Width = Trig.PictureBoxData.Width;
                tr.pic.Height = Trig.PictureBoxData.Height;
                tr.pic.Image = Properties.Resources.Empty;
                tr.pic.BackColor = Color.Transparent;

                form.Controls.Add(tr.pic);
                form.TrigerCords.Add(tr);
            }

            foreach (Control control in form.Controls)
            {
                if (control is PictureBox && control.Name == "Player")
                {
                    control.Width = Data.player.Width;
                    control.Height = Data.player.Height;
                    control.Location = new Point(Convert.ToInt32(Data.player.LocationX), Convert.ToInt32(Data.player.LocationY));
                    break;
                }
            }

            form.BackgroundImage = Image.FromFile(Convert.ToString(Data.BackgroundImage));



            MessageBox.Show("Load complete");
        }
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
        //Delete
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
        public string pathToInt { get; set; }
    }
    //Delete
    
}
