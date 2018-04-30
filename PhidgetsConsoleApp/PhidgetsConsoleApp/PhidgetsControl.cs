using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidgets;
using Phidgets.Events;

namespace PhidgetsTestWithSFML
{
    public class PhidgetsControl
    {
        public static InterfaceKit ifKit;
        public static int sliderOutput = 0;
        public static int magneticOutput = 0;

        public static void InitializePhidgets()
        {
            Console.WriteLine("- Initializing Phidgets");
            Console.WriteLine("Initializing InterfaceKit.");

            // Initialize the InterfaceKit objects.
            ifKit = new InterfaceKit();

            // Hook the event handlers
            ifKit.Attach += new AttachEventHandler(ifKit_Attach);
            ifKit.Detach += new DetachEventHandler(ifKit_Detach);
            ifKit.Error += new ErrorEventHandler(ifKit_Error);

            // Hook the phidget specific event handlers
            ifKit.InputChange += new InputChangeEventHandler(ifKit_InputChange);
            ifKit.OutputChange += new OutputChangeEventHandler(ifKit_OutputChange);
            ifKit.SensorChange += new SensorChangeEventHandler(ifKit_SensorChange);

            // Open the object for device connections.
            Console.WriteLine("Opening InterfaceKit for device connections.");

            ifKit.open();

            // Wait for attachement of the InterfaceKit
            Console.WriteLine("Waiting for InterfaceKit attachement.");
            ifKit.waitForAttachment();
        }

        /* PHIDGETS EVENT HANDLERS */
        static void ifKit_Attach(object sender, AttachEventArgs e)
        {
            Console.WriteLine("! InterfaceKit {" + e.Device.SerialNumber + "} attached !");
        }

        static void ifKit_Detach(object sender, DetachEventArgs e)
        {
            Console.WriteLine("! InterfaceKit {" + e.Device.SerialNumber + "} detached !");
        }

        static void ifKit_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Description);
        }

        static void ifKit_InputChange(object sender, InputChangeEventArgs e)
        {
            Console.WriteLine("Input index {" + e.Index + "} value {" + e.Value.ToString() + "}");
        }

        static void ifKit_OutputChange(object sender, OutputChangeEventArgs e)
        {
            //Console.WriteLine("Output index {" + e.Index + "} value {" + e.Value.ToString() + "}");
        }

        static void ifKit_SensorChange(object sender, SensorChangeEventArgs e)
        {
            Console.WriteLine("Sensor index {" + e.Index + "} value {" + e.Value.ToString() + "}");
            if (e.Index == 0)
            {
                sliderOutput = e.Value;
            }
            else if (e.Index == 1)
            {
                magneticOutput = e.Value;
            }
            else
            {
                return;
            }
        }
    }
}
