using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sensor_GUI.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    public class DataMessage<T> : ISerializable<DataMessage<T>>
    {
        public MessageHead MessageHead;
        public ushort ParameterNumber;
        public T Value;

        public override void GetFromByteArray(byte[] data)
        {

            this.MessageHead.MsgType = (MessageType)BitConverter.ToUInt16(data, 0);
            this.MessageHead.MsgLength = BitConverter.ToUInt16(data, 2);
            this.ParameterNumber = BitConverter.ToUInt16(data, 4);

            switch (this.MessageHead.MsgType)
            {
                case MessageType.PARAMETER_FLOAT:
                    this.Value = (T)(object)(BitConverter.ToSingle(data, 6));

                    break;
                case MessageType.PARAMETER_DOUBLE:
                    this.Value = (T)(object)(BitConverter.ToDouble(data, 6));
                    break;
                case MessageType.PARAMETER_INT8:
                    this.Value = (T)(object)(BitConverter.ToChar(data, 6));

                    break;
                case MessageType.PARAMETER_UINT8:
                    this.Value = (T)(object)data[6];
                    break;
                case MessageType.PARAMETER_INT16:
                    this.Value = (T)(object)(BitConverter.ToInt16(data, 6));

                    break;
                case MessageType.PARAMETER_UINT16:
                    this.Value = (T)(object)(BitConverter.ToUInt16(data, 6));

                    break;
                case MessageType.PARAMETER_INT32:
                    this.Value = (T)(object)(BitConverter.ToInt32(data, 6));

                    break;
                case MessageType.PARAMETER_UINT32:
                    this.Value = (T)(object)(BitConverter.ToUInt32(data, 6));

                    break;
                case MessageType.PARAMETER_INT64:
                    this.Value = (T)(object)(BitConverter.ToInt64(data, 6));

                    break;
                case MessageType.PARAMETER_UINT64:
                    this.Value = (T)(object)(BitConverter.ToUInt64(data, 6));

                    break;
            }

        }

        public override byte[] ToByteArray()
        {
            DataMessage<T> data_struct = this;
            byte[] bytes = new byte[data_struct.MessageHead.MsgLength];
            BitConverter.GetBytes((ushort)data_struct.MessageHead.MsgType).CopyTo(bytes, 0);
            BitConverter.GetBytes(data_struct.MessageHead.MsgLength).CopyTo(bytes, 2);
            BitConverter.GetBytes((ushort)data_struct.ParameterNumber).CopyTo(bytes, 4);
            BitConverter.GetBytes(data_struct.Value).CopyTo(bytes, 6);

            return bytes;

        }
    }
}
