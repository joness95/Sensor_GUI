using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sensor_GUI.Messages
{
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
}
