using System.Runtime.InteropServices;

namespace Sensor_GUI.Messages
{

    public class SetParameterRequest : ISerializable
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;
        public byte[] Value = Array.Empty<byte>();


        public override void GetFromByteArray(byte[] data)
        {
            this.MessageHead.MsgType = (MessageType)BitConverter.ToUInt16(data, 0);
            this.MessageHead.MsgLength = BitConverter.ToUInt16(data, 2);
            this.ParameterNumber = (ParameterNumber)BitConverter.ToUInt16(data, 4);

            this.Value = new byte[this.MessageHead.MsgLength - 6];
            Array.Copy(data, 6, this.Value, 0, this.MessageHead.MsgLength - 6);
        }

        public override byte[] ToByteArray()
        {
            SetParameterRequest data_struct = this;
            byte[] bytes = new byte[data_struct.MessageHead.MsgLength];
            BitConverter.GetBytes((ushort)data_struct.MessageHead.MsgType).CopyTo(bytes,0);
            BitConverter.GetBytes(data_struct.MessageHead.MsgLength).CopyTo(bytes,2);
            BitConverter.GetBytes((ushort)data_struct.ParameterNumber).CopyTo(bytes,4);
            data_struct.Value.CopyTo(bytes, 6);
            return bytes;
        }
    }
}
