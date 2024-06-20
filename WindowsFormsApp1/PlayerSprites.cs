using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp1
{
    public class PlayerSprites
    {
        //Инициализатор Блок
        private Dictionary<CharacterType, Dictionary<LocationType, Dictionary<SpriteState, Bitmap>>> sprites;
        private CharacterType currentCharacter;
        private LocationType currentLocation;

        public PlayerSprites(CharacterType character, LocationType location)
        {
            currentCharacter = character;
            currentLocation = location;
            InitializeSprites();
        }

        private void InitializeSprites()
        {
            sprites = new Dictionary<CharacterType, Dictionary<LocationType, Dictionary<SpriteState, Bitmap>>>
            {
                {
                    CharacterType.Brother, new Dictionary<LocationType, Dictionary<SpriteState, Bitmap>>
                    {
                        {
                            LocationType.Home, new Dictionary<SpriteState, Bitmap>
                            {
                                {SpriteState.IdleFront, Properties.Resources.PHIFront},
                                {SpriteState.IdleBack, Properties.Resources.PHIBack},
                                {SpriteState.MoveDown, Properties.Resources.PHDMove },
                                {SpriteState.MoveUp, Properties.Resources.PHUMove},
                                {SpriteState.MoveLeft, Properties.Resources.PHLMove},
                                {SpriteState.MoveRight, Properties.Resources.PHRMove},
                            }
                        },
                        {
                            LocationType.School, new Dictionary<SpriteState, Bitmap>
                            {
                                {SpriteState.IdleFront, Properties.Resources.PSIFront},
                                {SpriteState.IdleBack, Properties.Resources.PSIBack},
                                {SpriteState.MoveDown, Properties.Resources.PSDMove },
                                {SpriteState.MoveUp, Properties.Resources.PSUMove},
                                {SpriteState.MoveLeft, Properties.Resources.PSLMove},
                                {SpriteState.MoveRight, Properties.Resources.PSRMove},
                            }
                        }
                    }
                },
                {
                    CharacterType.Sister, new Dictionary<LocationType, Dictionary<SpriteState, Bitmap>>
                    {
                        {
                            LocationType.Home, new Dictionary<SpriteState, Bitmap>
                            {
                                {SpriteState.IdleFront, Properties.Resources.SHIFront},
                                {SpriteState.IdleBack, Properties.Resources.SHIBack},
                                {SpriteState.MoveDown, Properties.Resources.SHDMove },
                                {SpriteState.MoveUp, Properties.Resources.SHUMove},
                                {SpriteState.MoveLeft, Properties.Resources.SHLMove},
                                {SpriteState.MoveRight, Properties.Resources.SHRMove},
                            }

                        },
                        {
                            LocationType.School, new Dictionary<SpriteState, Bitmap>
                            {
                                {SpriteState.IdleFront, Properties.Resources.SSIFront},
                                {SpriteState.IdleBack, Properties.Resources.SSIBack},
                                {SpriteState.MoveDown, Properties.Resources.SSDMove },
                                {SpriteState.MoveUp, Properties.Resources.SSUMove},
                                {SpriteState.MoveLeft, Properties.Resources.SHLMove},
                                {SpriteState.MoveRight, Properties.Resources.SSRMove},
                            }
                        }
                    }
                }
            };
        }

        //Get'ер Блок
        
        public System.Drawing.Bitmap GetCurrentSprite(MovementState mv)
        {
            SpriteState state = SpriteState.IdleFront;
            switch (mv)
            {
                case MovementState.Up: state = SpriteState.MoveUp; break;
                case MovementState.Down: state = SpriteState.MoveDown; break;
                case MovementState.Left: state = SpriteState.MoveLeft; break;
                case MovementState.Right: state = SpriteState.MoveRight; break;
                case MovementState.None: state = SpriteState.IdleFront;break;
            }
            if (sprites.TryGetValue(currentCharacter, out var characterDict))
            {
                if (characterDict.TryGetValue(currentLocation, out var locationDict))
                {
                    if (locationDict.TryGetValue(state, out var sprite))
                    {
                        return sprite;
                    }
                }
            }
            return Properties.Resources.TestBox;
        }
    }
}
