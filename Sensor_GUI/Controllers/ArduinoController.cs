using ScottPlot.Palettes;
using Sensor_GUI.Helper;
using Sensor_GUI.Messages;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO.Ports;


namespace Sensor_GUI.Controllers
{
    public class ArduinoController : IBaseSensorController
    {
        public SerialPort port = new SerialPort();
        public Dictionary<int, IEnumerable> data = new Dictionary<int, IEnumerable>();

        public event DataAvailableDelegate<byte> UINT8_DataAvailable = delegate { };
        public event DataAvailableDelegate<ushort> UINT16_DataAvailable = delegate { };
        public event DataAvailableDelegate<uint> UINT32_DataAvailable = delegate { };
        public event DataAvailableDelegate<ulong> UINT64_DataAvailable = delegate { };
        public event DataAvailableDelegate<sbyte> INT8_DataAvailable = delegate { };
        public event DataAvailableDelegate<short> INT16_DataAvailable = delegate { };
        public event DataAvailableDelegate<int> INT32_DataAvailable = delegate { };
        public event DataAvailableDelegate<long> INT64_DataAvailable = delegate { };
        public event DataAvailableDelegate<float> FLOAT_DataAvailable = delegate { };
        public event DataAvailableDelegate<double> DOUBLE_DataAvailable = delegate { };

        public event ParameterResponseDelegate ParamterRecieved = delegate { };
        public event InitializedDelegate OnInitialized = delegate { };
        public delegate void ParameterResponseDelegate(object sender, ParameterNumber ParameterNumber, byte[] Value);

        public delegate void DataAvailableDelegate<T>(object sender, ushort MeassurementSet, T bytes);

        public delegate void InitializedDelegate(object sender);

        public ArduinoController()
        {
            port.DtrEnable = true;
            port.WriteTimeout = 100;
            
            Thread t = new Thread(() => { this.HandleMessages(); });
            t.IsBackground = true;

            t.Start();
            
        }



        public ArduinoController(string comPort)
        {
            port.DtrEnable = true;
            port.WriteTimeout = 100;
            Thread t = new Thread(() => { this.HandleMessages(); });
            t.Start();
            SetConnectionString(comPort);
        }

        private void HandleMessages()
        {
            while (true)
            {
                if (!port.IsOpen || port.BytesToRead ==0)
                {
                    continue;
                }
                byte[] buff_head = new byte[4];
                byte[] buff_data;
                MessageHead head;

                if (port.BytesToRead < 4)
                {
                    byte[] garbage = new byte[4];

                    port.Read(garbage, 0, port.BytesToRead);
                    Debug.WriteLine($"Recieved Garbage:{BitConverter.ToString(garbage)}");
                    return;
                }
                watch.Start();
                
                port.Read(buff_head, 0, 4);
                head.MsgType = (MessageType)BitConverter.ToUInt16(buff_head, 0);
                head.MsgLength = BitConverter.ToUInt16(buff_head, 2);

                buff_data = new byte[head.MsgLength - 4];
                Debug.WriteLine($"Type: {head.MsgType}");
                Debug.WriteLine($"Length: {head.MsgLength}");
                port.Read(buff_data, 0, head.MsgLength - 4);

                byte[] buff_msg = buff_head.Concat(buff_data).ToArray();
                Messages.Push(buff_msg);
                watch.Stop();
                Debug.WriteLine($"TimeNeeded: {watch.ElapsedMilliseconds}");
                watch.Restart();
                ISerializable msg;
                
                head.MsgType = (MessageType)BitConverter.ToUInt16(buff_head, 0);
                head.MsgLength = BitConverter.ToUInt16(buff_head, 2);
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
                        msg = new DataMessage<float>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_float = (DataMessage<float>)msg;
                        FLOAT_DataAvailable(this, buffmsg_float.ParameterNumber, buffmsg_float.Value);
                        break;
                    case MessageType.PARAMETER_DOUBLE:
                        msg = new DataMessage<double>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_double = (DataMessage<double>)msg;
                        DOUBLE_DataAvailable(this, buffmsg_double.ParameterNumber, buffmsg_double.Value);
                        break;
                    case MessageType.PARAMETER_INT8:
                        msg = new DataMessage<sbyte>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_sbyte = (DataMessage<sbyte>)msg;
                        INT8_DataAvailable(this, buffmsg_sbyte.ParameterNumber, buffmsg_sbyte.Value);
                        break;
                    case MessageType.PARAMETER_UINT8:
                        msg = new DataMessage<byte>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_byte = (DataMessage<byte>)msg;
                        UINT8_DataAvailable(this, buffmsg_byte.ParameterNumber, buffmsg_byte.Value);
                        break;
                    case MessageType.PARAMETER_INT16:
                        msg = new DataMessage<Int16>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_Int16 = (DataMessage<Int16>)msg;
                        INT16_DataAvailable(this, buffmsg_Int16.ParameterNumber, buffmsg_Int16.Value);
                        break;
                    case MessageType.PARAMETER_UINT16:
                        msg = new DataMessage<UInt16>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_UInt16 = (DataMessage<UInt16>)msg;
                        UINT16_DataAvailable(this, buffmsg_UInt16.ParameterNumber, buffmsg_UInt16.Value);
                        break;
                    case MessageType.PARAMETER_INT32:
                        msg = new DataMessage<Int32>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_Int32 = (DataMessage<Int32>)msg;
                        INT32_DataAvailable(this, buffmsg_Int32.ParameterNumber, buffmsg_Int32.Value);
                        break;
                    case MessageType.PARAMETER_UINT32:
                        msg = new DataMessage<UInt32>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_UInt32 = (DataMessage<UInt32>)msg;
                        UINT32_DataAvailable(this, buffmsg_UInt32.ParameterNumber, buffmsg_UInt32.Value);
                        break;
                    case MessageType.PARAMETER_INT64:
                        msg = new DataMessage<Int64>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_Int64 = (DataMessage<Int64>)msg;
                        INT64_DataAvailable(this, buffmsg_Int64.ParameterNumber, buffmsg_Int64.Value);
                        break;
                    case MessageType.PARAMETER_UINT64:
                        msg = new DataMessage<UInt64>();
                        msg.GetFromByteArray(buff_msg);
                        var buffmsg_UInt64 = (DataMessage<UInt64>)msg;
                        UINT64_DataAvailable(this, buffmsg_UInt64.ParameterNumber, buffmsg_UInt64.Value);
                        break;
                    case MessageType.INITIALIZE_RESPONSE:
                        var init_response = new InitializeResponseMessage();
                        init_response.GetFromByteArray(buff_msg);
                        OnInitialized(this);
                        break;
                }


                string hexString = BitConverter.ToString(buff_msg);
                Debug.WriteLine(hexString);
                Debug.WriteLine($"BytesToRead: {(port.IsOpen? port.BytesToRead:0)}");
            }
        }

        public void ReadParameter(ParameterNumber number)
        {
            GetParameterRequest request = new();
            request.MessageHead.MsgType = MessageType.GET_PARAMETER;
            request.ParameterNumber = number;
            request.MessageHead.MsgLength = 6;
            port.Write(request.ToByteArray(), 0, request.MessageHead.MsgLength);
        }
        private Stack<byte[]> Messages = new Stack<byte[]>();
        private object o = new object();
        Stopwatch watch = new Stopwatch();
        

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
            request.MessageHead.MsgLength = (UInt16)(value.Length + 6);
            request.Value = new byte[value.Length];
            value.CopyTo(request.Value, 0);
            if (port.IsOpen)
                port.Write(request.ToByteArray(), 0, request.MessageHead.MsgLength);
        }
    }
}
