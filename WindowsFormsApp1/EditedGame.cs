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
    public partial class EditedGame : Form
    {
        public EditedGame()//int volume)
        {
            InitializeComponent();

            playerSpeed = 2;
            Player.BringToFront();

            Volume = 100; //volume;
            pictureBoxList = new List<PictureBox> { }; //pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox8 };

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        enum MovementState { None, Up, Down, Left, Right }

        int playerSpeed;
        MovementState moveCheck;
        List<PictureBox> pictureBoxList;

        private int _volume;
        public int Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                // Дополнительная логика при изменении громкости
                MessageBox.Show(_volume == 100 ? "Музыка On!" : "Музыка Off!");
            }
        }

        private bool CheckCollision(PictureBox entity)
        {
            return Player.Bounds.IntersectsWith(entity.Bounds);
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

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (moveCheck != MovementState.None)
                return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    //PauseMenu pauseMenu = new PauseMenu(this);
                    //pauseMenu.MusicOnOff += TrackChange;
                    //pauseMenu.ShowDialog();
                    break;
                case Keys.Up:
                    Player.Image = Properties.Resources.IdleSisterBack;
                    moveCheck = MovementState.Up;
                    break;
                case Keys.Down:
                    Player.Image = Properties.Resources.IdleSisterFront;
                    moveCheck = MovementState.Down;
                    break;
                case Keys.Left:
                    Player.Image = Properties.Resources.IdleSisterLeft;
                    moveCheck = MovementState.Left;
                    break;
                case Keys.Right:
                    Player.Image = Properties.Resources.IdleSisterRight;
                    moveCheck = MovementState.Right;
                    break;
            }
        }
    }
}
