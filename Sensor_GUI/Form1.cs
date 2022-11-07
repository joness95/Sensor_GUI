using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Management;
using System.Numerics;
using System.Text;
using ScottPlot;
using ScottPlot.Plottable;
using Sensor_GUI.Controllers;
using Sensor_GUI.Helper;
using Sensor_GUI.Messages;

namespace SAI_4
{
    public partial class MainForm : Form
    {
        Dictionary<string, SerialPortInfo> _ports = new Dictionary<string, SerialPortInfo>();
        ArduinoController _controller = new ArduinoController();
        Dictionary<int,(IPlottable,List<long>,IEnumerable)> Plots = new Dictionary<int, (IPlottable, List<long>, IEnumerable)>();
        private bool recording;

        public long StartTime { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            ListProperties.Columns[0].Width = this.ListProperties.Size.Width / 2 - 1;
            ListProperties.Columns[1].Width = this.ListProperties.Size.Width / 2 - 1;
            _controller.ParamterRecieved += ((object sender, ParameterNumber ParameterNumber, byte[] Value) =>
            {
                Debug.WriteLine($"Paramternumber {ParameterNumber} - Value {BitConverter.ToString(Value)}");
            });

            _controller.INT16_DataAvailable += ((object sender, ushort Meassurement, Int16 bytes) => { Debug.WriteLine($"Data recieved {Meassurement} - Value {bytes}"); });

            _controller.ParamterRecieved += RecievedCycleTime;
            
            var Legend= Plot1.Plot.Legend(Enabled = true);
        }

        private void RecievedCycleTime(object sender, ParameterNumber ParameterNumber, byte[] Value)
        {
            UInt32 value = BitConverter.ToUInt32(Value, 0);
            textBox1.Invoke(()=> textBox1.Text = value.ToString());
        }

        private void ButtonScan_Click(object sender, EventArgs e)
        {
            var buff = new Dictionary<string, SerialPortInfo>();

            var ComportsNames = SerialPort.GetPortNames();

            _ports.Clear();
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();
            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name")?.ToString();
                if (name != null && name.Contains("COM"))
                {
                    buff.Add(name, new SerialPortInfo(property));
                    //Thats all information i got from port.
                    //Do whatever you want with this information
                }
            }

            foreach (var compName in ComportsNames)
            {
                foreach (var info in buff.Keys)
                {
                    if (info.Contains(compName))
                    {
                        var portInfo = buff[info];
                        portInfo.COMPort = compName;
                        _ports.Add(info, portInfo);
                    }
                }
            }
            ListConnections.Items.Clear();
            ListConnections.Clear();
            foreach (var item in _ports.Keys)
            {
                ListConnections.Items.Add(item);
            }
        }


