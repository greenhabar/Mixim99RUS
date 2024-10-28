using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            //Application.Run(new Dialog());

            //Application.Run(new SelectForm("C:\\Users\\User\\3D Objects\\ProjectUtilities\\SelectionGenerator\\WinFormsApp1\\bin\\Debug\\net7.0-windows\\TEST.json"));
        }
    }
}
