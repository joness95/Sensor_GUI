namespace Sensor_GUI.Messages
{
    internal interface IDataMessage
    {
        public MessageHead Head { get; }
        public byte[] Value { get; }
    }
}
