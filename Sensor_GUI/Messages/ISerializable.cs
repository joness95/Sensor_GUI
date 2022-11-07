using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sensor_GUI.Messages
{
    public abstract class ISerializable
    {
        public abstract void GetFromByteArray(byte[] data);

        public abstract byte[] ToByteArray();

    }
}
