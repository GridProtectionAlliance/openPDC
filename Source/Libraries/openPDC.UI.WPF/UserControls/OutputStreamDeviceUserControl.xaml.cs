using System.Windows.Controls;
using System.Windows.Input;
using openPDC.UI.ViewModels;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for OutputStreamDeviceUserControl.xaml
    /// </summary>
    public partial class OutputStreamDeviceUserControl : UserControl
    {
        /// <summary>
        /// Creates an instance of <see cref="OutputStreamDeviceUserControl"/> class.
        /// </summary>
        public OutputStreamDeviceUserControl()
        {
            InitializeComponent();
            this.DataContext = new OutputStreamDevices(1, 6);
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
