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
    public partial class Game : Form
    {
        
        int playerSpeed;
        int moveCheck;
        List<PictureBox> pictureBoxList;
        List<Trigger> triggerList;

        public int volume;
        public Game(int volume)
        {
            InitializeComponent();
            playerSpeed = 2;
            Player.BringToFront();

            this.volume = volume;
            pictureBoxList = new List<PictureBox> {pictureBox1, pictureBox2, pictureBox3,pictureBox4,pictureBox5,pictureBox6,pictureBox8 };
            triggerList = new List<Trigger>() { new Trigger(pictureBox9,
                3, x: 1000, y: 700,
                "C:/Users/Viktor/source/repos/Mixim99RUS/WindowsFormsApp1/Resources/c352b1b9801c11ee9607720ccb3e265f_upscaled.jpg") };
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }
        private bool CheckCollision(PictureBox entity)
        {
            if(!Player.Bounds.IntersectsWith(Player.Bounds) || Player.Top < Player.Top || Player.Right > Player.Right || Player.Bottom > Player.Bottom || Player.Left < Player.Left)
            {
                return true;
            }
            if (Player.Bounds.IntersectsWith(entity.Bounds))
            {
                return true;
            }
            return false;
        }
        private void CheckCollisionTrigger()
        {
            foreach (Trigger tr in triggerList)
            {
                if (Player.Bounds.IntersectsWith(tr.pic.Bounds))
                {
                    tr.ShowEvent();
                }
            }
        }
        private void UpMov_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 0)
                Player.Top -= playerSpeed;
            foreach (PictureBox pictureBox in pictureBoxList)
            {
                if (CheckCollision(pictureBox))
                {
                    Player.Top += playerSpeed;
                    return;
                }
            }
        }
        private void DownMov_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 1080)
                Player.Top += playerSpeed;
            foreach (PictureBox pictureBox in pictureBoxList)
            {
                if (CheckCollision(pictureBox))
                {
                    Player.Top -= playerSpeed;
                    return;
                }
            }
        }

        private void RightMov_Tick(object sender, EventArgs e)
        {
            if (Player.Left < 1920)
                Player.Left += playerSpeed;
            foreach (PictureBox pictureBox in pictureBoxList)
            {
                if (CheckCollision(pictureBox))
                {
                    Player.Left -= playerSpeed;
                    return;
                }
            }
        }

        private void LeftMov_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 0)
                Player.Left -= playerSpeed;
            foreach (PictureBox pictureBox in pictureBoxList)
            {
                if (CheckCollision(pictureBox))
                {
                    Player.Left += playerSpeed;
                    return;
                }
            }
        }

        private void Игра_KeyDown(object sender, KeyEventArgs e)
        {
            playerSpeed = 2;
            if (moveCheck != 0)
                return;
            if(e.KeyCode == Keys.Escape)
            {
                PauseMenu pauseMenu = new PauseMenu(this);
                pauseMenu.MusicOnOff += TrackChange;
                pauseMenu.ShowDialog();
            }
            if (e.KeyCode == Keys.Up)
            {
                if (Player.Image != Properties.Resources.IdleSisterBack)
                    Player.Image = Properties.Resources.IdleSisterBack;
                moveCheck = 1;
                UpMov.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                if (Player.Image != Properties.Resources.IdleSisterFront)
                    Player.Image = Properties.Resources.IdleSisterFront;
                moveCheck = 2;
                DownMov.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                if (Player.Image != Properties.Resources.IdleSisterRight)
                    Player.Image = Properties.Resources.IdleSisterRight;
                moveCheck = 3;
                RightMov.Start();
            }
            if (e.KeyCode == Keys.Left)
            {
                if (Player.Image != Properties.Resources.IdleSisterLeft)
                    Player.Image = Properties.Resources.IdleSisterLeft;
                moveCheck = 4;
                LeftMov.Start();
            }
            if (e.KeyCode == Keys.Z)
            {
                CheckCollisionTrigger();
            }
        }

        private void Игра_KeyUp(object sender, KeyEventArgs e)
        {
            moveCheck = 0;
            UpMov.Stop();
            RightMov.Stop();
            LeftMov.Stop();
            DownMov.Stop();
        }
        private void TrackChange(int a)
        {
            if(this.volume == 100)
            {
                volume = 0;
                MessageBox.Show("Музыка Off!");
            }
            else
            {
                volume = 100;
                MessageBox.Show("Музыка On!");
            }
        }
        private bool Trigger(int x, int y)
        {
            if (Player.Left > x - 20 && Player.Left <= x && Player.Top <= y && Player.Top > y - 20)
                return true;
            return false;
        }
        
        //private void SimpleEvents(int x, int y)
        //{
        //    if (simple_event && Trigger(x, y))
        //    {
        //        simple_event = false;
        //        playerSpeed = 0;
        //        MessageBox.Show("Произошло событие");
        //    }
        //}
    }
}
