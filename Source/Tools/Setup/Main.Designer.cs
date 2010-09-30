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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageInstallOptions = new System.Windows.Forms.TabPage();
            this.groupBoxInstallationOptions = new System.Windows.Forms.GroupBox();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.checkBoxConnectionTester = new System.Windows.Forms.CheckBox();
            this.radioButton64bit = new System.Windows.Forms.RadioButton();
            this.radioButton32bit = new System.Windows.Forms.RadioButton();
            this.labelNotes = new System.Windows.Forms.Label();
            this.tabPageHelpVideo = new System.Windows.Forms.TabPage();
            this.axVideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.tabPageReleaseNotes = new System.Windows.Forms.TabPage();
            this.richTextBoxReleaseNotes = new System.Windows.Forms.RichTextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageInstallOptions.SuspendLayout();
            this.groupBoxInstallationOptions.SuspendLayout();
            this.tabPageHelpVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axVideoPlayer)).BeginInit();
            this.tabPageReleaseNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageInstallOptions);
            this.tabControlMain.Controls.Add(this.tabPageHelpVideo);
            this.tabControlMain.Controls.Add(this.tabPageReleaseNotes);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControlMain.Location = new System.Drawing.Point(0, 71);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(501, 309);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageInstallOptions
            // 
            this.tabPageInstallOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPageInstallOptions.BackgroundImage")));
            this.tabPageInstallOptions.Controls.Add(this.groupBoxInstallationOptions);
            this.tabPageInstallOptions.Controls.Add(this.labelNotes);
            this.tabPageInstallOptions.Location = new System.Drawing.Point(4, 25);
            this.tabPageInstallOptions.Name = "tabPageInstallOptions";
            this.tabPageInstallOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstallOptions.Size = new System.Drawing.Size(493, 280);
            this.tabPageInstallOptions.TabIndex = 0;
            this.tabPageInstallOptions.Text = "Installation";
            this.tabPageInstallOptions.UseVisualStyleBackColor = true;
            // 
            // groupBoxInstallationOptions
            // 
            this.groupBoxInstallationOptions.Controls.Add(this.buttonUninstall);
            this.groupBoxInstallationOptions.Controls.Add(this.buttonCancel);
            this.groupBoxInstallationOptions.Controls.Add(this.buttonInstall);
            this.groupBoxInstallationOptions.Controls.Add(this.checkBoxConnectionTester);
            this.groupBoxInstallationOptions.Controls.Add(this.radioButton64bit);
            this.groupBoxInstallationOptions.Controls.Add(this.radioButton32bit);
            this.groupBoxInstallationOptions.Location = new System.Drawing.Point(4, 7);
            this.groupBoxInstallationOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxInstallationOptions.Name = "groupBoxInstallationOptions";
            this.groupBoxInstallationOptions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxInstallationOptions.Size = new System.Drawing.Size(483, 114);
            this.groupBoxInstallationOptions.TabIndex = 2;
            this.groupBoxInstallationOptions.TabStop = false;
            this.groupBoxInstallationOptions.Text = "Installation Options";
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUninstall.Location = new System.Drawing.Point(368, 45);
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
            this.buttonCancel.Location = new System.Drawing.Point(368, 77);
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
            this.buttonInstall.Location = new System.Drawing.Point(368, 13);
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
            this.checkBoxConnectionTester.Size = new System.Drawing.Size(140, 17);
            this.checkBoxConnectionTester.TabIndex = 2;
            this.checkBoxConnectionTester.Text = "PMU Connection Tester";
            this.checkBoxConnectionTester.UseVisualStyleBackColor = true;
            // 
            // radioButton64bit
            // 
            this.radioButton64bit.AutoSize = true;
            this.radioButton64bit.Location = new System.Drawing.Point(16, 51);
            this.radioButton64bit.Name = "radioButton64bit";
            this.radioButton64bit.Size = new System.Drawing.Size(167, 17);
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
            this.radioButton32bit.Size = new System.Drawing.Size(167, 17);
            this.radioButton32bit.TabIndex = 0;
            this.radioButton32bit.TabStop = true;
            this.radioButton32bit.Text = "32-bit version of the openPDC";
            this.radioButton32bit.UseVisualStyleBackColor = true;
            // 
            // labelNotes
            // 
            this.labelNotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelNotes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotes.Location = new System.Drawing.Point(3, 125);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelNotes.Size = new System.Drawing.Size(487, 152);
            this.labelNotes.TabIndex = 3;
            this.labelNotes.Text = resources.GetString("labelNotes.Text");
            this.labelNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageHelpVideo
            // 
            this.tabPageHelpVideo.Controls.Add(this.axVideoPlayer);
            this.tabPageHelpVideo.Location = new System.Drawing.Point(4, 25);
            this.tabPageHelpVideo.Name = "tabPageHelpVideo";
            this.tabPageHelpVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHelpVideo.Size = new System.Drawing.Size(493, 280);
            this.tabPageHelpVideo.TabIndex = 1;
            this.tabPageHelpVideo.Text = "Help Video";
            this.tabPageHelpVideo.ToolTipText = "Click here to see a short help video to assist you with your installation.";
            this.tabPageHelpVideo.UseVisualStyleBackColor = true;
            // 
            // axVideoPlayer
            // 
            this.axVideoPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVideoPlayer.Enabled = true;
            this.axVideoPlayer.Location = new System.Drawing.Point(3, 3);
            this.axVideoPlayer.Name = "axVideoPlayer";
            this.axVideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoPlayer.OcxState")));
            this.axVideoPlayer.Size = new System.Drawing.Size(487, 274);
            this.axVideoPlayer.TabIndex = 0;
            // 
            // tabPageReleaseNotes
            // 
            this.tabPageReleaseNotes.Controls.Add(this.richTextBoxReleaseNotes);
            this.tabPageReleaseNotes.Location = new System.Drawing.Point(4, 25);
            this.tabPageReleaseNotes.Name = "tabPageReleaseNotes";
            this.tabPageReleaseNotes.Size = new System.Drawing.Size(493, 280);
            this.tabPageReleaseNotes.TabIndex = 2;
            this.tabPageReleaseNotes.Text = "Release Notes";
            this.tabPageReleaseNotes.ToolTipText = "Click here to see notes about this version of the product release.";
            this.tabPageReleaseNotes.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReleaseNotes
            // 
            this.richTextBoxReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxReleaseNotes.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReleaseNotes.Name = "richTextBoxReleaseNotes";
            this.richTextBoxReleaseNotes.Size = new System.Drawing.Size(493, 280);
            this.richTextBoxReleaseNotes.TabIndex = 0;
            this.richTextBoxReleaseNotes.Text = "";
            this.richTextBoxReleaseNotes.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxReleaseNotes_LinkClicked);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(375, 75);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(125, 13);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version: {0}.{1}.{2}.{3}";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(501, 70);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(501, 380);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.tabControlMain);
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
            this.tabControlMain.ResumeLayout(false);
            this.tabPageInstallOptions.ResumeLayout(false);
            this.groupBoxInstallationOptions.ResumeLayout(false);
            this.groupBoxInstallationOptions.PerformLayout();
            this.tabPageHelpVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axVideoPlayer)).EndInit();
            this.tabPageReleaseNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageInstallOptions;
        private System.Windows.Forms.GroupBox groupBoxInstallationOptions;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.CheckBox checkBoxConnectionTester;
        private System.Windows.Forms.RadioButton radioButton64bit;
        private System.Windows.Forms.RadioButton radioButton32bit;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TabPage tabPageHelpVideo;
        private System.Windows.Forms.Label labelVersion;
        private AxWMPLib.AxWindowsMediaPlayer axVideoPlayer;
        private System.Windows.Forms.TabPage tabPageReleaseNotes;
        private System.Windows.Forms.RichTextBox richTextBoxReleaseNotes;
        private System.Windows.Forms.Label labelWelcome;
    }
}

