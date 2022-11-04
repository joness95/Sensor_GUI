using System.Diagnostics;
using System.IO.Ports;
using System.Management;
using Sensor_GUI.Controllers;
using Sensor_GUI.Helper;
using Sensor_GUI.Messages;

namespace SAI_4
{
    public partial class MainForm : Form
    {
        Dictionary<string, SerialPortInfo> _ports = new Dictionary<string, SerialPortInfo>();
        ArduinoController _controller = new ArduinoController();
        public MainForm()
        {
            InitializeComponent();
            ListProperties.Columns[0].Width = this.ListProperties.Size.Width / 2 - 1;
            ListProperties.Columns[1].Width = this.ListProperties.Size.Width / 2 - 1;
            _controller.ParamterRecieved += ((object sender, ParameterNumber ParameterNumber, byte[] Value) => {
                Debug.WriteLine($"Paramternumber {ParameterNumber} - Value {BitConverter.ToString(Value)}");
            });
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
            _controller.ReadParameter(ParameterNumber.CYCLETIME);
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
    }
}