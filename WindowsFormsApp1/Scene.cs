using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Windows.Input;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.PlayerSprites;
using static System.Runtime.CompilerServices.RuntimeHelpers;

//Доработать спринт

namespace WindowsFormsApp1
{
    public partial class Scene : Form
    {
        //Инициализатор Блок

        public string pathToImage;

        public string BackGroundPath;

        PlayerSprites playerSprites;
        
        public List<PictureBox> Colissions;
        public List<Triger> TrigerInput;//по нажатию
        public List<Triger> TrigerCords;//по коорднате

        bool dialogCheck = false;

        MovementState moveCheck;

        public Scene(string path)
        {
            InitializeComponent();
            InitializeForm();
            GlobalVariables.WorkWithJSON.Read(this,path);
        }
        public Scene(string path, string dialog)
        {
            InitializeComponent();
            InitializeForm();
            dialogCheck = true;
            GlobalVariables.WorkWithJSON.Read(this, path);
            GlobalVariables.dialogForm.ReadJson(dialog);
        }

        void InitializeForm()
        {
            GlobalVariables.WorkWithJSON = new WorkWithJSON();
            GlobalVariables.dialogForm = new Dialog();
            GlobalVariables.selectForm = new SelectForm();

            Colissions = new List<PictureBox>();
            TrigerCords = new List<Triger>();
            TrigerInput = new List<Triger>();

            this.DoubleBuffered = true;

            Player.BringToFront();
            playerSprites = new PlayerSprites(0, 0);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.BackGroundPath = "\\Resources\\ToiletTest.jpg";
            this.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + this.BackGroundPath);
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
                {
                    if(tr.active == false)
                    { return; }
                    MovementTimer.Stop();
                    moveCheck = MovementState.None;
                    tr.ShowEvent(this);
                    break;
                }
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
                    if (Player.Top > 0) Player.Top -= GlobalVariables.speed;
                    break;
                case MovementState.Down:
                    if (Player.Top < 1080) Player.Top += GlobalVariables.speed;
                    break;
                case MovementState.Left:
                    if (Player.Left > 0) Player.Left -= GlobalVariables.speed;
                    break;
                case MovementState.Right:
                    if (Player.Left < 1920) Player.Left += GlobalVariables.speed;
                    break;
            }

            foreach (PictureBox pictureBox in Colissions)
            {
                if (CheckCollision(pictureBox))
                {
                    // Отменить движение
                    MovePlayer(OppositeDirection(direction));
                    return;
                }
            }
        }
        public void SetMov()
        {
            Player.Image = playerSprites.GetCurrentSprite(moveCheck);
            MovementTimer.Start();
            Cigarete.Stop();
        }
        //Input блок
        private void Игра_KeyDown(object sender, KeyEventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                GlobalVariables.speed = 4;
            }
            else
            {
                GlobalVariables.speed = 2;
            }
            //playerSpeed = 2;
            if (moveCheck != MovementState.None)
                return;

            switch (e.KeyCode)
            {
                case Keys.Z:
                    this.StopMovement();
                    CheckCollisionTrigger(TrigerInput); 
                    break;
                case Keys.Escape:
                    PauseMenu pauseMenu = new PauseMenu(this);
                    pauseMenu.MusicOnOff += TrackChange;
                    pauseMenu.ShowDialog();
                    break;
                case Keys.Up:
                    moveCheck = MovementState.Up;
                    SetMov();
                    break;
                case Keys.Down:
                    moveCheck = MovementState.Down;
                    SetMov();
                    break;
                case Keys.Left:
                    moveCheck = MovementState.Left;
                    SetMov();
                    break;
                case Keys.Right:
                    moveCheck = MovementState.Right;
                    SetMov();
                    break;
                case Keys.Y:
                    MessageBox.Show("Y:" + Player.Top.ToString() + "\nX:" + Player.Right.ToString());
                    break;

            }
        }
        private void Игра_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ShiftKey)
            {
                GlobalVariables.speed = 2;
            }
            if (e.KeyCode == Keys.Left && moveCheck == MovementState.Left)
            {
                this.StopMovement();
                return;
            }
            else if (e.KeyCode == Keys.Right && moveCheck == MovementState.Right)
            {
                this.StopMovement();
                return;
            }
            else if (e.KeyCode == Keys.Up && moveCheck == MovementState.Up)
            {
                this.StopMovement();
                return;
            }
            else if (e.KeyCode == Keys.Down && moveCheck == MovementState.Down)
            {
                this.StopMovement();
                return;
            }
        }
        private void StopMovement()
        {
            moveCheck = MovementState.None;
            Player.Image = playerSprites.GetCurrentSprite(moveCheck);
            Cigarete.Start();
        }

        //PauseInput Блок
        private void TrackChange(int a)
        {
            GlobalVariables.player.ChangeVolume();
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            MovePlayer(moveCheck);
        }

        private void SpriteCig(object sender, EventArgs e)
        {
            Player.Image = playerSprites.GetCigSprite();
            Cigarete.Stop();
        }

        private void Scene_Load(object sender, EventArgs e)
        {
            GlobalVariables.dialogForm.ShowDialog();
        }
    }
}