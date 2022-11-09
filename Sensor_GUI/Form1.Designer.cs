namespace SAI_4
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PageMeassuring = new System.Windows.Forms.TabPage();
            this.checkBoxAutoZoom = new System.Windows.Forms.CheckBox();
            this.Plot1 = new ScottPlot.FormsPlot();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.PageConnection = new System.Windows.Forms.TabPage();
            this.ListConnections = new System.Windows.Forms.ListView();
            this.PanelUSBInfo = new System.Windows.Forms.Panel();
            this.Debug_Connect = new System.Windows.Forms.Button();
            this.ListProperties = new System.Windows.Forms.ListView();
            this.ColumnProperty = new System.Windows.Forms.ColumnHeader();
            this.ColumnValue = new System.Windows.Forms.ColumnHeader();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonScan = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PageController = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonInitialize = new System.Windows.Forms.Button();
            this.PageExperiments = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.PageMeassuring.SuspendLayout();
            this.PageConnection.SuspendLayout();
            this.PanelUSBInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.PageController.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageMeassuring
            // 
            this.PageMeassuring.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PageMeassuring.Controls.Add(this.checkBoxAutoZoom);
            this.PageMeassuring.Controls.Add(this.Plot1);
            this.PageMeassuring.Controls.Add(this.ButtonStart);
            this.PageMeassuring.Controls.Add(this.ButtonStop);
            this.PageMeassuring.Location = new System.Drawing.Point(4, 24);
            this.PageMeassuring.Name = "PageMeassuring";
            this.PageMeassuring.Padding = new System.Windows.Forms.Padding(3);
            this.PageMeassuring.Size = new System.Drawing.Size(776, 408);
            this.PageMeassuring.TabIndex = 1;
            this.PageMeassuring.Text = "Meassuring";
            // 
            // checkBoxAutoZoom
            // 
            this.checkBoxAutoZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoZoom.Location = new System.Drawing.Point(663, 102);
            this.checkBoxAutoZoom.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAutoZoom.Name = "checkBoxAutoZoom";
            this.checkBoxAutoZoom.Size = new System.Drawing.Size(108, 19);
            this.checkBoxAutoZoom.TabIndex = 5;
            this.checkBoxAutoZoom.Text = "AutoZoom";
            this.checkBoxAutoZoom.UseVisualStyleBackColor = true;
            // 
            // Plot1
            // 
            this.Plot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plot1.Location = new System.Drawing.Point(3, 3);
            this.Plot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Plot1.Name = "Plot1";
            this.Plot1.Size = new System.Drawing.Size(656, 402);
            this.Plot1.TabIndex = 4;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.Enabled = false;
            this.ButtonStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonStart.Location = new System.Drawing.Point(663, 6);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(113, 42);
            this.ButtonStart.TabIndex = 2;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStop.Enabled = false;
            this.ButtonStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStop.Location = new System.Drawing.Point(663, 54);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(113, 42);
            this.ButtonStop.TabIndex = 3;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // PageConnection
            // 
            this.PageConnection.BackColor = System.Drawing.Color.LightGray;
            this.PageConnection.Controls.Add(this.ListConnections);
            this.PageConnection.Controls.Add(this.PanelUSBInfo);
            this.PageConnection.Controls.Add(this.ButtonScan);
            this.PageConnection.Location = new System.Drawing.Point(4, 24);
            this.PageConnection.Margin = new System.Windows.Forms.Padding(0);
            this.PageConnection.Name = "PageConnection";
            this.PageConnection.Size = new System.Drawing.Size(776, 408);
            this.PageConnection.TabIndex = 0;
            this.PageConnection.Text = "Connections";
            // 
            // ListConnections
            // 
            this.ListConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListConnections.FullRowSelect = true;
            this.ListConnections.LabelWrap = false;
            this.ListConnections.Location = new System.Drawing.Point(0, 30);
            this.ListConnections.Margin = new System.Windows.Forms.Padding(0);
            this.ListConnections.MultiSelect = false;
            this.ListConnections.Name = "ListConnections";
            this.ListConnections.Size = new System.Drawing.Size(180, 375);
            this.ListConnections.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListConnections.TabIndex = 2;
            this.ListConnections.UseCompatibleStateImageBehavior = false;
            this.ListConnections.View = System.Windows.Forms.View.List;
            this.ListConnections.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListConnections_ItemSelectionChanged);
            // 
            // PanelUSBInfo
            // 
            this.PanelUSBInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelUSBInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelUSBInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelUSBInfo.Controls.Add(this.Debug_Connect);
            this.PanelUSBInfo.Controls.Add(this.ListProperties);
            this.PanelUSBInfo.Controls.Add(this.ButtonConnect);
            this.PanelUSBInfo.Location = new System.Drawing.Point(183, 0);
            this.PanelUSBInfo.Name = "PanelUSBInfo";
            this.PanelUSBInfo.Size = new System.Drawing.Size(593, 408);
            this.PanelUSBInfo.TabIndex = 2;
            // 
            // Debug_Connect
            // 
            this.Debug_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Debug_Connect.Location = new System.Drawing.Point(430, 373);
            this.Debug_Connect.Name = "Debug_Connect";
            this.Debug_Connect.Size = new System.Drawing.Size(160, 32);
            this.Debug_Connect.TabIndex = 2;
            this.Debug_Connect.Text = "Connect";
            this.Debug_Connect.UseVisualStyleBackColor = true;
            this.Debug_Connect.Click += new System.EventHandler(this.Debug_Connect_Click);
            // 
            // ListProperties
            // 
            this.ListProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnProperty,
            this.ColumnValue});
            this.ListProperties.FullRowSelect = true;
            this.ListProperties.GridLines = true;
            this.ListProperties.Location = new System.Drawing.Point(3, 3);
            this.ListProperties.MultiSelect = false;
            this.ListProperties.Name = "ListProperties";
            this.ListProperties.Size = new System.Drawing.Size(421, 402);
            this.ListProperties.TabIndex = 1;
            this.ListProperties.UseCompatibleStateImageBehavior = false;
            this.ListProperties.View = System.Windows.Forms.View.Details;
            this.ListProperties.Resize += new System.EventHandler(this.ListProperties_Resize);
            // 
            // ColumnProperty
            // 
            this.ColumnProperty.Text = "Property";
            this.ColumnProperty.Width = 200;
            // 
            // ColumnValue
            // 
            this.ColumnValue.Text = "Value";
            this.ColumnValue.Width = 200;
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonConnect.Location = new System.Drawing.Point(430, 3);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(160, 32);
            this.ButtonConnect.TabIndex = 0;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ButtonScan
            // 
            this.ButtonScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonScan.Location = new System.Drawing.Point(0, 0);
            this.ButtonScan.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonScan.Name = "ButtonScan";
            this.ButtonScan.Size = new System.Drawing.Size(180, 30);
            this.ButtonScan.TabIndex = 1;
            this.ButtonScan.Text = "Scan";
            this.ButtonScan.UseVisualStyleBackColor = true;
            this.ButtonScan.Click += new System.EventHandler(this.ButtonScan_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.PageConnection);
            this.tabControl1.Controls.Add(this.PageController);
            this.tabControl1.Controls.Add(this.PageMeassuring);
            this.tabControl1.Controls.Add(this.PageExperiments);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 436);
            this.tabControl1.TabIndex = 2;
            // 
            // PageController
            // 
            this.PageController.Controls.Add(this.tableLayoutPanel1);
            this.PageController.Location = new System.Drawing.Point(4, 24);
            this.PageController.Name = "PageController";
            this.PageController.Size = new System.Drawing.Size(776, 408);
            this.PageController.TabIndex = 3;
            this.PageController.Text = "Controller";
            this.PageController.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonApply, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonInitialize, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(375, 402);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 3);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "5000";
            this.textBox1.Size = new System.Drawing.Size(146, 23);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "5000";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(221, 3);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(151, 23);
            this.ButtonApply.TabIndex = 9;
            this.ButtonApply.Text = "Apply";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cycletime";
            // 
            // ButtonInitialize
            // 
            this.ButtonInitialize.Location = new System.Drawing.Point(221, 32);
            this.ButtonInitialize.Name = "ButtonInitialize";
            this.ButtonInitialize.Size = new System.Drawing.Size(151, 23);
            this.ButtonInitialize.TabIndex = 10;
            this.ButtonInitialize.Text = "Initialize";
            this.ButtonInitialize.UseVisualStyleBackColor = true;
            this.ButtonInitialize.Click += new System.EventHandler(this.ButtonInitialize_Click);
            // 
            // PageExperiments
            // 
            this.PageExperiments.Location = new System.Drawing.Point(4, 24);
            this.PageExperiments.Name = "PageExperiments";
            this.PageExperiments.Size = new System.Drawing.Size(776, 408);
            this.PageExperiments.TabIndex = 2;
            this.PageExperiments.Text = "Experiments";
            this.PageExperiments.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatus,
            this.ToolStripConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ToolStripStatus
            // 
            this.ToolStripStatus.Name = "ToolStripStatus";
            this.ToolStripStatus.Size = new System.Drawing.Size(690, 17);
            this.ToolStripStatus.Spring = true;
            // 
            // ToolStripConnectionStatus
            // 
            this.ToolStripConnectionStatus.BackColor = System.Drawing.Color.Gray;
            this.ToolStripConnectionStatus.Name = "ToolStripConnectionStatus";
            this.ToolStripConnectionStatus.Size = new System.Drawing.Size(79, 17);
            this.ToolStripConnectionStatus.Text = "Disconnected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Ozone Meassuring";
            this.PageMeassuring.ResumeLayout(false);
            this.PageConnection.ResumeLayout(false);
            this.PanelUSBInfo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.PageController.ResumeLayout(false);
            this.PageController.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabPage PageMeassuring;
        private Button ButtonStart;
        private Button ButtonStop;
        private TabPage PageConnection;
        private TabControl tabControl1;
        private Button ButtonScan;
        private Panel PanelUSBInfo;
        private ScottPlot.FormsPlot Plot1;
        private TabPage PageExperiments;
        private Button ButtonConnect;
        private ListView ListProperties;
        private ColumnHeader ColumnProperty;
        private ColumnHeader ColumnValue;
        private ListView ListConnections;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel ToolStripStatus;
        private ToolStripStatusLabel ToolStripConnectionStatus;
        private Button Debug_Connect;
        private TabPage PageController;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private Button ButtonApply;
        private Label label1;
        private Button ButtonInitialize;
        private CheckBox checkBoxAutoZoom;
    }
}