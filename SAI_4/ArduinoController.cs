using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SAI_4
{
    internal class ArduinoController : BaseSensorController
    {
        public SerialPort port = new SerialPort();

        public ArduinoController()
        {
            port.DataReceived += Port_DataReceived;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public ArduinoController(string comPort)
        {
            port.DataReceived += Port_DataReceived;

            SetConnectionString(comPort);
        }

        public bool Connect()
        {
            if (!port.IsOpen && port.PortName == "")
                return false;
            port.BaudRate = 115200;
            try
            {
                port.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            return true;

        }

        public void Disconnect()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }

        public bool SetConnectionString(string connectionString)
        {
            if (port.IsOpen)
            {
                return false;
            }
            port.PortName = connectionString;
            return true;
        }


    }
}
