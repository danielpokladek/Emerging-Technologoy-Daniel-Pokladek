using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidgets;
using Phidgets.Events;

namespace PhidgetsTestWithSFML
{
    class Program
    {
        static void Main(string[] args)
        {
            PhidgetsControl.InitializePhidgets();
            
            AppLoop();
        }

        static void AppLoop()
        {
            while (true)
            {
                // Loop to avoid the program from closing.
            }
        }
    }
}
