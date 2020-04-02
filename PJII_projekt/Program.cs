using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJII_projekt
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
          /*  AppSet a1 = new AppSet(15);
            a1.Add(new Appartment(1, 11000000, "Dr. Martinka 11:", true));

            Console.WriteLine(a1.Find(x => x.getAppNumber() == 1).DataToString());

            foreach (Appartment a in a1)
            {
                Console.WriteLine(a.DataToString());
            }
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
