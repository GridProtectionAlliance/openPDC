using System;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Web.Data;
using System.Windows;
using openPDCManager.Web.Data.Entities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class PhasorsUserControl
    {
        #region [ Methods ]

        void Initialize()
        {           
        }

        void SavePhasor(Phasor phasor, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SavePhasor(phasor, isNew);
                ClearForm();
                GetPhasorList();
                GetPhasors();
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                
            }
            catch (Exception ex)
            {
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Phasor Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }           
        }

        void GetPhasors()
        {
            try
            {
                ComboboxDestinationPhasor.ItemsSource = CommonFunctions.GetPhasors(m_sourceDeviceID, true);
            }
            catch (Exception ex)
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Phasors", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxDestinationPhasor.Items.Count > 0)
                ComboboxDestinationPhasor.SelectedIndex = 0;
        }

        void GetPhasorList()
        {
            try
            {
                ListBoxPhasorList.ItemsSource = CommonFunctions.GetPhasorList(m_sourceDeviceID);
            }
            catch (Exception ex)
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Phasor List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        #endregion
    }
}
