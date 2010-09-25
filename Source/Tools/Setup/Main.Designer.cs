namespace Setup
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.groupBoxInstallationOptions = new System.Windows.Forms.GroupBox();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.checkBoxConnectionTester = new System.Windows.Forms.CheckBox();
            this.radioButton64bit = new System.Windows.Forms.RadioButton();
            this.radioButton32bit = new System.Windows.Forms.RadioButton();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.groupBoxInstallationOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.BackColor = System.Drawing.Color.White;
            this.labelWelcome.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(2, 2);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(417, 66);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to the openPDC\r\nSetup Application";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(494, 70);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelNotes
            // 
            this.labelNotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelNotes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotes.Location = new System.Drawing.Point(0, 195);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelNotes.Size = new System.Drawing.Size(494, 162);
            this.labelNotes.TabIndex = 1;
            this.labelNotes.Text = resources.GetString("labelNotes.Text");
            this.labelNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxInstallationOptions
            // 
            this.groupBoxInstallationOptions.Controls.Add(this.buttonUninstall);
            this.groupBoxInstallationOptions.Controls.Add(this.buttonCancel);
            this.groupBoxInstallationOptions.Controls.Add(this.buttonInstall);
            this.groupBoxInstallationOptions.Controls.Add(this.checkBoxConnectionTester);
            this.groupBoxInstallationOptions.Controls.Add(this.radioButton64bit);
            this.groupBoxInstallationOptions.Controls.Add(this.radioButton32bit);
            this.groupBoxInstallationOptions.Location = new System.Drawing.Point(10, 82);
            this.groupBoxInstallationOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxInstallationOptions.Name = "groupBoxInstallationOptions";
            this.groupBoxInstallationOptions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxInstallationOptions.Size = new System.Drawing.Size(472, 114);
            this.groupBoxInstallationOptions.TabIndex = 0;
            this.groupBoxInstallationOptions.TabStop = false;
            this.groupBoxInstallationOptions.Text = "Installation Options";
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUninstall.Location = new System.Drawing.Point(357, 45);
            this.buttonUninstall.Name = "buttonUninstall";
            this.buttonUninstall.Size = new System.Drawing.Size(100, 31);
            this.buttonUninstall.TabIndex = 4;
            this.buttonUninstall.Text = "&Uninstall";
            this.buttonUninstall.UseVisualStyleBackColor = true;
            this.buttonUninstall.Click += new System.EventHandler(this.buttonUninstall_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(357, 77);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 31);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Location = new System.Drawing.Point(357, 13);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(100, 31);
            this.buttonInstall.TabIndex = 3;
            this.buttonInstall.Text = "&Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // checkBoxConnectionTester
            // 
            this.checkBoxConnectionTester.AutoSize = true;
            this.checkBoxConnectionTester.Checked = true;
            this.checkBoxConnectionTester.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConnectionTester.Location = new System.Drawing.Point(16, 78);
            this.checkBoxConnectionTester.Name = "checkBoxConnectionTester";
            this.checkBoxConnectionTester.Size = new System.Drawing.Size(160, 20);
            this.checkBoxConnectionTester.TabIndex = 2;
            this.checkBoxConnectionTester.Text = "PMU Connection Tester";
            this.checkBoxConnectionTester.UseVisualStyleBackColor = true;
            // 
            // radioButton64bit
            // 
            this.radioButton64bit.AutoSize = true;
            this.radioButton64bit.Location = new System.Drawing.Point(16, 51);
            this.radioButton64bit.Name = "radioButton64bit";
            this.radioButton64bit.Size = new System.Drawing.Size(196, 20);
            this.radioButton64bit.TabIndex = 1;
            this.radioButton64bit.TabStop = true;
            this.radioButton64bit.Text = "64-bit version of the openPDC";
            this.radioButton64bit.UseVisualStyleBackColor = true;
            // 
            // radioButton32bit
            // 
            this.radioButton32bit.AutoSize = true;
            this.radioButton32bit.Checked = true;
            this.radioButton32bit.Location = new System.Drawing.Point(16, 24);
            this.radioButton32bit.Name = "radioButton32bit";
            this.radioButton32bit.Size = new System.Drawing.Size(196, 20);
            this.radioButton32bit.TabIndex = 0;
            this.radioButton32bit.TabStop = true;
            this.radioButton32bit.Text = "32-bit version of the openPDC";
            this.radioButton32bit.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(369, 74);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(125, 13);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version: {0}.{1}.{2}.{3}";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.AcceptButton = this.buttonInstall;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(494, 357);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.groupBoxInstallationOptions);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.pictureBoxLogo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "openPDC Setup";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBoxInstallationOptions.ResumeLayout(false);
            this.groupBoxInstallationOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.GroupBox groupBoxInstallationOptions;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.CheckBox checkBoxConnectionTester;
        private System.Windows.Forms.RadioButton radioButton64bit;
        private System.Windows.Forms.RadioButton radioButton32bit;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.Label labelVersion;
    }
}

