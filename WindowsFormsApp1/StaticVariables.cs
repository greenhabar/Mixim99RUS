using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum CharacterType
    {
        Brother = 0,
        Sister = 1
    }
    public enum LocationType
    {
        Home = 0,
        School = 1
    }
    public enum SpriteState
    { 
        IdleFront,
        IdleBack,
        MoveDown,
        MoveUp,
        MoveLeft,
        MoveRight
    }
    public enum MovementState 
    { 
        None, 
        Up, 
        Down, 
        Left, 
        Right 
    }
    public static class GlobalVariables
    {
        public static bool volume { get; set; }
        public static AudioPlayer player { get; set; }
    }
}
