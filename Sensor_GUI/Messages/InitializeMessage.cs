using System.Runtime.InteropServices;

namespace Sensor_GUI.Messages
{
    
    public class InitializeMessage : ISerializable<InitializeMessage>
    {
        public MessageHead MsgHead;
        public InitializeMessage()
        {
            MsgHead.MsgType = MessageType.INITIALIZE;
            MsgHead.MsgLength = 4;
        }

        public override void GetFromByteArray(byte[] data)
        {
            MsgHead.MsgType = (MessageType)BitConverter.ToUInt16(data, 0);
            MsgHead.MsgLength = BitConverter.ToUInt16(data, 2);

        }

        public override byte[] ToByteArray()
        {
            byte[] data = new byte[MsgHead.MsgLength];
            BitConverter.GetBytes((UInt16)MsgHead.MsgType).CopyTo(data, 0);
            BitConverter.GetBytes((UInt16)MsgHead.MsgLength).CopyTo(data, 2);
            return data;

        }
    }

    public class InitializeResponseMessage : ISerializable<InitializeResponseMessage>
    {
        public MessageHead MsgHead;
        public InitializeResponseMessage()
        {
            MsgHead.MsgType = MessageType.INITIALIZE_RESPONSE;
            MsgHead.MsgLength = 4;
        }

        public override void GetFromByteArray(byte[] data)
        {
            MsgHead.MsgType = (MessageType)BitConverter.ToUInt16(data, 0);
            MsgHead.MsgLength = BitConverter.ToUInt16(data, 2);

        }

        public override byte[] ToByteArray()
        {
            byte[] data = new byte[MsgHead.MsgLength];
            BitConverter.GetBytes((UInt16)MsgHead.MsgType).CopyTo(data, 0);
            BitConverter.GetBytes((UInt16)MsgHead.MsgLength).CopyTo(data, 2);
            return data;

        }
    }
}
