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
    public partial class SelectForm : Form
    {

        public List<SelectItem> Selects;

        public SelectForm()
        {
            InitializeComponent();
            InitForm();
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            
            this.Selects = new List<SelectItem>();

            Selects.Add(new SelectItem("aa", 1, "fe"));
            Selects.Add(new SelectItem("ab", 1, "fe"));
            Selects.Add(new SelectItem("ac", 1, "fe"));

            initButtons();
        }
        public SelectForm(string js)
        {
            InitializeComponent();
            InitForm();
            var FileData = File.ReadAllText(js);
            Selects = JsonConvert.DeserializeObject<List<SelectItem>>(FileData);
            Selects.Add(new SelectItem("Третий Выбор", 1, "fe"));
            initButtons();
        }
        public void InitForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
        }
        public void initButtons()
        {
            int yloc = 20;
            int xloc = 20;
            for(int i = 0; i < Selects.Count(); i++)
            {
                BeutifulButton defaultbut = new BeutifulButton();
                defaultbut.Size = new System.Drawing.Size(570, 40);
                
                defaultbut.Font = new Font("Segoe Script", 14);

                defaultbut.Text = Selects[i].Text;

                defaultbut.Location = new System.Drawing.Point(20,yloc) ;
                switch ((i+1))
                {
                    case 1:
                        defaultbut.Click += new EventHandler(But1_Click);
                        break;
                    case 2:
                        defaultbut.Click += new EventHandler(But2_Click);
                        break;
                    case 3:
                        defaultbut.Click += new EventHandler(But3_Click);
                        break;
                }
                this.Controls.Add(defaultbut);
                yloc += 50;
                xloc += 50;
            }
        }
        public void But1_Click(object sender, EventArgs e)
        {
            GlobalVariables.reputation += Selects[0].Rep;
            closeSelect(Selects[0].NextDialog);
        }
        public void But2_Click(object sender, EventArgs e)
        {
            GlobalVariables.reputation += Selects[1].Rep;
            closeSelect(Selects[1].NextDialog);
        }
        public void But3_Click(object sender, EventArgs e)
        {
            GlobalVariables.reputation += Selects[2].Rep;
            closeSelect(Selects[2].NextDialog);
        }
        public void closeSelect(string path)
        {
            GlobalVariables.Temp = path;
            this.Close();
        }

        
        public class SelectItem
        {
            public string Text;
            public int Rep;
            public string NextDialog = "NULL";

            public SelectItem(string t, int r, string d)
            {
                this.Text = t;
                this.Rep = r;
                this.NextDialog = d;
            }
        }
    }
}
