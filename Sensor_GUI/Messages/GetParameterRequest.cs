using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Sensor_GUI.Messages
{

    public class GetParameterRequest : ISerializable<GetParameterRequest>
    {
        public MessageHead MessageHead;
        public ParameterNumber ParameterNumber;


        public override void GetFromByteArray(byte[] data)
        {

            this.MessageHead.MsgType = (MessageType)BitConverter.ToUInt16(data, 0);
            this.MessageHead.MsgLength = BitConverter.ToUInt16(data, 2);
            this.ParameterNumber = (ParameterNumber)BitConverter.ToUInt16(data, 4);
        }

        public override byte[] ToByteArray()
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
