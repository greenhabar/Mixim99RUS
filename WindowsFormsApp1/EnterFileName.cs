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
    public partial class EnterFileName : Form
    {
        public EnterFileName()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GlobalVariables.savefilename = textBox1.Text;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
