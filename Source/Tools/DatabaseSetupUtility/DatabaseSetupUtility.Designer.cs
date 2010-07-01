namespace DatabaseSetupUtility
{
    partial class DatabaseSetupUtility
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
            this.nextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.databaseTypePanel = new System.Windows.Forms.Panel();
            this.databaseTypeTitleLabel = new System.Windows.Forms.Label();
            this.databaseTypeInstructionLabel = new System.Windows.Forms.Label();
            this.sampleDataScriptCheckBox = new System.Windows.Forms.CheckBox();
            this.initialDataScriptCheckBox = new System.Windows.Forms.CheckBox();
            this.sqlServerRadioButton = new System.Windows.Forms.RadioButton();
            this.mysqlRadioButton = new System.Windows.Forms.RadioButton();
            this.accessRadioButton = new System.Windows.Forms.RadioButton();
            this.accessDatabasePanel = new System.Windows.Forms.Panel();
            this.accessDatabaseBrowseButton = new System.Windows.Forms.Button();
            this.accessDatabaseFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.accessDatabaseInstructionLabel = new System.Windows.Forms.Label();
            this.accessDatabaseTitleLabel = new System.Windows.Forms.Label();
            this.accessDatabaseSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mySqlDatabasePanel = new System.Windows.Forms.Panel();
            this.mySqlDatabasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabasePasswordLabel = new System.Windows.Forms.Label();
            this.mySqlDatabaseUserNameTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabaseUserNameLabel = new System.Windows.Forms.Label();
            this.mySqlDatabaseNameTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabaseNameLabel = new System.Windows.Forms.Label();
            this.mySqlDatabaseHostNameTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabaseHostNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mySqlDatabaseTitleLabel = new System.Windows.Forms.Label();
            this.sqlServerDatabasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.sqlServerDatabasePasswordLabel = new System.Windows.Forms.Label();
            this.sqlServerDatabaseUserNameTextBox = new System.Windows.Forms.TextBox();
            this.sqlServerDatabasePanel = new System.Windows.Forms.Panel();
            this.sqlServerDatabaseUserNameLabel = new System.Windows.Forms.Label();
            this.sqlServerDatabaseNameTextBox = new System.Windows.Forms.TextBox();
            this.sqlServerDatabaseNameLabel = new System.Windows.Forms.Label();
            this.sqlServerDatabaseHostNameTextBox = new System.Windows.Forms.TextBox();
            this.sqlServerDatabaseHostNameLabel = new System.Windows.Forms.Label();
            this.sqlServerDatabaseInstructionLabel = new System.Windows.Forms.Label();
            this.sqlServerDatabaseTitleLabel = new System.Windows.Forms.Label();
            this.prepareForSetupPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.prepareForSetupTitleLabel = new System.Windows.Forms.Label();
            this.advancedButton = new System.Windows.Forms.Button();
            this.databaseSetupPanel = new System.Windows.Forms.Panel();
            this.databaseSetupInstructionLabel = new System.Windows.Forms.Label();
            this.databaseSetupTitleLabel = new System.Windows.Forms.Label();
            this.databaseSetupProgressBar = new System.Windows.Forms.ProgressBar();
            this.setupFinishedPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.setupFinishedTitleLabel = new System.Windows.Forms.Label();
            this.databaseTypePanel.SuspendLayout();
            this.accessDatabasePanel.SuspendLayout();
            this.mySqlDatabasePanel.SuspendLayout();
            this.sqlServerDatabasePanel.SuspendLayout();
            this.prepareForSetupPanel.SuspendLayout();
            this.databaseSetupPanel.SuspendLayout();
            this.setupFinishedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(352, 275);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next >";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(190, 275);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(271, 275);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "< Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // databaseTypePanel
            // 
            this.databaseTypePanel.Controls.Add(this.databaseTypeTitleLabel);
            this.databaseTypePanel.Controls.Add(this.databaseTypeInstructionLabel);
            this.databaseTypePanel.Controls.Add(this.sampleDataScriptCheckBox);
            this.databaseTypePanel.Controls.Add(this.initialDataScriptCheckBox);
            this.databaseTypePanel.Controls.Add(this.sqlServerRadioButton);
            this.databaseTypePanel.Controls.Add(this.mysqlRadioButton);
            this.databaseTypePanel.Controls.Add(this.accessRadioButton);
            this.databaseTypePanel.Location = new System.Drawing.Point(12, 12);
            this.databaseTypePanel.Name = "databaseTypePanel";
            this.databaseTypePanel.Size = new System.Drawing.Size(415, 257);
            this.databaseTypePanel.TabIndex = 1;
            // 
            // databaseTypeTitleLabel
            // 
            this.databaseTypeTitleLabel.AutoSize = true;
            this.databaseTypeTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseTypeTitleLabel.Location = new System.Drawing.Point(106, 14);
            this.databaseTypeTitleLabel.Name = "databaseTypeTitleLabel";
            this.databaseTypeTitleLabel.Size = new System.Drawing.Size(183, 24);
            this.databaseTypeTitleLabel.TabIndex = 0;
            this.databaseTypeTitleLabel.Text = "Select database type";
            // 
            // databaseTypeInstructionLabel
            // 
            this.databaseTypeInstructionLabel.AutoSize = true;
            this.databaseTypeInstructionLabel.Location = new System.Drawing.Point(49, 47);
            this.databaseTypeInstructionLabel.Name = "databaseTypeInstructionLabel";
            this.databaseTypeInstructionLabel.Size = new System.Drawing.Size(314, 13);
            this.databaseTypeInstructionLabel.TabIndex = 1;
            this.databaseTypeInstructionLabel.Text = "Please select the type of database you would like to have set up.";
            // 
            // sampleDataScriptCheckBox
            // 
            this.sampleDataScriptCheckBox.AutoSize = true;
            this.sampleDataScriptCheckBox.Location = new System.Drawing.Point(153, 192);
            this.sampleDataScriptCheckBox.Name = "sampleDataScriptCheckBox";
            this.sampleDataScriptCheckBox.Size = new System.Drawing.Size(134, 17);
            this.sampleDataScriptCheckBox.TabIndex = 4;
            this.sampleDataScriptCheckBox.Text = "Run sample data script";
            this.sampleDataScriptCheckBox.UseVisualStyleBackColor = true;
            // 
            // initialDataScriptCheckBox
            // 
            this.initialDataScriptCheckBox.AutoSize = true;
            this.initialDataScriptCheckBox.Checked = true;
            this.initialDataScriptCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.initialDataScriptCheckBox.Location = new System.Drawing.Point(134, 169);
            this.initialDataScriptCheckBox.Name = "initialDataScriptCheckBox";
            this.initialDataScriptCheckBox.Size = new System.Drawing.Size(124, 17);
            this.initialDataScriptCheckBox.TabIndex = 3;
            this.initialDataScriptCheckBox.Text = "Run initial data script";
            this.initialDataScriptCheckBox.UseVisualStyleBackColor = true;
            this.initialDataScriptCheckBox.CheckedChanged += new System.EventHandler(this.initialDataScriptCheckBox_CheckedChanged);
            // 
            // sqlServerRadioButton
            // 
            this.sqlServerRadioButton.AutoSize = true;
            this.sqlServerRadioButton.Location = new System.Drawing.Point(134, 128);
            this.sqlServerRadioButton.Name = "sqlServerRadioButton";
            this.sqlServerRadioButton.Size = new System.Drawing.Size(80, 17);
            this.sqlServerRadioButton.TabIndex = 2;
            this.sqlServerRadioButton.Text = "SQL Server";
            this.sqlServerRadioButton.UseVisualStyleBackColor = true;
            this.sqlServerRadioButton.CheckedChanged += new System.EventHandler(this.sqlServerRadioButton_CheckedChanged);
            // 
            // mysqlRadioButton
            // 
            this.mysqlRadioButton.AutoSize = true;
            this.mysqlRadioButton.Location = new System.Drawing.Point(134, 105);
            this.mysqlRadioButton.Name = "mysqlRadioButton";
            this.mysqlRadioButton.Size = new System.Drawing.Size(60, 17);
            this.mysqlRadioButton.TabIndex = 2;
            this.mysqlRadioButton.Text = "MySQL";
            this.mysqlRadioButton.UseVisualStyleBackColor = true;
            this.mysqlRadioButton.CheckedChanged += new System.EventHandler(this.mysqlRadioButton_CheckedChanged);
            // 
            // accessRadioButton
            // 
            this.accessRadioButton.AutoSize = true;
            this.accessRadioButton.Checked = true;
            this.accessRadioButton.Location = new System.Drawing.Point(134, 82);
            this.accessRadioButton.Name = "accessRadioButton";
            this.accessRadioButton.Size = new System.Drawing.Size(60, 17);
            this.accessRadioButton.TabIndex = 2;
            this.accessRadioButton.TabStop = true;
            this.accessRadioButton.Text = "Access";
            this.accessRadioButton.UseVisualStyleBackColor = true;
            this.accessRadioButton.CheckedChanged += new System.EventHandler(this.accessRadioButton_CheckedChanged);
            // 
            // accessDatabasePanel
            // 
            this.accessDatabasePanel.Controls.Add(this.accessDatabaseBrowseButton);
            this.accessDatabasePanel.Controls.Add(this.accessDatabaseFileLocationTextBox);
            this.accessDatabasePanel.Controls.Add(this.accessDatabaseInstructionLabel);
            this.accessDatabasePanel.Controls.Add(this.accessDatabaseTitleLabel);
            this.accessDatabasePanel.Location = new System.Drawing.Point(12, 12);
            this.accessDatabasePanel.Name = "accessDatabasePanel";
            this.accessDatabasePanel.Size = new System.Drawing.Size(415, 257);
            this.accessDatabasePanel.TabIndex = 0;
            this.accessDatabasePanel.Visible = false;
            // 
            // accessDatabaseBrowseButton
            // 
            this.accessDatabaseBrowseButton.Location = new System.Drawing.Point(273, 102);
            this.accessDatabaseBrowseButton.Name = "accessDatabaseBrowseButton";
            this.accessDatabaseBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.accessDatabaseBrowseButton.TabIndex = 3;
            this.accessDatabaseBrowseButton.Text = "Browse...";
            this.accessDatabaseBrowseButton.UseVisualStyleBackColor = true;
            this.accessDatabaseBrowseButton.Click += new System.EventHandler(this.accessDatabaseBrowseButton_Click);
            // 
            // accessDatabaseFileLocationTextBox
            // 
            this.accessDatabaseFileLocationTextBox.Location = new System.Drawing.Point(85, 105);
            this.accessDatabaseFileLocationTextBox.Name = "accessDatabaseFileLocationTextBox";
            this.accessDatabaseFileLocationTextBox.Size = new System.Drawing.Size(182, 20);
            this.accessDatabaseFileLocationTextBox.TabIndex = 2;
            this.accessDatabaseFileLocationTextBox.Text = "openPDC.mdb";
            // 
            // accessDatabaseInstructionLabel
            // 
            this.accessDatabaseInstructionLabel.AutoSize = true;
            this.accessDatabaseInstructionLabel.Location = new System.Drawing.Point(82, 47);
            this.accessDatabaseInstructionLabel.Name = "accessDatabaseInstructionLabel";
            this.accessDatabaseInstructionLabel.Size = new System.Drawing.Size(266, 13);
            this.accessDatabaseInstructionLabel.TabIndex = 1;
            this.accessDatabaseInstructionLabel.Text = "Please select the location of your access database file.";
            // 
            // accessDatabaseTitleLabel
            // 
            this.accessDatabaseTitleLabel.AutoSize = true;
            this.accessDatabaseTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accessDatabaseTitleLabel.Location = new System.Drawing.Point(106, 14);
            this.accessDatabaseTitleLabel.Name = "accessDatabaseTitleLabel";
            this.accessDatabaseTitleLabel.Size = new System.Drawing.Size(212, 24);
            this.accessDatabaseTitleLabel.TabIndex = 0;
            this.accessDatabaseTitleLabel.Text = "Set up Access database";
            // 
            // accessDatabaseSaveFileDialog
            // 
            this.accessDatabaseSaveFileDialog.DefaultExt = "mdb";
            // 
            // mySqlDatabasePanel
            // 
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabasePasswordTextBox);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabasePasswordLabel);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabaseUserNameTextBox);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabaseUserNameLabel);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabaseNameTextBox);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabaseNameLabel);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabaseHostNameTextBox);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabaseHostNameLabel);
            this.mySqlDatabasePanel.Controls.Add(this.label1);
            this.mySqlDatabasePanel.Controls.Add(this.mySqlDatabaseTitleLabel);
            this.mySqlDatabasePanel.Location = new System.Drawing.Point(12, 12);
            this.mySqlDatabasePanel.Name = "mySqlDatabasePanel";
            this.mySqlDatabasePanel.Size = new System.Drawing.Size(415, 257);
            this.mySqlDatabasePanel.TabIndex = 0;
            this.mySqlDatabasePanel.Visible = false;
            this.mySqlDatabasePanel.VisibleChanged += new System.EventHandler(this.mySqlDatabasePanel_VisibleChanged);
            // 
            // mySqlDatabasePasswordTextBox
            // 
            this.mySqlDatabasePasswordTextBox.Location = new System.Drawing.Point(213, 167);
            this.mySqlDatabasePasswordTextBox.Name = "mySqlDatabasePasswordTextBox";
            this.mySqlDatabasePasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.mySqlDatabasePasswordTextBox.TabIndex = 9;
            this.mySqlDatabasePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // mySqlDatabasePasswordLabel
            // 
            this.mySqlDatabasePasswordLabel.AutoSize = true;
            this.mySqlDatabasePasswordLabel.Location = new System.Drawing.Point(120, 172);
            this.mySqlDatabasePasswordLabel.Name = "mySqlDatabasePasswordLabel";
            this.mySqlDatabasePasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.mySqlDatabasePasswordLabel.TabIndex = 8;
            this.mySqlDatabasePasswordLabel.Text = "Password:";
            // 
            // mySqlDatabaseUserNameTextBox
            // 
            this.mySqlDatabaseUserNameTextBox.Location = new System.Drawing.Point(213, 141);
            this.mySqlDatabaseUserNameTextBox.Name = "mySqlDatabaseUserNameTextBox";
            this.mySqlDatabaseUserNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.mySqlDatabaseUserNameTextBox.TabIndex = 7;
            // 
            // mySqlDatabaseUserNameLabel
            // 
            this.mySqlDatabaseUserNameLabel.AutoSize = true;
            this.mySqlDatabaseUserNameLabel.Location = new System.Drawing.Point(120, 144);
            this.mySqlDatabaseUserNameLabel.Name = "mySqlDatabaseUserNameLabel";
            this.mySqlDatabaseUserNameLabel.Size = new System.Drawing.Size(63, 13);
            this.mySqlDatabaseUserNameLabel.TabIndex = 6;
            this.mySqlDatabaseUserNameLabel.Text = "User Name:";
            // 
            // mySqlDatabaseNameTextBox
            // 
            this.mySqlDatabaseNameTextBox.Location = new System.Drawing.Point(213, 115);
            this.mySqlDatabaseNameTextBox.Name = "mySqlDatabaseNameTextBox";
            this.mySqlDatabaseNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.mySqlDatabaseNameTextBox.TabIndex = 5;
            this.mySqlDatabaseNameTextBox.Text = "openPDC";
            // 
            // mySqlDatabaseNameLabel
            // 
            this.mySqlDatabaseNameLabel.AutoSize = true;
            this.mySqlDatabaseNameLabel.Location = new System.Drawing.Point(120, 118);
            this.mySqlDatabaseNameLabel.Name = "mySqlDatabaseNameLabel";
            this.mySqlDatabaseNameLabel.Size = new System.Drawing.Size(87, 13);
            this.mySqlDatabaseNameLabel.TabIndex = 4;
            this.mySqlDatabaseNameLabel.Text = "Database Name:";
            // 
            // mySqlDatabaseHostNameTextBox
            // 
            this.mySqlDatabaseHostNameTextBox.Location = new System.Drawing.Point(213, 89);
            this.mySqlDatabaseHostNameTextBox.Name = "mySqlDatabaseHostNameTextBox";
            this.mySqlDatabaseHostNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.mySqlDatabaseHostNameTextBox.TabIndex = 3;
            this.mySqlDatabaseHostNameTextBox.Text = "localhost";
            // 
            // mySqlDatabaseHostNameLabel
            // 
            this.mySqlDatabaseHostNameLabel.AutoSize = true;
            this.mySqlDatabaseHostNameLabel.Location = new System.Drawing.Point(120, 92);
            this.mySqlDatabaseHostNameLabel.Name = "mySqlDatabaseHostNameLabel";
            this.mySqlDatabaseHostNameLabel.Size = new System.Drawing.Size(63, 13);
            this.mySqlDatabaseHostNameLabel.TabIndex = 2;
            this.mySqlDatabaseHostNameLabel.Text = "Host Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter the following information about your MySQL database.";
            // 
            // mySqlDatabaseTitleLabel
            // 
            this.mySqlDatabaseTitleLabel.AutoSize = true;
            this.mySqlDatabaseTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mySqlDatabaseTitleLabel.Location = new System.Drawing.Point(107, 14);
            this.mySqlDatabaseTitleLabel.Name = "mySqlDatabaseTitleLabel";
            this.mySqlDatabaseTitleLabel.Size = new System.Drawing.Size(212, 24);
            this.mySqlDatabaseTitleLabel.TabIndex = 0;
            this.mySqlDatabaseTitleLabel.Text = "Set up MySQL database";
            // 
            // sqlServerDatabasePasswordTextBox
            // 
            this.sqlServerDatabasePasswordTextBox.Location = new System.Drawing.Point(213, 167);
            this.sqlServerDatabasePasswordTextBox.Name = "sqlServerDatabasePasswordTextBox";
            this.sqlServerDatabasePasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.sqlServerDatabasePasswordTextBox.TabIndex = 9;
            this.sqlServerDatabasePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // sqlServerDatabasePasswordLabel
            // 
            this.sqlServerDatabasePasswordLabel.AutoSize = true;
            this.sqlServerDatabasePasswordLabel.Location = new System.Drawing.Point(120, 172);
            this.sqlServerDatabasePasswordLabel.Name = "sqlServerDatabasePasswordLabel";
            this.sqlServerDatabasePasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.sqlServerDatabasePasswordLabel.TabIndex = 8;
            this.sqlServerDatabasePasswordLabel.Text = "Password:";
            // 
            // sqlServerDatabaseUserNameTextBox
            // 
            this.sqlServerDatabaseUserNameTextBox.Location = new System.Drawing.Point(213, 141);
            this.sqlServerDatabaseUserNameTextBox.Name = "sqlServerDatabaseUserNameTextBox";
            this.sqlServerDatabaseUserNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.sqlServerDatabaseUserNameTextBox.TabIndex = 7;
            // 
            // sqlServerDatabasePanel
            // 
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabasePasswordTextBox);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabasePasswordLabel);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseUserNameTextBox);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseUserNameLabel);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseNameTextBox);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseNameLabel);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseHostNameTextBox);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseHostNameLabel);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseInstructionLabel);
            this.sqlServerDatabasePanel.Controls.Add(this.sqlServerDatabaseTitleLabel);
            this.sqlServerDatabasePanel.Location = new System.Drawing.Point(12, 12);
            this.sqlServerDatabasePanel.Name = "sqlServerDatabasePanel";
            this.sqlServerDatabasePanel.Size = new System.Drawing.Size(415, 257);
            this.sqlServerDatabasePanel.TabIndex = 9;
            this.sqlServerDatabasePanel.Visible = false;
            this.sqlServerDatabasePanel.VisibleChanged += new System.EventHandler(this.sqlServerDatabasePanel_VisibleChanged);
            // 
            // sqlServerDatabaseUserNameLabel
            // 
            this.sqlServerDatabaseUserNameLabel.AutoSize = true;
            this.sqlServerDatabaseUserNameLabel.Location = new System.Drawing.Point(120, 144);
            this.sqlServerDatabaseUserNameLabel.Name = "sqlServerDatabaseUserNameLabel";
            this.sqlServerDatabaseUserNameLabel.Size = new System.Drawing.Size(63, 13);
            this.sqlServerDatabaseUserNameLabel.TabIndex = 6;
            this.sqlServerDatabaseUserNameLabel.Text = "User Name:";
            // 
            // sqlServerDatabaseNameTextBox
            // 
            this.sqlServerDatabaseNameTextBox.Location = new System.Drawing.Point(213, 115);
            this.sqlServerDatabaseNameTextBox.Name = "sqlServerDatabaseNameTextBox";
            this.sqlServerDatabaseNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.sqlServerDatabaseNameTextBox.TabIndex = 5;
            this.sqlServerDatabaseNameTextBox.Text = "openPDC";
            // 
            // sqlServerDatabaseNameLabel
            // 
            this.sqlServerDatabaseNameLabel.AutoSize = true;
            this.sqlServerDatabaseNameLabel.Location = new System.Drawing.Point(120, 118);
            this.sqlServerDatabaseNameLabel.Name = "sqlServerDatabaseNameLabel";
            this.sqlServerDatabaseNameLabel.Size = new System.Drawing.Size(87, 13);
            this.sqlServerDatabaseNameLabel.TabIndex = 4;
            this.sqlServerDatabaseNameLabel.Text = "Database Name:";
            // 
            // sqlServerDatabaseHostNameTextBox
            // 
            this.sqlServerDatabaseHostNameTextBox.Location = new System.Drawing.Point(213, 89);
            this.sqlServerDatabaseHostNameTextBox.Name = "sqlServerDatabaseHostNameTextBox";
            this.sqlServerDatabaseHostNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.sqlServerDatabaseHostNameTextBox.TabIndex = 3;
            this.sqlServerDatabaseHostNameTextBox.Text = "localhost";
            // 
            // sqlServerDatabaseHostNameLabel
            // 
            this.sqlServerDatabaseHostNameLabel.AutoSize = true;
            this.sqlServerDatabaseHostNameLabel.Location = new System.Drawing.Point(120, 92);
            this.sqlServerDatabaseHostNameLabel.Name = "sqlServerDatabaseHostNameLabel";
            this.sqlServerDatabaseHostNameLabel.Size = new System.Drawing.Size(63, 13);
            this.sqlServerDatabaseHostNameLabel.TabIndex = 2;
            this.sqlServerDatabaseHostNameLabel.Text = "Host Name:";
            // 
            // sqlServerDatabaseInstructionLabel
            // 
            this.sqlServerDatabaseInstructionLabel.AutoSize = true;
            this.sqlServerDatabaseInstructionLabel.Location = new System.Drawing.Point(32, 47);
            this.sqlServerDatabaseInstructionLabel.Name = "sqlServerDatabaseInstructionLabel";
            this.sqlServerDatabaseInstructionLabel.Size = new System.Drawing.Size(343, 13);
            this.sqlServerDatabaseInstructionLabel.TabIndex = 1;
            this.sqlServerDatabaseInstructionLabel.Text = "Please enter the following information about your SQL Server database.";
            // 
            // sqlServerDatabaseTitleLabel
            // 
            this.sqlServerDatabaseTitleLabel.AutoSize = true;
            this.sqlServerDatabaseTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlServerDatabaseTitleLabel.Location = new System.Drawing.Point(87, 14);
            this.sqlServerDatabaseTitleLabel.Name = "sqlServerDatabaseTitleLabel";
            this.sqlServerDatabaseTitleLabel.Size = new System.Drawing.Size(247, 24);
            this.sqlServerDatabaseTitleLabel.TabIndex = 0;
            this.sqlServerDatabaseTitleLabel.Text = "Set up SQL Server database";
            // 
            // prepareForSetupPanel
            // 
            this.prepareForSetupPanel.Controls.Add(this.label2);
            this.prepareForSetupPanel.Controls.Add(this.prepareForSetupTitleLabel);
            this.prepareForSetupPanel.Location = new System.Drawing.Point(12, 12);
            this.prepareForSetupPanel.Name = "prepareForSetupPanel";
            this.prepareForSetupPanel.Size = new System.Drawing.Size(415, 257);
            this.prepareForSetupPanel.TabIndex = 0;
            this.prepareForSetupPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "The setup is ready to create the database. When you are ready, click Next.";
            // 
            // prepareForSetupTitleLabel
            // 
            this.prepareForSetupTitleLabel.AutoSize = true;
            this.prepareForSetupTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepareForSetupTitleLabel.Location = new System.Drawing.Point(82, 14);
            this.prepareForSetupTitleLabel.Name = "prepareForSetupTitleLabel";
            this.prepareForSetupTitleLabel.Size = new System.Drawing.Size(252, 24);
            this.prepareForSetupTitleLabel.TabIndex = 0;
            this.prepareForSetupTitleLabel.Text = "Ready to set up the database";
            // 
            // advancedButton
            // 
            this.advancedButton.Location = new System.Drawing.Point(12, 275);
            this.advancedButton.Name = "advancedButton";
            this.advancedButton.Size = new System.Drawing.Size(75, 23);
            this.advancedButton.TabIndex = 1;
            this.advancedButton.Text = "Advanced...";
            this.advancedButton.UseVisualStyleBackColor = true;
            this.advancedButton.Visible = false;
            this.advancedButton.VisibleChanged += new System.EventHandler(this.advancedButton_VisibleChanged);
            this.advancedButton.Click += new System.EventHandler(this.advancedButton_Click);
            // 
            // databaseSetupPanel
            // 
            this.databaseSetupPanel.Controls.Add(this.databaseSetupInstructionLabel);
            this.databaseSetupPanel.Controls.Add(this.databaseSetupTitleLabel);
            this.databaseSetupPanel.Controls.Add(this.databaseSetupProgressBar);
            this.databaseSetupPanel.Location = new System.Drawing.Point(12, 12);
            this.databaseSetupPanel.Name = "databaseSetupPanel";
            this.databaseSetupPanel.Size = new System.Drawing.Size(415, 257);
            this.databaseSetupPanel.TabIndex = 2;
            this.databaseSetupPanel.Visible = false;
            this.databaseSetupPanel.VisibleChanged += new System.EventHandler(this.databaseSetupPanel_VisibleChanged);
            // 
            // databaseSetupInstructionLabel
            // 
            this.databaseSetupInstructionLabel.AutoSize = true;
            this.databaseSetupInstructionLabel.Location = new System.Drawing.Point(95, 47);
            this.databaseSetupInstructionLabel.Name = "databaseSetupInstructionLabel";
            this.databaseSetupInstructionLabel.Size = new System.Drawing.Size(239, 13);
            this.databaseSetupInstructionLabel.TabIndex = 2;
            this.databaseSetupInstructionLabel.Text = "The setup is creating your database. Please wait.";
            // 
            // databaseSetupTitleLabel
            // 
            this.databaseSetupTitleLabel.AutoSize = true;
            this.databaseSetupTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseSetupTitleLabel.Location = new System.Drawing.Point(107, 14);
            this.databaseSetupTitleLabel.Name = "databaseSetupTitleLabel";
            this.databaseSetupTitleLabel.Size = new System.Drawing.Size(191, 24);
            this.databaseSetupTitleLabel.TabIndex = 1;
            this.databaseSetupTitleLabel.Text = "Setup is in progress...";
            // 
            // databaseSetupProgressBar
            // 
            this.databaseSetupProgressBar.Location = new System.Drawing.Point(26, 153);
            this.databaseSetupProgressBar.Name = "databaseSetupProgressBar";
            this.databaseSetupProgressBar.Size = new System.Drawing.Size(368, 23);
            this.databaseSetupProgressBar.TabIndex = 0;
            // 
            // setupFinishedPanel
            // 
            this.setupFinishedPanel.Controls.Add(this.label4);
            this.setupFinishedPanel.Controls.Add(this.setupFinishedTitleLabel);
            this.setupFinishedPanel.Location = new System.Drawing.Point(12, 12);
            this.setupFinishedPanel.Name = "setupFinishedPanel";
            this.setupFinishedPanel.Size = new System.Drawing.Size(415, 257);
            this.setupFinishedPanel.TabIndex = 3;
            this.setupFinishedPanel.Visible = false;
            this.setupFinishedPanel.VisibleChanged += new System.EventHandler(this.setupFinishedPanel_VisibleChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "The database setup is complete. Click Finish to exit the Database Setup Utility.";
            // 
            // setupFinishedTitleLabel
            // 
            this.setupFinishedTitleLabel.AutoSize = true;
            this.setupFinishedTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupFinishedTitleLabel.Location = new System.Drawing.Point(82, 14);
            this.setupFinishedTitleLabel.Name = "setupFinishedTitleLabel";
            this.setupFinishedTitleLabel.Size = new System.Drawing.Size(222, 24);
            this.setupFinishedTitleLabel.TabIndex = 0;
            this.setupFinishedTitleLabel.Text = "Database setup complete";
            // 
            // DatabaseSetupUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 310);
            this.Controls.Add(this.databaseSetupPanel);
            this.Controls.Add(this.advancedButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prepareForSetupPanel);
            this.Controls.Add(this.sqlServerDatabasePanel);
            this.Controls.Add(this.mySqlDatabasePanel);
            this.Controls.Add(this.accessDatabasePanel);
            this.Controls.Add(this.databaseTypePanel);
            this.Controls.Add(this.setupFinishedPanel);
            this.KeyPreview = true;
            this.Name = "DatabaseSetupUtility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Setup Utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseSetupUtility_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatabaseSetupUtility_KeyDown);
            this.databaseTypePanel.ResumeLayout(false);
            this.databaseTypePanel.PerformLayout();
            this.accessDatabasePanel.ResumeLayout(false);
            this.accessDatabasePanel.PerformLayout();
            this.mySqlDatabasePanel.ResumeLayout(false);
            this.mySqlDatabasePanel.PerformLayout();
            this.sqlServerDatabasePanel.ResumeLayout(false);
            this.sqlServerDatabasePanel.PerformLayout();
            this.prepareForSetupPanel.ResumeLayout(false);
            this.prepareForSetupPanel.PerformLayout();
            this.databaseSetupPanel.ResumeLayout(false);
            this.databaseSetupPanel.PerformLayout();
            this.setupFinishedPanel.ResumeLayout(false);
            this.setupFinishedPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel databaseTypePanel;
        private System.Windows.Forms.CheckBox sampleDataScriptCheckBox;
        private System.Windows.Forms.CheckBox initialDataScriptCheckBox;
        private System.Windows.Forms.RadioButton sqlServerRadioButton;
        private System.Windows.Forms.RadioButton mysqlRadioButton;
        private System.Windows.Forms.RadioButton accessRadioButton;
        private System.Windows.Forms.Label databaseTypeInstructionLabel;
        private System.Windows.Forms.Label databaseTypeTitleLabel;
        private System.Windows.Forms.Panel accessDatabasePanel;
        private System.Windows.Forms.TextBox accessDatabaseFileLocationTextBox;
        private System.Windows.Forms.Label accessDatabaseInstructionLabel;
        private System.Windows.Forms.Label accessDatabaseTitleLabel;
        private System.Windows.Forms.Button accessDatabaseBrowseButton;
        private System.Windows.Forms.SaveFileDialog accessDatabaseSaveFileDialog;
        private System.Windows.Forms.Panel mySqlDatabasePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mySqlDatabaseTitleLabel;
        private System.Windows.Forms.Label mySqlDatabaseNameLabel;
        private System.Windows.Forms.TextBox mySqlDatabaseHostNameTextBox;
        private System.Windows.Forms.Label mySqlDatabaseHostNameLabel;
        private System.Windows.Forms.TextBox mySqlDatabaseNameTextBox;
        private System.Windows.Forms.Label mySqlDatabasePasswordLabel;
        private System.Windows.Forms.TextBox mySqlDatabaseUserNameTextBox;
        private System.Windows.Forms.Label mySqlDatabaseUserNameLabel;
        private System.Windows.Forms.TextBox mySqlDatabasePasswordTextBox;
        private System.Windows.Forms.TextBox sqlServerDatabasePasswordTextBox;
        private System.Windows.Forms.Label sqlServerDatabasePasswordLabel;
        private System.Windows.Forms.TextBox sqlServerDatabaseUserNameTextBox;
        private System.Windows.Forms.Panel sqlServerDatabasePanel;
        private System.Windows.Forms.Label sqlServerDatabaseUserNameLabel;
        private System.Windows.Forms.TextBox sqlServerDatabaseNameTextBox;
        private System.Windows.Forms.Label sqlServerDatabaseNameLabel;
        private System.Windows.Forms.TextBox sqlServerDatabaseHostNameTextBox;
        private System.Windows.Forms.Label sqlServerDatabaseHostNameLabel;
        private System.Windows.Forms.Label sqlServerDatabaseInstructionLabel;
        private System.Windows.Forms.Label sqlServerDatabaseTitleLabel;
        private System.Windows.Forms.Panel prepareForSetupPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label prepareForSetupTitleLabel;
        private System.Windows.Forms.Button advancedButton;
        private System.Windows.Forms.Panel databaseSetupPanel;
        private System.Windows.Forms.ProgressBar databaseSetupProgressBar;
        private System.Windows.Forms.Label databaseSetupInstructionLabel;
        private System.Windows.Forms.Label databaseSetupTitleLabel;
        private System.Windows.Forms.Panel setupFinishedPanel;
        private System.Windows.Forms.Label setupFinishedTitleLabel;
        private System.Windows.Forms.Label label4;
    }
}

