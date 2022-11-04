using System.Runtime.InteropServices;

namespace Sensor_GUI.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    internal struct SetParameterRequest
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;
        public byte[] Value;

        public static SetParameterRequest GetFromByteArray(byte[] data)
        {
            SetParameterRequest data_struct = new SetParameterRequest();
            data_struct.MessageHead.MsgType = (MessageType)BitConverter.ToUInt16(data, 0);
            data_struct.MessageHead.MsgLength = BitConverter.ToUInt16(data, 2);
            data_struct.ParameterNumber = (ParameterNumber)BitConverter.ToUInt16(data, 4);

            data_struct.Value = new byte[data_struct.MessageHead.MsgLength - 6];
            Array.Copy(data, 0, data_struct.Value, 0, data_struct.MessageHead.MsgLength - 6);
            return data_struct;
        }

        public byte[] ToByteArray()
        {
            SetParameterRequest data_struct = this;
            byte[] bytes = new byte[data_struct.MessageHead.MsgLength];
            bytes.SetValue(BitConverter.GetBytes((ushort)data_struct.MessageHead.MsgType), 0);
            bytes.SetValue(BitConverter.GetBytes(data_struct.MessageHead.MsgLength), 2);
            bytes.SetValue(BitConverter.GetBytes((ushort)data_struct.ParameterNumber), 4);
            bytes.SetValue(data_struct.Value, 6);
            return bytes;

        }
    }
}
