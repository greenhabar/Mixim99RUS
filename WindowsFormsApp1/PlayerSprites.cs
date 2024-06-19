using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class PlayerSprites
    {
        //Инициализатор Блок
        int SisterBrother; //0-Brother, 1-Sister
        int School;//0-Home, 1-School

        Dictionary<int, Dictionary<int, List<System.Drawing.Bitmap>>> sprites;

        public PlayerSprites(int sisterBrother, int school)
        {
            SisterBrother = sisterBrother;
            School = school;

            sprites = new Dictionary<int, Dictionary<int, List<System.Drawing.Bitmap>>>();

            sprites.Add(0, new Dictionary<int, List<System.Drawing.Bitmap>>());
            sprites.Add(1, new Dictionary<int, List<System.Drawing.Bitmap>>());

            sprites[0].Add(0,new List<System.Drawing.Bitmap> //Brother|Home
            {
                //Idle
                Properties.Resources.PHIFront,
                Properties.Resources.PHIBack,
                //Move
                Properties.Resources.PHDMove,
                Properties.Resources.PHUMove,
                Properties.Resources.PHLMove,
                Properties.Resources.PHRMove,
                //Dop
                Properties.Resources.PHIFSigaret
            });
            sprites[0].Add(1, new List<System.Drawing.Bitmap>
            {
                //Idle
                Properties.Resources.PSIFront,
                Properties.Resources.PSIBack,
                //Move
                Properties.Resources.PSDMove,
                Properties.Resources.PSUMove,
                Properties.Resources.PSLMove,
                Properties.Resources.PSRMove,
                //Dop
                Properties.Resources.TestBox, //Properties.Resources.PSIFSigaret, Должно Быть, произошла утеря спрайта
            });
            
            sprites[1].Add(0, new List<System.Drawing.Bitmap> //Brother|Home
            {
                //Idle
                Properties.Resources.SHIFront,
                Properties.Resources.SHIBack,
                //Move
                Properties.Resources.PHDMove,
                Properties.Resources.PHUMove,
                Properties.Resources.PHLMove,
                Properties.Resources.PHRMove
            });
            sprites[1].Add(1, new List<System.Drawing.Bitmap>
            {
                //Idle
                Properties.Resources.SSIFront,
                Properties.Resources.SSIBack,
                //Move
                Properties.Resources.SSDMove,
                Properties.Resources.SSUMove,
                Properties.Resources.SSLMove,
                Properties.Resources.SSRMove
            });
        }

        //Get'ер Блок
        public System.Drawing.Bitmap GetCurrentIdleSprite(MovementState mv)
        {
            switch (mv)
            {
                case MovementState.Up: return sprites[SisterBrother][School][1];
                default: return sprites[SisterBrother][School][0];
            }
        }
        public System.Drawing.Bitmap GetCurrentMoveSprite(MovementState mv) 
        {
            switch(mv)
            {
                case MovementState.Down: return sprites[SisterBrother][School][2];
                case MovementState.Up: return sprites[SisterBrother][School][3];
                case MovementState.Left: return sprites[SisterBrother][School][4];
                case MovementState.Right: return sprites[SisterBrother][School][5];
            }
            return Properties.Resources.TestBox; //Это скорее Debug отросток, до него не должен доходить код
        }
        //Change Блок
        public void ChangeCharacter()
        {
            SisterBrother = (SisterBrother + 1) % 2;
        }
        public void ChangeSchool()
        {
            School = (School + 1) % 2;
        }
    }
}
