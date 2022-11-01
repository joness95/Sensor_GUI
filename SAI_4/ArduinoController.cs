using Sensor_GUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace SAI_4
{
    internal class ArduinoController : BaseSensorController
    {
        public SerialPort port = new SerialPort();
        public Dictionary<int, IEnumerable> data = new Dictionary<int, IEnumerable>();

        public event DataAvailableDelegate<SByte> UINT8_DataAvailable = delegate { };
        public event DataAvailableDelegate<UInt16> UINT16_DataAvailable = delegate { };
        public event DataAvailableDelegate<UInt32> UINT32_DataAvailable = delegate { };
        public event DataAvailableDelegate<UInt64> UINT64_DataAvailable = delegate { };
        public event DataAvailableDelegate<Byte> INT8_DataAvailable = delegate { };
        public event DataAvailableDelegate<Int16> INT16_DataAvailable = delegate { };
        public event DataAvailableDelegate<Int32> INT32_DataAvailable = delegate { };
        public event DataAvailableDelegate<Int64> INT64_DataAvailable = delegate { };
        public event DataAvailableDelegate<float> FLOAT_DataAvailable = delegate { };
        public event DataAvailableDelegate<double> DOUBLE_DataAvailable = delegate { };

        public event ParameterResponse ParamterRecieved = delegate { };

        public delegate void ParameterResponse(object sender, ParameterNumber ParameterNumber, byte[] Value);

        public delegate void DataAvailableDelegate<T>(object sender, ushort ParameterNumber, T bytes);



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
            GetParameterRequest request;
            request.MessageHead.MsgType = MessageType.GET_PARAMETER;
            request.ParameterNumber = number;
            request.MessageHead.MsgLength = 2;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            var _port = (SerialPort)sender;
            byte[] buff_head = new byte[4];
            _port.Read(buff_head, 0, 4);
            var head = CastingHelper.CastToStruct<MessageHead>(buff_head);
            Debug.WriteLine($"Type: {head.MsgType}");
            Debug.WriteLine($"Length: {head.MsgLength}");
            byte[] buff_data = new byte[head.MsgLength];
            _port.Read(buff_data, 0, head.MsgLength);
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
                case MessageType.SET_PARAMETER:
                    break;
                case MessageType.SET_PARAMETER_RESPONSE:
                    var set_param_response = CastingHelper.CastToStruct<SetParameterResponse>(buff_msg);
                    ParamterRecieved(this, set_param_response.ParameterNumber, set_param_response.Value);
                    break;
                case MessageType.GET_PARAMETER:
                    break;
                case MessageType.GET_PARAMETER_RESPONSE:
                    var get_param_response = CastingHelper.CastToStruct<GetParameterResponse>(buff_msg);
                    ParamterRecieved(this, get_param_response.ParameterNumber, get_param_response.Value);
                    break;
                case MessageType.PARAMETER_FLOAT:
                    msg = CastingHelper.CastToStruct<DataMessage<float>>(buff_msg);
                    var buffmsg_float = (DataMessage<float>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_float.ParameterNumber, buffmsg_float.Value);
                    break;
                case MessageType.PARAMETER_DOUBLE:
                    msg = CastingHelper.CastToStruct<DataMessage<double>>(buff_msg);
                    var buffmsg_double = (DataMessage<double>)msg;
                    this.DOUBLE_DataAvailable(this, buffmsg_double.ParameterNumber, buffmsg_double.Value);
                    break;
                case MessageType.PARAMETER_INT8:
                    msg = CastingHelper.CastToStruct<DataMessage<SByte>>(buff_msg);
                    var buffmsg_SByte = (DataMessage<SByte>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_SByte.ParameterNumber, buffmsg_SByte.Value);
                    break;
                case MessageType.PARAMETER_UINT8:
                    msg = CastingHelper.CastToStruct<DataMessage<Byte>>(buff_msg);
                    var buffmsg_Byte = (DataMessage<Byte>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_Byte.ParameterNumber, buffmsg_Byte.Value);
                    break;
                case MessageType.PARAMETER_INT16:
                    msg = CastingHelper.CastToStruct<DataMessage<Int16>>(buff_msg);
                    var buffmsg_Int16 = (DataMessage<Int16>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_Int16.ParameterNumber, buffmsg_Int16.Value);
                    break;
                case MessageType.PARAMETER_UINT16:
                    msg = CastingHelper.CastToStruct<DataMessage<UInt16>>(buff_msg);
                    var buffmsg_UInt16 = (DataMessage<UInt16>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_UInt16.ParameterNumber, buffmsg_UInt16.Value);
                    break;
                case MessageType.PARAMETER_INT32:
                    msg = CastingHelper.CastToStruct<DataMessage<Int32>>(buff_msg);
                    var buffmsg_Int32 = (DataMessage<Int32>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_Int32.ParameterNumber, buffmsg_Int32.Value);
                    break;
                case MessageType.PARAMETER_UINT32:
                    msg = CastingHelper.CastToStruct<DataMessage<UInt32>>(buff_msg);
                    var buffmsg_UInt32 = (DataMessage<UInt32>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_UInt32.ParameterNumber, buffmsg_UInt32.Value);
                    break;
                case MessageType.PARAMETER_INT64:
                    msg = CastingHelper.CastToStruct<DataMessage<Int64>>(buff_msg);
                    var buffmsg_Int64 = (DataMessage<Int64>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_Int64.ParameterNumber, buffmsg_Int64.Value);
                    break;
                case MessageType.PARAMETER_UINT64:
                    msg = CastingHelper.CastToStruct<DataMessage<UInt64>>(buff_msg);
                    var buffmsg_UInt64 = (DataMessage<UInt64>)msg;
                    this.FLOAT_DataAvailable(this, buffmsg_UInt64.ParameterNumber, buffmsg_UInt64.Value);
                    break;
            }


            string hexString = BitConverter.ToString(buff_data);
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
            catch (Exception e)
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


    }
}
