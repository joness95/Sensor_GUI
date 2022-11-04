namespace Sensor_GUI.Messages
{
    internal enum MessageType : ushort
    {
        INVALID = 0,
        GET_HEARTBEAT = 0x01,
        GET_HEARTBEAT_RESPONSE,
        SET_PARAMETER,
        SET_PARAMETER_RESPONSE,
        GET_PARAMETER,
        GET_PARAMETER_RESPONSE,
        INITIALIZE,
        PARAMETER_FLOAT = 0x100,
        PARAMETER_DOUBLE,
        PARAMETER_INT8 = 0x110,
        PARAMETER_UINT8,
        PARAMETER_INT16,
        PARAMETER_UINT16,
        PARAMETER_INT32,
        PARAMETER_UINT32,
        PARAMETER_INT64,
        PARAMETER_UINT64,
    }
}
