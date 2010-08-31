//******************************************************************************************************
//  AdvancedForm.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  06/30/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows.Forms;

namespace DatabaseSetupUtility
{
    /// <summary>
    /// The form that is used when the "Advanced" button is clicked in the <see cref="DatabaseSetupUtility"/> form.
    /// </summary>
    public partial class AdvancedForm : Form
    {

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="AdvancedForm"/> class.
        /// </summary>
        public AdvancedForm()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the text of the advanced form's connection string text box.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return connectionStringTextBox.Text;
            }
            set
            {
                connectionStringTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the connection string encryption check box is checked.
        /// </summary>
        public bool Encrypted
        {
            get
            {
                return encryptConnectionStringCheckBox.Checked;
            }
            set
            {
                encryptConnectionStringCheckBox.Checked = value;
            }
        }

        #endregion

        #region [ Methods ]

        private void AdvancedForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
