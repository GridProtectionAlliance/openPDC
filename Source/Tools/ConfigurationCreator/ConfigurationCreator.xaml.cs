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

        private ConfigurationCell SelectedItem
        {
            get
            {
                int selectedIndex = listBoxDevices.SelectedIndex;

                if (selectedIndex >= 0 && selectedIndex < m_configurationFrame.Cells.Count)
                    return m_configurationFrame.Cells[selectedIndex];

                return null;
            }
        }

        private void buttonDeviceAdd_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationCell device = new ConfigurationCell(m_configurationFrame, 0);
            device.IDCode = (ushort)m_configurationFrame.Cells.Count;
            device.IDLabel = "Device " + (device.IDCode + 1);

            m_configurationFrame.Cells.Add(device);
            listBoxDevices.SelectedIndex = (m_configurationFrame.Cells.Count - 1);
        }

        private void buttonDeviceDelete_Click(object sender, RoutedEventArgs e)
        {
            m_configurationFrame.Cells.Remove(listBoxDevices.SelectedItem as IConfigurationCell);
            
            if (m_configurationFrame.Cells.Count > 0)
                listBoxDevices.SelectedIndex = 0;
        }

        private void buttonDeviceCopy_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxDevices.SelectedItems.Count > 0)
            {
                ConfigurationCell[] selectedItems = listBoxDevices.SelectedItems.Cast<ConfigurationCell>().ToArray();

                foreach (ConfigurationCell selectedItem in selectedItems)
                {
                    if (selectedItem != null)
                        CopyCell(selectedItem);
                }
            }
            else
                MessageBox.Show("No items were selected to copy.");
        }

        private void CopyCell(ConfigurationCell sourceCell)
        {
            // Create a new configuration cell to hold copied information
            ConfigurationCell copiedCell = new ConfigurationCell(m_configurationFrame, 0);

            copiedCell.IDCode = (ushort)m_configurationFrame.Cells.Count;
            copiedCell.IDLabel = "Device " + (copiedCell.IDCode + 1);

            // Create equivalent derived phasor definitions
            foreach (PhasorDefinition sourcePhasor in sourceCell.PhasorDefinitions)
            {
                copiedCell.PhasorDefinitions.Add(new PhasorDefinition(copiedCell, sourcePhasor.Label, sourcePhasor.ScalingValue, sourcePhasor.PhasorType, null));
            }

            // Create equivalent dervied frequency definition
            IFrequencyDefinition sourceFrequency = sourceCell.FrequencyDefinition;

            if (sourceFrequency != null)
                copiedCell.FrequencyDefinition = new FrequencyDefinition(copiedCell, sourceFrequency.Label);

            // Create equivalent dervied analog definitions (assuming analog type = SinglePointOnWave)
            foreach (AnalogDefinition sourceAnalog in sourceCell.AnalogDefinitions)
            {
                copiedCell.AnalogDefinitions.Add(new AnalogDefinition(copiedCell, sourceAnalog.Label, sourceAnalog.ScalingValue, sourceAnalog.AnalogType));
            }

            // Create equivalent dervied digital definitions
            foreach (DigitalDefinition sourceDigital in sourceCell.DigitalDefinitions)
            {
                copiedCell.DigitalDefinitions.Add(new DigitalDefinition(copiedCell, sourceDigital.Label, sourceDigital.MaskValue));
            }

            // Add new copied cell to the list and select it
            m_configurationFrame.Cells.Add(copiedCell);
            listBoxDevices.SelectedIndex = (m_configurationFrame.Cells.Count - 1);
        }

        private void buttonDeviceMoveUp_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listBoxDevices.SelectedIndex;

            if (selectedIndex > 0 && selectedIndex < m_configurationFrame.Cells.Count)
            {
                ConfigurationCell selectedItem = m_configurationFrame.Cells[selectedIndex];
                m_configurationFrame.Cells.RemoveAt(selectedIndex);
                m_configurationFrame.Cells.Insert(selectedIndex - 1, selectedItem);
                listBoxDevices.SelectedIndex = selectedIndex - 1;
            }
        }

        private void buttonDeviceMoveDown_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listBoxDevices.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < m_configurationFrame.Cells.Count - 1)
            {
                ConfigurationCell selectedItem = m_configurationFrame.Cells[selectedIndex];
                m_configurationFrame.Cells.RemoveAt(selectedIndex);
                m_configurationFrame.Cells.Insert(selectedIndex + 1, selectedItem);
                listBoxDevices.SelectedIndex = selectedIndex + 1;
            }
        }

        private void listBoxDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConfigurationCell selectedItem = this.SelectedItem;

            if (selectedItem != null)
            {
                textBoxName.Text = selectedItem.IDLabel;
                textBoxDeviceIDCode.Text = selectedItem.IDCode.ToString();
            }
        }

        private void textBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConfigurationCell selectedItem = this.SelectedItem;

            if (selectedItem != null)
            {
                selectedItem.IDLabel = textBoxName.Text;
                //listBoxDevices.InputBindings
            }
        }

        private void textBoxDeviceIDCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxDeviceIDCode.Text = textBoxDeviceIDCode.Text.RemoveCharacters(c => !Char.IsDigit(c));

            ConfigurationCell selectedItem = this.SelectedItem;

            if (selectedItem != null)
            {
                ushort idCode;

                if (ushort.TryParse(textBoxDeviceIDCode.Text, out idCode))
                    selectedItem.IDCode = idCode;
                else
                    textBoxDeviceIDCode.Text = "0";
            }
        }

        private void textBoxDeviceIDCode_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            textBoxDeviceIDCode.Text = textBoxDeviceIDCode.Text.RemoveCharacters(c => !Char.IsDigit(c));
        }
    }
}
