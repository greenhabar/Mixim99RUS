using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForm
{
    public partial class Form1 : Form
    {
        List<Label> labels = new List<Label>();
        public Form1()
        {
            InitializeComponent();
            labels.Add(Introd1);
            labels.Add(Introd2);
            labels.Add(Introd3);
            labels.Add(Introd4);
            labels.Add(Introd5);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            Thread thread;
            foreach (Label label in labels)
            {
                thread = new Thread(new ParameterizedThreadStart(ShowTitle));
                thread.Start(label);
                thread.Join();
            }
            this.Close();
        }
        private void ShowTitle(object o)
        {
            Label nowLab = (Label)o;

            for(int i = 0; i<255; i++)
            {
                nowLab.ForeColor = Color.FromArgb(i,i,i);
                Thread.Sleep(13);
            }
        }
    }
}
