using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sensor_GUI.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message
    {
        public MessageHead MessageHead;
        public byte[] Data;
    }
}
