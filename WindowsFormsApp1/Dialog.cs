using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();
            InitForm();
        }
        public void InitForm()
        {
            this.StartPosition = FormStartPosition.Manual;

            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int y = Screen.PrimaryScreen.WorkingArea.Height- this.Height;

            this.Location = new Point(x, y);

            this.FormBorderStyle = FormBorderStyle.None;
            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.White;

        }

        List<DialogStr> Data;
        public int i = 0;

        public void ReadJson(string path)
        {

            string PAth = "C:\\Users\\User\\Desktop\\⠀⠀⠀⠀\\Folders\\JsonWriterDialog\\TEST.json";

            var FileData = File.ReadAllText(PAth);
            Data = JsonConvert.DeserializeObject<List<DialogStr>>(FileData);

            ShowDialog();
        }
        public void ShowDialog()
        {
            ChName.Text = Data[i].Name;
            pictureBox1.Image = Image.FromFile("Resources\\" + Data[i].Icon);
            richTextBox1.Text = Data[i].Dialogue;
            i++;
        }

        public class DialogStr
        {
            public string Name { get; set; }
            public string Icon { get; set; }
            public string Dialogue { get; set; }
        }

        private void Dialog_KeyDown(object sender, KeyEventArgs e)
        {
            if(i != Data.Count)
            {
                ShowDialog();
            }
            else
            {
                this.Close();
            }
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                richTextBox1.SelectionLength = 0; // Убираем выделение
                richTextBox1.SelectionStart = richTextBox1.Text.Length; // Убираем курсор
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (i != Data.Count)
            {
                ShowDialog();
            }
            else
            {
                this.Close();
            }
        }
    }
}
