using System.Runtime.InteropServices;

namespace Sensor_GUI.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    struct MessageHead
    {
        public MessageType MsgType;
        public ushort MsgLength;
    }
}