        private void ListConnections_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs eventargs)
        {
            ListProperties.Items.Clear();
            var item = ListProperties.Items.Add("Name");
            item.SubItems.Add(eventargs.Item.Text);
            item = ListProperties.Items.Add("COM-Port");
            item.SubItems.Add(_ports[eventargs.Item.Text].COMPort);
            item = ListProperties.Items.Add("Manufacturer");
            item.SubItems.Add(_ports[eventargs.Item.Text].Manufacturer);
            item = ListProperties.Items.Add("Description");
            item.SubItems.Add(_ports[eventargs.Item.Text].Description);
            item = ListProperties.Items.Add("Availability");
            item.SubItems.Add(_ports[eventargs.Item.Text].Availability.ToString());
            item = ListProperties.Items.Add("Present");
            item.SubItems.Add(_ports[eventargs.Item.Text].Present.ToString());
        }

        private void ListProperties_Resize(object sender, EventArgs e)
        {

            ListView view = (ListView)sender;
            var size = view.Size.Width;
            view.Columns[0].Width = size / 2 - 2;
            view.Columns[1].Width = size / 2 - 2;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            var selected = ListConnections.SelectedItems;
            var ToolStripConnectionStatus = statusStrip1.Items["ToolStripConnectionStatus"];
            if (selected.Count > 0 && _controller.port.IsOpen == false && button.Text == "Connect")
            {
                button.Text = "Disconnect";
                ButtonScan.Enabled = false;
                ListConnections.Enabled = false;

                ToolStripConnectionStatus.BackColor = Color.Orange;
                ToolStripConnectionStatus.Text = "Connecting...";

                _controller.SetConnectionString(_ports[ListConnections.SelectedItems[0].Text].COMPort);
                try
                {
                    _controller.Connect();
                    ToolStripConnectionStatus.BackColor = Color.SpringGreen;
                    ToolStripConnectionStatus.Text = "Connected";
                }
                catch (Exception exception)
                {
                    ListConnections.Enabled = true;
                    ButtonScan.Enabled = true;

                    _controller.Disconnect();
                    button.Text = "Connect";
                    ToolStripConnectionStatus.BackColor = Color.Red;
                    ToolStripConnectionStatus.Text = "Error";
                    Debug.WriteLine(exception);
                }
            }
            else if (_controller.port.IsOpen && button.Text == "Disconnect")
            {
                ListConnections.Enabled = true;
                ButtonScan.Enabled = true;
                ToolStripConnectionStatus.BackColor = Color.Gray;
                ToolStripConnectionStatus.Text = "Disconnected";
                _controller.Disconnect();
                button.Text = "Connect";
            }
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            
        }

        private void Debug_Connect_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var selected = ListConnections.SelectedItems;
            var ToolStripConnectionStatus = statusStrip1.Items["ToolStripConnectionStatus"];
            if (_controller.port.IsOpen == false && button.Text == "Connect")
            {
                button.Text = "Disconnect";
                ButtonScan.Enabled = false;
                ListConnections.Enabled = false;

                ToolStripConnectionStatus.BackColor = Color.Orange;
                ToolStripConnectionStatus.Text = "Connecting...";

                _controller.SetConnectionString("COM1");
                try
                {
                    _controller.Connect();
                    ToolStripConnectionStatus.BackColor = Color.SpringGreen;
                    ToolStripConnectionStatus.Text = "Connected";
                }
                catch (Exception exception)
                {
                    ListConnections.Enabled = true;
                    ButtonScan.Enabled = true;

                    _controller.Disconnect();
                    button.Text = "Connect";
                    ToolStripConnectionStatus.BackColor = Color.Red;
                    ToolStripConnectionStatus.Text = "Error";
                    Debug.WriteLine(exception);
                }
            }
            else if (_controller.port.IsOpen && button.Text == "Disconnect")
            {
                ListConnections.Enabled = true;
                ButtonScan.Enabled = true;
                ToolStripConnectionStatus.BackColor = Color.Gray;
                ToolStripConnectionStatus.Text = "Disconnected";
                _controller.Disconnect();
                button.Text = "Connect";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsNumber(ch) && !char.IsLetter(ch) && ch != 8 && ch != 46)  //8 is Backspace key; 46 is Delete key. This statement accepts dot key. 
                                                                                  //if (!char.IsLetterOrDigit(ch) && !char.IsLetter(ch) && ch != 8 && ch != 46)   //This statement accepts dot key. 
            {
                e.Handled = true;
                MessageBox.Show("Only accept digital character or letter.");
            }
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (_controller.port.IsOpen)
                _controller.SetParameter(ParameterNumber.CYCLETIME, BitConverter.GetBytes( UInt32.Parse(textBox1.Text)));
        }

        private void ButtonInitialize_Click(object sender, EventArgs e)
        {
            _controller.Initialize();
        }

        
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false; 
            ButtonStop.Enabled = true;
            Plot1.Plot.Clear();
            Plots.Clear();
            recording = true;
            StartTime = DateTime.UtcNow.Ticks;
            _controller.DOUBLE_DataAvailable += _controller_DataAvailable<double>; 
            _controller.FLOAT_DataAvailable += _controller_DataAvailable<float>;
            _controller.INT8_DataAvailable += _controller_DataAvailable<sbyte>;
            _controller.INT16_DataAvailable += _controller_DataAvailable<Int16>;
            _controller.INT32_DataAvailable += _controller_DataAvailable<Int32>;
            _controller.INT64_DataAvailable +=  _controller_DataAvailable<Int64>;
            _controller.UINT8_DataAvailable += _controller_DataAvailable<byte>;
            _controller.UINT16_DataAvailable += _controller_DataAvailable<UInt16>;
            _controller.UINT32_DataAvailable += _controller_DataAvailable<UInt32>;
            _controller.UINT64_DataAvailable += _controller_DataAvailable<UInt64>;

        }

        

        private void _controller_DataAvailable<T>(object sender, ushort MeassurementSet, T bytes) where T:struct,IComparable
        {
            if (!recording)
                return;
            if (!Plots.ContainsKey(MeassurementSet))
            {
                var plt = new SignalPlotXYGeneric<long, T>();
                var tickList = new List<long>();
                var valuesList = new List<T>();
                plt.Label = $"Signal {MeassurementSet}";
                plt.Color = Plot1.Plot.GetNextColor();
                Plot1.Plot.Add(plt);
                Plots.Add(MeassurementSet, (plt, tickList, valuesList));
            }

            (var p, var ticks, var v) = Plots[MeassurementSet];
            
            var plot = (SignalPlotXYGeneric<long, T>)p ;
            var values = v as List<T>;

            ticks.Add((DateTime.UtcNow.Ticks - StartTime)/10000000);
            values.Add(bytes);

            plot.Xs = ticks.ToArray();
            plot.Ys = values.ToArray();
            plot.MaxRenderIndex = ticks.Count-1;

            Plot1.Invoke(() => { Plot1.Refresh(); }); 
        }

        

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
            recording = false;
            _controller.DOUBLE_DataAvailable -= _controller_DataAvailable<double>;
            _controller.FLOAT_DataAvailable -=  _controller_DataAvailable<float>;
            _controller.INT8_DataAvailable -=   _controller_DataAvailable<sbyte>;
            _controller.INT16_DataAvailable -=  _controller_DataAvailable<Int16>;
            _controller.INT32_DataAvailable -=  _controller_DataAvailable<Int32>;
            _controller.INT64_DataAvailable -=   _controller_DataAvailable<Int64>;
            _controller.UINT8_DataAvailable -=  _controller_DataAvailable<byte>;
            _controller.UINT16_DataAvailable -= _controller_DataAvailable<UInt16>;
            _controller.UINT32_DataAvailable -= _controller_DataAvailable<UInt32>;
            _controller.UINT64_DataAvailable -= _controller_DataAvailable<UInt64>;
        }
    }
}