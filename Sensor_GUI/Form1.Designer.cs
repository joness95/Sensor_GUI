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
            this.Plot1 = new ScottPlot.FormsPlot();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.PageSettings = new System.Windows.Forms.TabPage();
            this.ListConnections = new System.Windows.Forms.ListView();
            this.PanelUSBInfo = new System.Windows.Forms.Panel();
            this.ListProperties = new System.Windows.Forms.ListView();
            this.ColumnProperty = new System.Windows.Forms.ColumnHeader();
            this.ColumnValue = new System.Windows.Forms.ColumnHeader();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonScan = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PageExperiments = new System.Windows.Forms.TabPage();
            this.button_test = new System.Windows.Forms.Button();
            this.PageMeassuring.SuspendLayout();
            this.PageSettings.SuspendLayout();
            this.PanelUSBInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageMeassuring
            // 
            this.PageMeassuring.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PageMeassuring.Controls.Add(this.button_test);
            this.PageMeassuring.Controls.Add(this.Plot1);
            this.PageMeassuring.Controls.Add(this.ButtonStart);
            this.PageMeassuring.Controls.Add(this.ButtonStop);
            this.PageMeassuring.Location = new System.Drawing.Point(4, 24);
            this.PageMeassuring.Name = "PageMeassuring";
            this.PageMeassuring.Padding = new System.Windows.Forms.Padding(3);
            this.PageMeassuring.Size = new System.Drawing.Size(776, 433);
            this.PageMeassuring.TabIndex = 1;
            this.PageMeassuring.Text = "Meassuring";
            this.PageMeassuring.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // Plot1
            // 
            this.Plot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plot1.Location = new System.Drawing.Point(3, 3);
            this.Plot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Plot1.Name = "Plot1";
            this.Plot1.Size = new System.Drawing.Size(656, 427);
            this.Plot1.TabIndex = 4;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonStart.Location = new System.Drawing.Point(663, 6);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(113, 42);
            this.ButtonStart.TabIndex = 2;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            // 
            // ButtonStop
            // 
            this.ButtonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStop.Location = new System.Drawing.Point(663, 54);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(113, 42);
            this.ButtonStop.TabIndex = 3;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            // 
            // PageSettings
            // 
            this.PageSettings.BackColor = System.Drawing.Color.LightGray;
            this.PageSettings.Controls.Add(this.ListConnections);
            this.PageSettings.Controls.Add(this.PanelUSBInfo);
            this.PageSettings.Controls.Add(this.ButtonScan);
            this.PageSettings.Location = new System.Drawing.Point(4, 24);
            this.PageSettings.Margin = new System.Windows.Forms.Padding(0);
            this.PageSettings.Name = "PageSettings";
            this.PageSettings.Size = new System.Drawing.Size(776, 433);
            this.PageSettings.TabIndex = 0;
            this.PageSettings.Text = "Settings";
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
            this.ListConnections.Size = new System.Drawing.Size(180, 403);
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
            this.PanelUSBInfo.Controls.Add(this.ListProperties);
            this.PanelUSBInfo.Controls.Add(this.ButtonConnect);
            this.PanelUSBInfo.Location = new System.Drawing.Point(183, 0);
            this.PanelUSBInfo.Name = "PanelUSBInfo";
            this.PanelUSBInfo.Size = new System.Drawing.Size(593, 433);
            this.PanelUSBInfo.TabIndex = 2;
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
            this.ListProperties.Size = new System.Drawing.Size(421, 430);
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
            this.tabControl1.Controls.Add(this.PageSettings);
            this.tabControl1.Controls.Add(this.PageMeassuring);
            this.tabControl1.Controls.Add(this.PageExperiments);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 461);
            this.tabControl1.TabIndex = 2;
            // 
            // PageExperiments
            // 
            this.PageExperiments.Location = new System.Drawing.Point(4, 24);
            this.PageExperiments.Name = "PageExperiments";
            this.PageExperiments.Size = new System.Drawing.Size(776, 433);
            this.PageExperiments.TabIndex = 2;
            this.PageExperiments.Text = "Experiments";
            this.PageExperiments.UseVisualStyleBackColor = true;
            // 
            // button_test
            // 
            this.button_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_test.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_test.Location = new System.Drawing.Point(660, 383);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(113, 42);
            this.button_test.TabIndex = 5;
            this.button_test.Text = "Stop";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Ozone Meassuring";
            this.PageMeassuring.ResumeLayout(false);
            this.PageSettings.ResumeLayout(false);
            this.PanelUSBInfo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage PageMeassuring;
        private Button ButtonStart;
        private Button ButtonStop;
        private TabPage PageSettings;
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
        private Button button_test;
    }
}