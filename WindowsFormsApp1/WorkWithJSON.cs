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

namespace WindowsFormsApp1
{
    public class WorkWithJSON
    {
        public void SaveData(Scene form,string FileName)
        {
            var pictureBoxesData = new List<PictureBoxData>();
            var trigersCordsData = new List<TrigerData>();
            var trigersInputData = new List<TrigerData>();
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
            MessageBox.Show(pictureBoxesData[0].Name.ToString());
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
            }

            PictureBoxData Pl = new PictureBoxData();

            var CollisionData = new
            {
                PictureBoxes = pictureBoxesData,
                BackgroundImage = form.BackgroundImage != null ? form.BackgroundImage.Tag?.ToString() : null,
            };
            var TrigersData = new
            {
                InputTrigers = trigersInputData,
                CordsTrigers = trigersCordsData
            };
            string json = JsonConvert.SerializeObject(CollisionData);
            File.WriteAllText((FileName + "ColData.txt"), json);
            string json2 = JsonConvert.SerializeObject(TrigersData);
            File.WriteAllText((FileName + "TrigData.txt"), json2);
        }

        public void ReadScene(Scene form, string FileName)
        {
            DeleteAllPBox(form);
            string json = File.ReadAllText(FileName + "ColData.txt");
            var CollisionsData = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (var pictureBox in CollisionsData.PictureBoxes)
            {
                PictureBox pb = new PictureBox();
                pb.Name = pictureBox.Name;
                pb.Location = new System.Drawing.Point(Convert.ToInt32(pictureBox.LocationX), Convert.ToInt32(pictureBox.LocationY));
                pb.Width = pictureBox.Width;
                pb.Height = pictureBox.Height;
                pb.ImageLocation = pictureBox.Image;
                form.Controls.Add(pb);
                form.Colissions.Add(pb);
            }

            json = File.ReadAllText(FileName + "TrigData.txt");
            var CollisionsData2 = JsonConvert.DeserializeObject<dynamic>(json);

            foreach(var Trig in CollisionsData2.InputTrigers)
            {
                Triger tr = new Triger(new PictureBox(), Convert.ToInt32(Trig.type), Convert.ToBoolean(Trig.active));
                tr.pic.Name = Trig.PictureBoxData.Name;
                tr.pic.Location = new System.Drawing.Point(Convert.ToInt32(Trig.PictureBoxData.LocationX), Convert.ToInt32(Trig.PictureBoxData.LocationY));
                tr.pic.Width = Trig.PictureBoxData.Width;
                tr.pic.Height = Trig.PictureBoxData.Height;
                tr.pic.ImageLocation = Trig.PictureBoxData.Image;

                form.Controls.Add(tr.pic);
                form.TrigerInput.Add(tr);
            }

            foreach (var Trig in CollisionsData2.CordsTrigers)
            {
                Triger tr = new Triger(new PictureBox(), Convert.ToInt32(Trig.type), Convert.ToBoolean(Trig.active));
                tr.pic.Name = Trig.PictureBoxData.Name;
                tr.pic.Location = new System.Drawing.Point(Convert.ToInt32(Trig.PictureBoxData.LocationX), Convert.ToInt32(Trig.PictureBoxData.LocationY));
                tr.pic.Width = Trig.PictureBoxData.Width;
                tr.pic.Height = Trig.PictureBoxData.Height;
                tr.pic.ImageLocation = Trig.PictureBoxData.Image;

                form.Controls.Add(tr.pic);
                form.TrigerCords.Add(tr);
            }

            MessageBox.Show("Я СЧИТАЛ ВСЕ ЭТО, ПРИКИНЬ?!?!?!?!?!?");
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
    
}
