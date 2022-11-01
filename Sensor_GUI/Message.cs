using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SAI_4
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Message
    {
        public MessageHead MessageHead;
        public byte[] Data;
    }

    internal interface IDataMessage
    {
        public MessageHead Head { get; }
        public byte[] Value { get; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    internal struct GetParameterResponse
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;
        public byte[] Value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    internal struct GetParameterRequest
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    internal struct SetParameterResponse
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;
        public byte[] Value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    internal struct SetParameterRequest
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;
        public byte[] Value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    internal struct DataMessage<T> : IDataMessage
    {
        public MessageHead MessageHead;
        public ushort ParameterNumber;
        public T Value;


        byte[] IDataMessage.Value
        {
            get
            {
                MemoryStream ms = new MemoryStream();
                var binaryFormatter = new BinaryFormatter();
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
#pragma warning disable SYSLIB0011 // Typ oder Element ist veraltet
                binaryFormatter.Serialize(ms, Value);
#pragma warning restore SYSLIB0011 // Typ oder Element ist veraltet
#pragma warning restore CS8604 // Mögliches Nullverweisargument.

                return ms.ToArray();

            }

        }

        MessageHead IDataMessage.Head => MessageHead;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    struct MessageHead
    {
        public MessageType MsgType;
        public ushort MsgLength;
    }

    internal enum MessageType : ushort
    {
        INVALID = 0,
        GET_HEARTBEAT = 0x01,
        GET_HEARTBEAT_RESPONSE = 0x02,
        SET_PARAMETER = 0x03,
        SET_PARAMETER_RESPONSE = 0x04,
        GET_PARAMETER = 0x05,
        GET_PARAMETER_RESPONSE = 0x06,
        PARAMETER_FLOAT = 0x10,
        PARAMETER_DOUBLE,
        PARAMETER_INT8 = 0x20,
        PARAMETER_UINT8,
        PARAMETER_INT16,
        PARAMETER_UINT16,
        PARAMETER_INT32,
        PARAMETER_UINT32,
        PARAMETER_INT64,
        PARAMETER_UINT64,
    }
    internal enum ParameterNumber : ushort
    {
        INVALID = 0,
        CYCLETIME
    }
}
