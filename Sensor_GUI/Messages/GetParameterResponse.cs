using System.Runtime.InteropServices;

namespace Sensor_GUI.Messages
{
    public class GetParameterResponse : ISerializable
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
            GetParameterResponse data_struct = this;
            byte[] bytes = new byte[data_struct.MessageHead.MsgLength];
            bytes.SetValue(BitConverter.GetBytes((ushort)data_struct.MessageHead.MsgType), 0);
            bytes.SetValue(BitConverter.GetBytes(data_struct.MessageHead.MsgLength), 2);
            bytes.SetValue(BitConverter.GetBytes((ushort)data_struct.ParameterNumber), 4);
            return bytes;
        }
    }
}
