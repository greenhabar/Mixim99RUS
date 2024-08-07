using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Reflection;
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

            MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);

            MessageBox.Show(this.BackGroundPath);

            //Debug

            Colissions = new List<PictureBox> {Col4,Col2,Col3,Col4,Col5,Col6}; //JSON done
            TrigerInput = new List<Triger> {new Triger(inputTriger1,1,true,"null")};
            TrigerCords = new List<Triger> {};

        }

        public Scene(string path)
        {
            InitializeComponent();
            InitializeForm();

            GlobalVariables.WorkWithJSON.ReadScene(this, path);

        }

        void InitializeForm()
        {
            GlobalVariables.WorkWithJSON = new WorkWithJSON();

            this.DoubleBuffered = true;

            playerSpeed = 1;
            Player.BringToFront();
            playerSprites = new PlayerSprites(0, 0);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;


            this.BackGroundPath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\ToiletTest.jpg";
            this.BackgroundImage = Image.FromFile(this.BackGroundPath);
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
                    case Keys.I:
                    GlobalVariables.WorkWithJSON.SaveData(this,"ToiletTest");
                    break;
                case Keys.G:
                    GlobalVariables.WorkWithJSON.ReadScene(this, "ToiletTest");
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
