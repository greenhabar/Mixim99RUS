﻿using System;
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

        int volume;
        int sound;
        int character;
        bool simple_event = true;

        void SetPictureToCenter()
        {
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
        }

        public Game(int volume, int sound, int character)
        {
            InitializeComponent();
            playerSpeed = 2;
            Player.BringToFront();

            this.volume = volume;
            this.sound = sound;
            this.character = character;
            pictureBoxList = new List<PictureBox> { new PictureBox() };
            SetPictureToCenter();
            //pictureBoxList = new List<PictureBox> { pictureBox1, pictureBox3 };
        }
        private bool CheckCollision(PictureBox entity)
        {
            this.Text = $"Pl = {Player.Bottom}, PB = {pictureBox1.Bottom}";
            if(!Player.Bounds.IntersectsWith(pictureBox1.Bounds) || Player.Top < pictureBox1.Top || Player.Right > pictureBox1.Right || Player.Bottom > pictureBox1.Bottom || Player.Left < pictureBox1.Left)
            {
                return true;
            }
            if (Player.Bounds.IntersectsWith(entity.Bounds))
            {
                return true;
            }
            return false;
        }
        private void UpMov_Tick(object sender, EventArgs e)
        {

            if (Player.Top > 10)
                Player.Top -= playerSpeed;

            SimpleEvents(863, 400);
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
            
            if (Player.Top < 1000)
                Player.Top += playerSpeed;
            SimpleEvents(863, 400);
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
         
            if (Player.Left < 1000)
            {
                Player.Left += playerSpeed;
            }
            SimpleEvents(863, 400);
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
            
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
            SimpleEvents(863, 400);
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
        }

        private void Игра_KeyUp(object sender, KeyEventArgs e)
        {
            //На стоячее положение изменять спрайт

            moveCheck = 0;
            UpMov.Stop();
            RightMov.Stop();
            LeftMov.Stop();
            DownMov.Stop();
        }
        private bool Trigger(int x, int y)
        {
            if (Player.Left > x - 20 && Player.Left <= x && Player.Top <= y && Player.Top > y - 20)
                return true;
            return false;
        }
        private void SimpleEvents(int x, int y)
        {
            if (simple_event && Trigger(x, y))
            {
                simple_event = false;
                playerSpeed = 0;
                MessageBox.Show("Произошло событие");
            }
        }
    }
}
