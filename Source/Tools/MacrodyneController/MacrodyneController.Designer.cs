namespace MacrodyneController
{
    partial class MacrodyneController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacrodyneController));
            this.ComboBoxSerialStopBits = new System.Windows.Forms.ComboBox();
            this.ComboBoxSerialParities = new System.Windows.Forms.ComboBox();
            this.ComboBoxSerialBaudRates = new System.Windows.Forms.ComboBox();
            this.ComboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.ComboBoxCommands = new System.Windows.Forms.ComboBox();
            this.TextBoxSerialDataBits = new System.Windows.Forms.MaskedTextBox();
            this.ButtonAddCommand = new System.Windows.Forms.Button();
            this.CheckBoxSerialDTR = new System.Windows.Forms.CheckBox();
            this.CheckBoxSerialRTS = new System.Windows.Forms.CheckBox();
            this.LabelPort = new System.Windows.Forms.Label();
            this.LabelBaudRate = new System.Windows.Forms.Label();
            this.LabelParity = new System.Windows.Forms.Label();
            this.LabelStopBits = new System.Windows.Forms.Label();
            this.LabelDataBits = new System.Windows.Forms.Label();
            this.LabelCommand = new System.Windows.Forms.Label();
            this.TextBoxBytesToSend = new System.Windows.Forms.TextBox();
            this.LabelBytesToSend = new System.Windows.Forms.Label();
            this.LabelBytesReceived = new System.Windows.Forms.Label();
            this.TextBoxBytesReceived = new System.Windows.Forms.TextBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonAddInput = new System.Windows.Forms.Button();
            this.ComboBoxDataInputs = new System.Windows.Forms.ComboBox();
            this.TextBoxData = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxByteEncodingDisplayFormats = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxStatus = new System.Windows.Forms.TextBox();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.LabelInDecimal = new System.Windows.Forms.Label();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.LinkLabelMacrodyne = new System.Windows.Forms.LinkLabel();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBoxSerialStopBits
            // 
            this.ComboBoxSerialStopBits.Location = new System.Drawing.Point(230, 21);
            this.ComboBoxSerialStopBits.Name = "ComboBoxSerialStopBits";
            this.ComboBoxSerialStopBits.Size = new System.Drawing.Size(85, 21);
            this.ComboBoxSerialStopBits.TabIndex = 7;
            // 
            // ComboBoxSerialParities
            // 
            this.ComboBoxSerialParities.Location = new System.Drawing.Point(85, 76);
            this.ComboBoxSerialParities.Name = "ComboBoxSerialParities";
            this.ComboBoxSerialParities.Size = new System.Drawing.Size(85, 21);
            this.ComboBoxSerialParities.TabIndex = 5;
            // 
            // ComboBoxSerialBaudRates
            // 
            this.ComboBoxSerialBaudRates.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400",
            "1200"});
            this.ComboBoxSerialBaudRates.Location = new System.Drawing.Point(85, 48);
            this.ComboBoxSerialBaudRates.Name = "ComboBoxSerialBaudRates";
            this.ComboBoxSerialBaudRates.Size = new System.Drawing.Size(85, 21);
            this.ComboBoxSerialBaudRates.TabIndex = 3;
            // 
            // ComboBoxSerialPorts
            // 
            this.ComboBoxSerialPorts.Location = new System.Drawing.Point(85, 21);
            this.ComboBoxSerialPorts.Name = "ComboBoxSerialPorts";
            this.ComboBoxSerialPorts.Size = new System.Drawing.Size(85, 21);
            this.ComboBoxSerialPorts.TabIndex = 1;
            // 
            // ComboBoxCommands
            // 
            this.ComboBoxCommands.Location = new System.Drawing.Point(22, 132);
            this.ComboBoxCommands.Name = "ComboBoxCommands";
            this.ComboBoxCommands.Size = new System.Drawing.Size(208, 21);
            this.ComboBoxCommands.TabIndex = 14;
            // 
            // TextBoxSerialDataBits
            // 
            this.TextBoxSerialDataBits.AllowPromptAsInput = false;
            this.TextBoxSerialDataBits.HidePromptOnLeave = true;
            this.TextBoxSerialDataBits.Location = new System.Drawing.Point(230, 48);
            this.TextBoxSerialDataBits.Mask = "00";
            this.TextBoxSerialDataBits.Name = "TextBoxSerialDataBits";
            this.TextBoxSerialDataBits.Size = new System.Drawing.Size(22, 20);
            this.TextBoxSerialDataBits.TabIndex = 9;
            this.TextBoxSerialDataBits.Text = "8";
            this.TextBoxSerialDataBits.ValidatingType = typeof(int);
            // 
            // ButtonAddCommand
            // 
            this.ButtonAddCommand.Location = new System.Drawing.Point(239, 130);
            this.ButtonAddCommand.Name = "ButtonAddCommand";
            this.ButtonAddCommand.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddCommand.TabIndex = 15;
            this.ButtonAddCommand.Text = "Add";
            this.ButtonAddCommand.UseVisualStyleBackColor = true;
            this.ButtonAddCommand.Click += new System.EventHandler(this.ButtonAddCommand_Click);
            // 
            // CheckBoxSerialDTR
            // 
            this.CheckBoxSerialDTR.AutoSize = true;
            this.CheckBoxSerialDTR.Location = new System.Drawing.Point(191, 78);
            this.CheckBoxSerialDTR.Name = "CheckBoxSerialDTR";
            this.CheckBoxSerialDTR.Size = new System.Drawing.Size(49, 17);
            this.CheckBoxSerialDTR.TabIndex = 10;
            this.CheckBoxSerialDTR.Text = "DTR";
            this.CheckBoxSerialDTR.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSerialRTS
            // 
            this.CheckBoxSerialRTS.AutoSize = true;
            this.CheckBoxSerialRTS.Location = new System.Drawing.Point(247, 78);
            this.CheckBoxSerialRTS.Name = "CheckBoxSerialRTS";
            this.CheckBoxSerialRTS.Size = new System.Drawing.Size(48, 17);
            this.CheckBoxSerialRTS.TabIndex = 11;
            this.CheckBoxSerialRTS.Text = "RTS";
            this.CheckBoxSerialRTS.UseVisualStyleBackColor = true;
            // 
            // LabelPort
            // 
            this.LabelPort.Location = new System.Drawing.Point(15, 20);
            this.LabelPort.Name = "LabelPort";
            this.LabelPort.Size = new System.Drawing.Size(68, 20);
            this.LabelPort.TabIndex = 0;
            this.LabelPort.Text = "&Port:";
            this.LabelPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelBaudRate
            // 
            this.LabelBaudRate.Location = new System.Drawing.Point(15, 47);
            this.LabelBaudRate.Name = "LabelBaudRate";
            this.LabelBaudRate.Size = new System.Drawing.Size(68, 20);
            this.LabelBaudRate.TabIndex = 2;
            this.LabelBaudRate.Text = "&Baud Rate:";
            this.LabelBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelParity
            // 
            this.LabelParity.Location = new System.Drawing.Point(15, 75);
            this.LabelParity.Name = "LabelParity";
            this.LabelParity.Size = new System.Drawing.Size(68, 20);
            this.LabelParity.TabIndex = 4;
            this.LabelParity.Text = "P&arity:";
            this.LabelParity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelStopBits
            // 
            this.LabelStopBits.Location = new System.Drawing.Point(162, 20);
            this.LabelStopBits.Name = "LabelStopBits";
            this.LabelStopBits.Size = new System.Drawing.Size(68, 20);
            this.LabelStopBits.TabIndex = 6;
            this.LabelStopBits.Text = "S&top Bits:";
            this.LabelStopBits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDataBits
            // 
            this.LabelDataBits.Location = new System.Drawing.Point(162, 47);
            this.LabelDataBits.Name = "LabelDataBits";
            this.LabelDataBits.Size = new System.Drawing.Size(68, 20);
            this.LabelDataBits.TabIndex = 8;
            this.LabelDataBits.Text = "Da&ta Bits:";
            this.LabelDataBits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelCommand
            // 
            this.LabelCommand.Location = new System.Drawing.Point(19, 109);
            this.LabelCommand.Name = "LabelCommand";
            this.LabelCommand.Size = new System.Drawing.Size(168, 20);
            this.LabelCommand.TabIndex = 13;
            this.LabelCommand.Text = "Device Set / Request Co&mmand:";
            this.LabelCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxBytesToSend
            // 
            this.TextBoxBytesToSend.Location = new System.Drawing.Point(22, 240);
            this.TextBoxBytesToSend.Multiline = true;
            this.TextBoxBytesToSend.Name = "TextBoxBytesToSend";
            this.TextBoxBytesToSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxBytesToSend.Size = new System.Drawing.Size(208, 53);
            this.TextBoxBytesToSend.TabIndex = 24;
            // 
            // LabelBytesToSend
            // 
            this.LabelBytesToSend.AutoSize = true;
            this.LabelBytesToSend.Location = new System.Drawing.Point(22, 221);
            this.LabelBytesToSend.Name = "LabelBytesToSend";
            this.LabelBytesToSend.Size = new System.Drawing.Size(74, 13);
            this.LabelBytesToSend.TabIndex = 23;
            this.LabelBytesToSend.Text = "Bytes to send:";
            // 
            // LabelBytesReceived
            // 
            this.LabelBytesReceived.AutoSize = true;
            this.LabelBytesReceived.Location = new System.Drawing.Point(22, 299);
            this.LabelBytesReceived.Name = "LabelBytesReceived";
            this.LabelBytesReceived.Size = new System.Drawing.Size(80, 13);
            this.LabelBytesReceived.TabIndex = 25;
            this.LabelBytesReceived.Text = "Bytes received:";
            // 
            // TextBoxBytesReceived
            // 
            this.TextBoxBytesReceived.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxBytesReceived.Location = new System.Drawing.Point(22, 318);
            this.TextBoxBytesReceived.Multiline = true;
            this.TextBoxBytesReceived.Name = "TextBoxBytesReceived";
            this.TextBoxBytesReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxBytesReceived.Size = new System.Drawing.Size(289, 53);
            this.TextBoxBytesReceived.TabIndex = 26;
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonConnect.Location = new System.Drawing.Point(488, 17);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(75, 23);
            this.ButtonConnect.TabIndex = 12;
            this.ButtonConnect.Text = "&Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(239, 240);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 21;
            this.ButtonClear.Text = "C&lear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(239, 270);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 22;
            this.ButtonSend.Text = "&Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(149, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "&Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonAddInput
            // 
            this.ButtonAddInput.Location = new System.Drawing.Point(239, 177);
            this.ButtonAddInput.Name = "ButtonAddInput";
            this.ButtonAddInput.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddInput.TabIndex = 20;
            this.ButtonAddInput.Text = "Add";
            this.ButtonAddInput.UseVisualStyleBackColor = true;
            this.ButtonAddInput.Click += new System.EventHandler(this.ButtonAddInput_Click);
            // 
            // ComboBoxDataInputs
            // 
            this.ComboBoxDataInputs.Location = new System.Drawing.Point(22, 179);
            this.ComboBoxDataInputs.Name = "ComboBoxDataInputs";
            this.ComboBoxDataInputs.Size = new System.Drawing.Size(116, 21);
            this.ComboBoxDataInputs.TabIndex = 17;
            this.ComboBoxDataInputs.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDataInputs_SelectedIndexChanged);
            // 
            // TextBoxData
            // 
            this.TextBoxData.AllowPromptAsInput = false;
            this.TextBoxData.AsciiOnly = true;
            this.TextBoxData.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxData.HidePromptOnLeave = true;
            this.TextBoxData.Location = new System.Drawing.Point(152, 178);
            this.TextBoxData.Mask = "CCCCCCCC";
            this.TextBoxData.Name = "TextBoxData";
            this.TextBoxData.Size = new System.Drawing.Size(75, 22);
            this.TextBoxData.TabIndex = 19;
            this.TextBoxData.Text = "0";
            this.TextBoxData.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.TextBoxData_TypeValidationCompleted);
            this.TextBoxData.Leave += new System.EventHandler(this.TextBoxData_Leave);
            this.TextBoxData.Enter += new System.EventHandler(this.TextBoxData_Enter);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Data Input Co&mmand:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxByteEncodingDisplayFormats
            // 
            this.ComboBoxByteEncodingDisplayFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBoxByteEncodingDisplayFormats.Items.AddRange(new object[] {
            "Hexadecimal",
            "Decimal",
            "Big Endian Binary",
            "Little Endian Binary",
            "Base64",
            "ASCII Extraction"});
            this.ComboBoxByteEncodingDisplayFormats.Location = new System.Drawing.Point(22, 392);
            this.ComboBoxByteEncodingDisplayFormats.Name = "ComboBoxByteEncodingDisplayFormats";
            this.ComboBoxByteEncodingDisplayFormats.Size = new System.Drawing.Size(130, 21);
            this.ComboBoxByteEncodingDisplayFormats.TabIndex = 27;
            this.ComboBoxByteEncodingDisplayFormats.SelectedIndexChanged += new System.EventHandler(this.ComboBoxByteEncodingDisplayFormats_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Byte visualization:";
            // 
            // TextBoxStatus
            // 
            this.TextBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxStatus.Location = new System.Drawing.Point(331, 78);
            this.TextBoxStatus.Multiline = true;
            this.TextBoxStatus.Name = "TextBoxStatus";
            this.TextBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxStatus.Size = new System.Drawing.Size(232, 309);
            this.TextBoxStatus.TabIndex = 29;
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(328, 62);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(40, 13);
            this.LabelStatus.TabIndex = 30;
            this.LabelStatus.Text = "Status:";
            // 
            // LabelVersion
            // 
            this.LabelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelVersion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVersion.Location = new System.Drawing.Point(411, 43);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(152, 14);
            this.LabelVersion.TabIndex = 31;
            this.LabelVersion.Text = "Version: 0.0.0.0";
            this.LabelVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelInDecimal
            // 
            this.LabelInDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInDecimal.Location = new System.Drawing.Point(153, 200);
            this.LabelInDecimal.Name = "LabelInDecimal";
            this.LabelInDecimal.Size = new System.Drawing.Size(74, 13);
            this.LabelInDecimal.TabIndex = 32;
            this.LabelInDecimal.Text = "In decimal";
            this.LabelInDecimal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelDescription
            // 
            this.LabelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelDescription.Location = new System.Drawing.Point(364, 20);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(121, 26);
            this.LabelDescription.TabIndex = 33;
            this.LabelDescription.Text = "GPA Macrodyne 1690M Host Utility";
            this.LabelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LinkLabelMacrodyne
            // 
            this.LinkLabelMacrodyne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkLabelMacrodyne.Location = new System.Drawing.Point(331, 390);
            this.LinkLabelMacrodyne.Name = "LinkLabelMacrodyne";
            this.LinkLabelMacrodyne.Size = new System.Drawing.Size(232, 23);
            this.LinkLabelMacrodyne.TabIndex = 34;
            this.LinkLabelMacrodyne.TabStop = true;
            this.LinkLabelMacrodyne.Text = "http://www.macrodyneUSA.com/";
            this.LinkLabelMacrodyne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkLabelMacrodyne.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelMacrodyne_LinkClicked);
            // 
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxLogo.Image")));
            this.PictureBoxLogo.Location = new System.Drawing.Point(331, 16);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(32, 32);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxLogo.TabIndex = 35;
            this.PictureBoxLogo.TabStop = false;
            this.PictureBoxLogo.Click += new System.EventHandler(this.PictureBoxLogo_Click);
            // 
            // MacrodyneController
            // 
            this.AcceptButton = this.ButtonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 431);
            this.Controls.Add(this.LabelDescription);
            this.Controls.Add(this.PictureBoxLogo);
            this.Controls.Add(this.LinkLabelMacrodyne);
            this.Controls.Add(this.TextBoxData);
            this.Controls.Add(this.LabelInDecimal);
            this.Controls.Add(this.LabelVersion);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.TextBoxStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboBoxByteEncodingDisplayFormats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonAddInput);
            this.Controls.Add(this.ComboBoxDataInputs);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.LabelBytesReceived);
            this.Controls.Add(this.TextBoxBytesReceived);
            this.Controls.Add(this.LabelBytesToSend);
            this.Controls.Add(this.TextBoxBytesToSend);
            this.Controls.Add(this.LabelCommand);
            this.Controls.Add(this.CheckBoxSerialRTS);
            this.Controls.Add(this.CheckBoxSerialDTR);
            this.Controls.Add(this.ButtonAddCommand);
            this.Controls.Add(this.TextBoxSerialDataBits);
            this.Controls.Add(this.ComboBoxCommands);
            this.Controls.Add(this.ComboBoxSerialStopBits);
            this.Controls.Add(this.ComboBoxSerialParities);
            this.Controls.Add(this.ComboBoxSerialBaudRates);
            this.Controls.Add(this.ComboBoxSerialPorts);
            this.Controls.Add(this.LabelDataBits);
            this.Controls.Add(this.LabelStopBits);
            this.Controls.Add(this.LabelParity);
            this.Controls.Add(this.LabelBaudRate);
            this.Controls.Add(this.LabelPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(590, 465);
            this.Name = "MacrodyneController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Macrodyne Controller";
            this.Load += new System.EventHandler(this.MacrodyneController_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MacrodyneController_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox ComboBoxSerialStopBits;
        internal System.Windows.Forms.ComboBox ComboBoxSerialParities;
        internal System.Windows.Forms.ComboBox ComboBoxSerialBaudRates;
        internal System.Windows.Forms.ComboBox ComboBoxSerialPorts;
        internal System.Windows.Forms.ComboBox ComboBoxCommands;
        private System.Windows.Forms.MaskedTextBox TextBoxSerialDataBits;
        private System.Windows.Forms.Button ButtonAddCommand;
        private System.Windows.Forms.CheckBox CheckBoxSerialDTR;
        private System.Windows.Forms.CheckBox CheckBoxSerialRTS;
        private System.Windows.Forms.Label LabelPort;
        private System.Windows.Forms.Label LabelBaudRate;
        private System.Windows.Forms.Label LabelParity;
        private System.Windows.Forms.Label LabelStopBits;
        private System.Windows.Forms.Label LabelDataBits;
        private System.Windows.Forms.Label LabelCommand;
        private System.Windows.Forms.TextBox TextBoxBytesToSend;
        private System.Windows.Forms.Label LabelBytesToSend;
        private System.Windows.Forms.Label LabelBytesReceived;
        private System.Windows.Forms.TextBox TextBoxBytesReceived;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonAddInput;
        internal System.Windows.Forms.ComboBox ComboBoxDataInputs;
        private System.Windows.Forms.MaskedTextBox TextBoxData;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox ComboBoxByteEncodingDisplayFormats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxStatus;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.Label LabelInDecimal;
        private System.Windows.Forms.Label LabelDescription;
        private System.Windows.Forms.LinkLabel LinkLabelMacrodyne;
        private System.Windows.Forms.PictureBox PictureBoxLogo;
    }
}

