using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deposito
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            inicio ini = new inicio();
            ini.ShowDialog();
            if (ini.login() != -1)
            {
                Application.Run(new MDIMenu(ini.tipo));
            }
        }
    }
}
