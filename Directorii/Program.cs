using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorii
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SplashForm());
            }
            else
            {
                Console.WriteLine("running in silent mode");
                Console.WriteLine("There are :" + args.Length + "arguments.");
                foreach(var arg in args)
                {
                    Console.WriteLine(arg.ToString());
                }
                Console.ReadLine();
            }
        }
    }
}
