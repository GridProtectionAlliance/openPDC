using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSeriesFramework.UI;
using TimeSeriesFramework.UI.DataModels;
using System.Windows.Input;
using TimeSeriesFramework.UI.Commands;
using TVA.Data;
using openPDCManager.UI.DataModels;
using System.Windows;
using System.Windows.Controls;

namespace openPDCManager.UI.ViewModels
{
    internal class OutputStreams : PagedViewModelBase<openPDCManager.UI.DataModels.OutputStream, int>
    {

        #region [ Members ]

        private Dictionary<Guid, string> m_nodelookupList;
        private RelayCommand m_sendInitCommand;
        private RelayCommand m_initializeCommand;
        private RelayCommand m_copyCommand;
        private RelayCommand m_updateCommand;
        private RelayCommand m_deleteCommand;
        private AdoDataConnection database;

        #endregion

        #region [ Properties ]

        public ICommand UpdateCommand
        {
            get
            {
                if (m_updateCommand == null)
                {
                    m_updateCommand = new RelayCommand(UpdateConfig);
                }
                return m_updateCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (m_deleteCommand == null)
                {
                    m_deleteCommand = new RelayCommand(DeleteComm);
                }
                return m_deleteCommand;
            }
        }

        public ICommand CopyCommand
        {
            get
            {
                if (m_copyCommand == null)
                {
                    m_copyCommand = new RelayCommand(Copy);
                }

                return m_copyCommand;
            }
        }

        public ICommand InitializeCommand
        {
            get
            {
                if (m_initializeCommand == null)
                {
                    m_initializeCommand = new RelayCommand(InitCommand);
                }
                return m_initializeCommand;
            }
        }

        public ICommand SendInitCommand
        {
            get
            {
                if (m_sendInitCommand == null)
                {

                }
                return m_sendInitCommand;
            }
        }

        public Dictionary<Guid, string> NodeLookupList
        {
            get
            {
                return m_nodelookupList;
            }
        }

        public override bool IsNewRecord
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region [ Constructor ]

        public OutputStreams(int itemsPerPage, bool autoSave = true)
            : base(itemsPerPage, autoSave)
        {
            m_nodelookupList = Node.GetLookupList(null);
            database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory);
        }
 
        #endregion

        #region [ Methods ]
        public override int GetCurrentItemKey()
        {
            return CurrentItem.ID;
        }

        public override string GetCurrentItemName()
        {
            return CurrentItem.Name;
        }

        public override void Clear()
        {
            base.Clear();
            CurrentItem.NodeID = m_nodelookupList.First().Key;
        }

        public override void Load()
        {
            base.Load();

            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                ItemsSource = OutputStream.Load(null, false, (Guid)database.CurrentNodeID());
            }
            catch (Exception ex)
            {
                Popup("Error: ", ex.Message, MessageBoxImage.Error);
            }
        }

        private void SendInitializeCommand()
        {
            try
            {
                    var result = CommonFunctions.SendCommandToService("Initialize" + CommonFunctions.GetRuntimeID("OutputStream", CurrentItem.ID));
                    Popup(result, "", System.Windows.MessageBoxImage.Information);
                    CommonFunctions.SendCommandToService("Invoke 0 ReloadStatistics");
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SendInitialize", ex);
                Popup("Failed to Send Initialize Command", ex.Message, System.Windows.MessageBoxImage.Error);
            }
        }

        private void InitCommand()
        {
            if (Confirm("Do you want to send Initialize Command?", "Output Stream Acronym: " + CurrentItem.Acronym))
            {
                SendInitializeCommand();
            }
        } 

        private void Copy(object parameter)
        {
            OutputStream outputStreamToCopy = new OutputStream();
            outputStreamToCopy = (OutputStream)parameter;
            try
            {
                if (Confirm("Do you want to make a copy of " + CurrentItem.Acronym + " output stream?", "This will only copy the output stream configuration, not associated devices."))
                {
                    outputStreamToCopy.Name = "Copy of " + outputStreamToCopy.Name;
                    outputStreamToCopy.Enabled = false;
                    string originalAcronym = outputStreamToCopy.Acronym;
                    Guid nodeID = (Guid)database.CurrentNodeID();
                    int i = 1;
                    do
                    {
                        outputStreamToCopy.Acronym = originalAcronym + i.ToString();
                        i++;
                    }
                    while (OutputStream.GetOutputStreamByAcronym(null, outputStreamToCopy.Acronym, nodeID) != null);

                    CurrentItem = outputStreamToCopy;
                }
            }
            catch(Exception ex)
            {
                Popup("Failed to delete output stream.", ex.Message, System.Windows.MessageBoxImage.Error);
            }
        }

        private void UpdateConfig()
        {
            try
            {
                if (Confirm("Do you want to update configuration?", ""))
                {
                    string runtimeID = CommonFunctions.GetRuntimeID("OutputStream", CurrentItem.ID);
                    string result = CommonFunctions.SendCommandToService("reloadconfig");
                    result = CommonFunctions.SendCommandToService("Invoke " + runtimeID + " UpdateConfiguration");
                    Popup(result, "", MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Popup("Failed to UpdateConfiguration", ex.Message, MessageBoxImage.Error);
            }
        }

        private void DeleteComm()
        {
            try
            {

                if (Confirm("Do you want to delete output stream?", "Output Stream Acronym: "))
                {
                    OutputStream.DeleteOutputStream(null, CurrentItem.ID);

                }
            }
            catch (Exception ex)
            {
                Popup("Failed to delete output stream", ex.Message, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
