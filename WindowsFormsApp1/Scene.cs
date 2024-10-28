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

        MovementState moveCheck;

        public Scene()
        {
            InitializeComponent();
            InitializeForm();
            InitializeDefaultSettings();
        }
        public Scene(string path)
        {
            InitializeComponent();
            InitializeForm();
            GlobalVariables.WorkWithJSON.Read(this,path);
        }

        void InitializeForm()
        {
            GlobalVariables.WorkWithJSON = new WorkWithJSON();
            GlobalVariables.dialogForm = new Dialog();
            GlobalVariables.selectForm = new SelectForm();

            this.DoubleBuffered = true;

            Player.BringToFront();
            playerSprites = new PlayerSprites(0, 0);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;


            this.BackGroundPath = "\\Resources\\ToiletTest.jpg";
            this.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + this.BackGroundPath);
        }
        void InitializeDefaultSettings()
        {
            GlobalVariables.inventory = new List<string>();
            GlobalVariables.locationId = 0;
            GlobalVariables.locations = new List<LocationData>();

            Colissions = new List<PictureBox> { Col4, Col2, Col3, Col4, Col5, Col6 }; //JSON done
            TrigerInput = new List<Triger> { new Triger(inputTriger1, 1, true, "null") };
            TrigerCords = new List<Triger> { };
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
                case Keys.I:
                    GlobalVariables.WorkWithJSON.SaveData(this,"ToiletTest");
                    break;
                case Keys.G:
                    GlobalVariables.WorkWithJSON.ReadScene(this, "ToiletTest");
                    break;
                //case Keys.T:
                //    GlobalVariables.WorkWithJSON.DEBUG_Save(this, "bruh");
                //    break;

            }
            Player.Image = playerSprites.GetCurrentSprite(moveCheck);
            MovementTimer.Start();
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
    }
}