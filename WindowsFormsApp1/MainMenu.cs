﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameForm;
using NAudio.Wave;


namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        introduction game;
        public MainMenu()
        {
            InitializeComponent();
            InitializeWindow();
            InitializeParams();
        }
        private void InitializeWindow()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void InitializeParams()
        {
            GlobalVariables.volume = true;
            GlobalVariables.player = new AudioPlayer();
            GlobalVariables.player.Play(Properties.Resources.MainMenu1);
        }
        private void Button1_Click(object sender, EventArgs e) // переход на форму запуска игры 
        {
            this.Hide();
            game = new introduction();
            game.ShowDialog();
            this.Show();
            GlobalVariables.player.Play(Properties.Resources.MainMenu1);
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            GlobalVariables.player.ChangeVolume();
        }
        private void button5_Click(object sender, EventArgs e) // выход из игры 
        {
            Thread.Sleep(100);
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e) //LoadGame
        {
            
        }
        private void button4_Click(object sender, EventArgs e) // Authors
        {
            
        }

    }
}
