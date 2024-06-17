using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Sprites
    {
        Dictionary<string, List< System.Drawing.Bitmap>> brotherSprites = new Dictionary<string, List<System.Drawing.Bitmap>>();
        Dictionary<string, List< System.Drawing.Bitmap>> sisterSprites = new Dictionary<string, List<System.Drawing.Bitmap>>();

        public List<System.Drawing.Bitmap> CurrentPlayerSprites;

        bool School = false;
        bool Sister = false;

        public Sprites() 
        {
            brotherSprites.Add("school", new List<System.Drawing.Bitmap>
            {
               Properties.Resources.PSIFront,
               Properties.Resources.PSIBack,
               Properties.Resources.PSILeft,
               Properties.Resources.PSIRight,
               Properties.Resources.PSIFSigaret,
               Properties.Resources.PSDMove,
               Properties.Resources.PSUMove,
               Properties.Resources.PSLMove,
               Properties.Resources.PSRMove
            });
            brotherSprites.Add("home", new List<System.Drawing.Bitmap>
            {
               Properties.Resources.PHIFront,
               Properties.Resources.PHIBack,
               Properties.Resources.PHILeft,
               Properties.Resources.PHIRight,
               Properties.Resources.PHIFSigaret,
               Properties.Resources.PHDMove,
               Properties.Resources.PHUMove,
               Properties.Resources.PHLMove,
               Properties.Resources.PHRMove
            });
            //----------------------------------------------------
            sisterSprites.Add("school", new List<System.Drawing.Bitmap>
            {
               Properties.Resources.SHIFront,
               Properties.Resources.SHIBack,
               Properties.Resources.SHILeft,
               Properties.Resources.SHIRight,
               Properties.Resources.Empty,
               Properties.Resources.SHDMove,
               Properties.Resources.SHUMove,
               Properties.Resources.SHLMove,
               Properties.Resources.SHRMove
            });
            sisterSprites.Add("home", new List<System.Drawing.Bitmap>
            {
               Properties.Resources.SSIFront,
               Properties.Resources.SSIBack,
               Properties.Resources.SSILeft,
               Properties.Resources.SSIRight,
               Properties.Resources.Empty,
               Properties.Resources.SSDMove,
               Properties.Resources.SSUMove,
               Properties.Resources.SSLMove,
               Properties.Resources.SSRMove
            });

        }

        public void SchoolEnter_Exit()
        {
            School = !School;
            ChangePLSprites();
        }
        public void SisterYe_No()
        {
            Sister = !Sister;
            ChangePLSprites();
        }

        void ChangePLSprites()
        {
            if(Sister)
            {

                if(School)
                {
                    CurrentPlayerSprites = sisterSprites["school"];
                }
                else
                {
                    CurrentPlayerSprites = sisterSprites["home"];
                }

            }
            else
            {
                if (School)
                {
                    CurrentPlayerSprites = brotherSprites["school"];
                }
                else
                {
                    CurrentPlayerSprites = brotherSprites["home"];
                }
            }
        }
    }
}
