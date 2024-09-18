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
    public partial class PauseMenu : Form
    {
        Scene mother;
        public event Action<int> MusicOnOff;
        public PauseMenu(Scene g)
        {
            InitializeComponent();
            this.mother = g;
            pictureBox2.SendToBack();
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new Point(0, 0);

            CurrentTask.Text = GlobalVariables.task;

        }

        private void Resume_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MusicSwitch_Click(object sender, EventArgs e)
        {
            MusicOnOff?.Invoke(1);
        }
        private void Load_Click(object sender, EventArgs e)
        {

        }
        private void Save_Click(object sender, EventArgs e)
        {

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            mother.Close();
            this.Close();
        }
    }
}
