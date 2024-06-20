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
using static WindowsFormsApp1.PlayerSprites;

namespace WindowsFormsApp1
{
    public partial class Scene : Form
    {
        //Инициализатор Блок
        int playerSpeed;

        PlayerSprites playerSprites;

        List<PictureBox> pictureBoxList;
        List<Triger> TrigerInput;//по нажатию
        List<Triger> TrigerCords;//по коорднате

        MovementState moveCheck;

        public Scene()
        {
            InitializeComponent();

            playerSpeed = 2;
            Player.BringToFront();
            playerSprites = new PlayerSprites(0,0);

            pictureBoxList = new List<PictureBox> {pictureBox1, pictureBox2,pictureBox3,pictureBox4,pictureBox5,pictureBox6,pictureBox8 };
            TrigerInput = new List<Triger> { new Triger(triger,1)};
            TrigerCords = new List<Triger> { new Triger(triger2,2)};

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        //Check Блок
        private bool CheckCollision(PictureBox entity)
        {
            CheckCollisionTrigger(TrigerCords);
            return Player.Bounds.IntersectsWith(entity.Bounds);
        }
        private void CheckCollisionTrigger(List<Triger> Trigers)
        {
            foreach (Triger tr in Trigers)
            {
                if (Player.Bounds.IntersectsWith(tr.pic.Bounds))
                    tr.ShowEvent();
            }
        }

        //Move Блок
        private MovementState OppositeDirection(MovementState direction)
        {
            switch (direction)
            {
                case MovementState.Up: return MovementState.Down;
                case MovementState.Down: return MovementState.Up;
                case MovementState.Left: return MovementState.Right;
                case MovementState.Right: return MovementState.Left;
                default: return MovementState.None;
            }
        }
        private void MovePlayer(MovementState direction)
        {
            switch (direction)
            {
                case MovementState.Up:
                    if (Player.Top > 0) Player.Top -= playerSpeed;
                    break;
                case MovementState.Down:
                    if (Player.Top < 1080) Player.Top += playerSpeed;
                    break;
                case MovementState.Left:
                    if (Player.Left > 0) Player.Left -= playerSpeed;
                    break;
                case MovementState.Right:
                    if (Player.Left < 1920) Player.Left += playerSpeed;
                    break;
            }

            foreach (PictureBox pictureBox in pictureBoxList)
            {
                if (CheckCollision(pictureBox))
                {
                    // Отменить движение
                    MovePlayer(OppositeDirection(direction));
                    return;
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            MovePlayer(moveCheck);
        }

        //Input блок
        private void Игра_KeyDown(object sender, KeyEventArgs e)
        {
            //playerSpeed = 2;
            if (moveCheck != MovementState.None)
                return;

            switch (e.KeyCode)
            {
                case Keys.Z:
                    CheckCollisionTrigger(TrigerInput); 
                    break;
                case Keys.Escape:
                    PauseMenu pauseMenu = new PauseMenu(this);
                    pauseMenu.MusicOnOff += TrackChange;
                    pauseMenu.ShowDialog();
                    break;
                case Keys.Up:
                    moveCheck = MovementState.Up;
                    break;
                case Keys.Down:
                    moveCheck = MovementState.Down;
                    break;
                case Keys.Left:
                    moveCheck = MovementState.Left;
                    break;
                case Keys.Right:
                    moveCheck = MovementState.Right;
                    break;
                
            }
            Player.Image = playerSprites.GetCurrentSprite(moveCheck);
            Timer.Start();
        }
        private void Игра_KeyUp(object sender, KeyEventArgs e)
        {
            moveCheck = MovementState.None;
            Player.Image = playerSprites.GetCurrentSprite(moveCheck);
        }
        //PauseInput Блок
        private void TrackChange(int a)
        {
            GlobalVariables.player.ChangeVolume();
        }
    }
}
