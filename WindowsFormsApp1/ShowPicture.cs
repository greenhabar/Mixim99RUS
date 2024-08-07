using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ShowPicture : Form
    {
        public ShowPicture(string path)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(path);
        }

        private void Click(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
