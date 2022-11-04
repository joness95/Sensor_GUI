using System.Runtime.InteropServices;

namespace Sensor_GUI.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    internal struct GetParameterRequest
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;

        public static GetParameterRequest GetFromByteArray(byte[] data)
        {
            GetParameterRequest data_struct = new GetParameterRequest();
            data_struct.MessageHead.MsgType = (MessageType)BitConverter.ToUInt16(data, 0);
            data_struct.MessageHead.MsgLength = BitConverter.ToUInt16(data, 2);
            data_struct.ParameterNumber = (ParameterNumber)BitConverter.ToUInt16(data, 4);
            return data_struct;
        }
        public byte[] ToByteArray()
        {
            GetParameterRequest data_struct = this;
            byte[] bytes = new byte[data_struct.MessageHead.MsgLength];
            BitConverter.GetBytes((ushort)data_struct.MessageHead.MsgType).CopyTo(bytes, 0);
            BitConverter.GetBytes(data_struct.MessageHead.MsgLength).CopyTo(bytes, 2);
            BitConverter.GetBytes((ushort)data_struct.ParameterNumber).CopyTo(bytes, 4);
            return bytes;

        }

    }
}
