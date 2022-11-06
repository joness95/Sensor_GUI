using ScottPlot.Palettes;
using Sensor_GUI.Helper;
using Sensor_GUI.Messages;
using System.Collections;
using System.Diagnostics;
using System.IO.Ports;


namespace Sensor_GUI.Controllers
{
    public class ArduinoController : IBaseSensorController
    {
        public SerialPort port = new SerialPort();
        public Dictionary<int, IEnumerable> data = new Dictionary<int, IEnumerable>();

        public event DataAvailableDelegate<sbyte> UINT8_DataAvailable = delegate { };
        public event DataAvailableDelegate<ushort> UINT16_DataAvailable = delegate { };
        public event DataAvailableDelegate<uint> UINT32_DataAvailable = delegate { };
        public event DataAvailableDelegate<ulong> UINT64_DataAvailable = delegate { };
        public event DataAvailableDelegate<byte> INT8_DataAvailable = delegate { };
        public event DataAvailableDelegate<short> INT16_DataAvailable = delegate { };
        public event DataAvailableDelegate<int> INT32_DataAvailable = delegate { };
        public event DataAvailableDelegate<long> INT64_DataAvailable = delegate { };
        public event DataAvailableDelegate<float> FLOAT_DataAvailable = delegate { };
        public event DataAvailableDelegate<double> DOUBLE_DataAvailable = delegate { };

        public event ParameterResponseDelegate ParamterRecieved = delegate { };
        public event InitializedDelegate OnInitialized = delegate { };
        public delegate void ParameterResponseDelegate(object sender, ParameterNumber ParameterNumber, byte[] Value);

        public delegate void DataAvailableDelegate<T>(object sender, ushort ParameterNumber, T bytes);

        public delegate void InitializedDelegate(object sender);

        public ArduinoController()
        {
            port.DtrEnable = true;
            port.DataReceived += Port_DataReceived;
        }



        public ArduinoController(string comPort)
        {
            port.DtrEnable = true;
            port.DataReceived += Port_DataReceived;

            SetConnectionString(comPort);
        }

