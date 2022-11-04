using System.Runtime.InteropServices;

namespace Sensor_GUI.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct InitializeMessage
    {
        public MessageHead MsgHead;
        public InitializeMessage()
        {
            MsgHead.MsgType = MessageType.INITIALIZE;
            MsgHead.MsgLength = 4;
        }
    }
}
