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
        public static string task { get; set; } = " - ";
        public static int locationId {  get; set; }
        public static int speed {  get; set; } 
        public static bool volume { get; set; }
        public static List<string> inventory { get; set; }
        public static AudioPlayer player { get; set; }
        public static WorkWithJSON WorkWithJSON { get; set; }
        public static List<LocationData> locations { get; set; }
    }
}
