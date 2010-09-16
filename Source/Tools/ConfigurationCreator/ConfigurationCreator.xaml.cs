using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TVA;
using TVA.PhasorProtocols;
using TVA.PhasorProtocols.Anonymous;

namespace ConfigurationCreationWizard
{
    /// <summary>
    /// Interaction logic for ConfigurationCreator.xaml
    /// </summary>
    public partial class ConfigurationCreator : UserControl
    {

        private ConfigurationFrame m_configurationFrame;

        public ConfigurationCreator()
        {
            InitializeComponent();

            foreach (PhasorProtocol protocol in Enum.GetValues(typeof(PhasorProtocol)))
            {
                comboBoxProtocols.Items.Add(protocol.GetFormattedProtocolName());
            }

            comboBoxProtocols.SelectedIndex = 0;

            m_configurationFrame = new ConfigurationFrame((ushort)0, (Ticks)0, (ushort)30);

            listBoxDevices.ItemsSource = m_configurationFrame.Cells;
            listBoxDevices.SelectedValuePath = "@IDCode";
        }

        private void RefreshDeviceList()
        {
        }

        private void buttonDeviceAdd_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationCell device = new ConfigurationCell(0);
            device.IDCode = (ushort)m_configurationFrame.Cells.Count;
            device.IDLabel = "Device " + (device.IDCode + 1);

            m_configurationFrame.Cells.Add(device);
            listBoxDevices.SelectedIndex = (m_configurationFrame.Cells.Count - 1);
        }

        private void buttonDeviceDelete_Click(object sender, RoutedEventArgs e)
        {
            m_configurationFrame.Cells.Remove(listBoxDevices.SelectedItem as IConfigurationCell);
            listBoxDevices.SelectedIndex = -1;
        }
    }
}
