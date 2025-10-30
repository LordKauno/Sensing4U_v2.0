using System;
using System.Windows.Forms;

namespace Sensing4U_v2._0
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Sensing4USensorData());
        }
    }
}