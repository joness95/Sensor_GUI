using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SAI_4
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message
    {
        public ushort MsgType;
        public ushort MsgLength;
        public byte[] Data;
    }

    internal enum MessageType : ushort
    {
        INVALID=0,
        GET_HEARTBEAT=0x01,
        GET_HEARTBEAT_RESPONSE = 0x02,
        SET_PARAMETER = 0x03,
        SET_PARAMETER_RESPONSE = 0x04,
        GET_PARAMETER = 0x05,
        GET_PARAMETER_RESPONSE = 0x06,
        PARAMETER = 0x07,

    }

}