        public void ReadParameter(ParameterNumber number)
        {
            GetParameterRequest request = new();
            request.MessageHead.MsgType = MessageType.GET_PARAMETER;
            request.ParameterNumber = number;
            request.MessageHead.MsgLength = 6;
            port.Write(request.ToByteArray(), 0, request.MessageHead.MsgLength);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            var _port = (SerialPort)sender;
            byte[] buff_head = new byte[4];
            _port.Read(buff_head, 0, 4);
            var head = buff_head.CastToStruct<MessageHead>();
            Debug.WriteLine($"Type: {head.MsgType}");
            Debug.WriteLine($"Length: {head.MsgLength}");
            byte[] buff_data = new byte[head.MsgLength - 4];
            _port.Read(buff_data, 0, head.MsgLength - 4);
            byte[] buff_msg = buff_head.Concat(buff_data).ToArray();

            IDataMessage msg;

            switch (head.MsgType)
            {
                case MessageType.INVALID:
                    break;
                case MessageType.GET_HEARTBEAT:
                    break;
                case MessageType.GET_HEARTBEAT_RESPONSE:
                    break;
                case MessageType.SET_PARAMETER_RESPONSE:
                    var set_param_response = new SetParameterResponse();
                    set_param_response.GetFromByteArray(buff_msg);
                    ParamterRecieved(this, set_param_response.ParameterNumber, set_param_response.Value);
                    break;
                case MessageType.GET_PARAMETER_RESPONSE:
                    var get_param_response = new GetParameterResponse();
                    get_param_response.GetFromByteArray(buff_msg);
                    ParamterRecieved(this, get_param_response.ParameterNumber, get_param_response.Value);
                    break;
                case MessageType.PARAMETER_FLOAT:
                    msg = buff_msg.CastToStruct<DataMessage<float>>();
                    var buffmsg_float = (DataMessage<float>)msg;
                    FLOAT_DataAvailable(this, buffmsg_float.ParameterNumber, buffmsg_float.Value);
                    break;
                case MessageType.PARAMETER_DOUBLE:
                    msg = buff_msg.CastToStruct<DataMessage<double>>();
                    var buffmsg_double = (DataMessage<double>)msg;
                    DOUBLE_DataAvailable(this, buffmsg_double.ParameterNumber, buffmsg_double.Value);
                    break;
                case MessageType.PARAMETER_INT8:
                    msg = buff_msg.CastToStruct<DataMessage<sbyte>>();
                    var buffmsg_SByte = (DataMessage<sbyte>)msg;
                    FLOAT_DataAvailable(this, buffmsg_SByte.ParameterNumber, buffmsg_SByte.Value);
                    break;
                case MessageType.PARAMETER_UINT8:
                    msg = buff_msg.CastToStruct<DataMessage<byte>>();
                    var buffmsg_Byte = (DataMessage<byte>)msg;
                    FLOAT_DataAvailable(this, buffmsg_Byte.ParameterNumber, buffmsg_Byte.Value);
                    break;
                case MessageType.PARAMETER_INT16:
                    msg = buff_msg.CastToStruct<DataMessage<short>>();
                    var buffmsg_Int16 = (DataMessage<short>)msg;
                    FLOAT_DataAvailable(this, buffmsg_Int16.ParameterNumber, buffmsg_Int16.Value);
                    break;
                case MessageType.PARAMETER_UINT16:
                    msg = buff_msg.CastToStruct<DataMessage<ushort>>();
                    var buffmsg_UInt16 = (DataMessage<ushort>)msg;
                    FLOAT_DataAvailable(this, buffmsg_UInt16.ParameterNumber, buffmsg_UInt16.Value);
                    break;
                case MessageType.PARAMETER_INT32:
                    msg = buff_msg.CastToStruct<DataMessage<int>>();
                    var buffmsg_Int32 = (DataMessage<int>)msg;
                    FLOAT_DataAvailable(this, buffmsg_Int32.ParameterNumber, buffmsg_Int32.Value);
                    break;
                case MessageType.PARAMETER_UINT32:
                    msg = buff_msg.CastToStruct<DataMessage<uint>>();
                    var buffmsg_UInt32 = (DataMessage<uint>)msg;
                    FLOAT_DataAvailable(this, buffmsg_UInt32.ParameterNumber, buffmsg_UInt32.Value);
                    break;
                case MessageType.PARAMETER_INT64:
                    msg = buff_msg.CastToStruct<DataMessage<long>>();
                    var buffmsg_Int64 = (DataMessage<long>)msg;
                    FLOAT_DataAvailable(this, buffmsg_Int64.ParameterNumber, buffmsg_Int64.Value);
                    break;
                case MessageType.PARAMETER_UINT64:
                    msg = buff_msg.CastToStruct<DataMessage<ulong>>();
                    var buffmsg_UInt64 = (DataMessage<ulong>)msg;
                    FLOAT_DataAvailable(this, buffmsg_UInt64.ParameterNumber, buffmsg_UInt64.Value);
                    break;
                case MessageType.INITIALIZE_RESPONSE:
                    var init_response = new InitializeResponseMessage();
                    init_response.GetFromByteArray(buff_msg);
                    OnInitialized(this);
                    break;
            }


            string hexString = BitConverter.ToString(buff_msg);
            Debug.WriteLine(hexString);
        }

        public bool Connect()
        {
            if (!port.IsOpen && port.PortName == "")
                return false;
            port.BaudRate = 115200;
            try
            {
                port.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return true;

        }

        public void Disconnect()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }

        public bool SetConnectionString(string connectionString)
        {
            if (port.IsOpen)
            {
                return false;
            }
            port.PortName = connectionString;
            return true;
        }

        public void Initialize()
        {
            if (port.IsOpen)
            {
                InitializeMessage msg = new InitializeMessage();
                port.Write(msg.ToByteArray(), 0, msg.MsgHead.MsgLength);
            }
        }

        public void SetParameter(ParameterNumber number, byte[] value)
        {
            SetParameterRequest request = new();
            request.MessageHead.MsgType = MessageType.SET_PARAMETER;
            request.ParameterNumber = number;
            request.MessageHead.MsgLength = (UInt16)(value.Length +6);
            request.Value = new byte[value.Length];
            value.CopyTo(request.Value, 0);
            port.Write(request.ToByteArray(), 0, request.MessageHead.MsgLength);
        }
    }
}
