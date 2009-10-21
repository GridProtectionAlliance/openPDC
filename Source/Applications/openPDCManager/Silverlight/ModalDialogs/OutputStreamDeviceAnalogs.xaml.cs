using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.ModalDialogs
{
	public partial class OutputStreamDeviceAnalogs : ChildWindow
	{
		int sourceOutputStreamDeviceID;
		string sourceOutputStreamDeviceAcronym;
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		bool inEditMode = false;
		int outputStreamDeviceAnalogID = 0;

		public OutputStreamDeviceAnalogs(int outputStreamDeviceID, string outputStreamDeviceAcronym)
		{
			InitializeComponent();
			sourceOutputStreamDeviceAcronym = outputStreamDeviceAcronym;
			sourceOutputStreamDeviceID = outputStreamDeviceID;
			this.Title = "Manage Analogs For Output Stream Device: " + sourceOutputStreamDeviceAcronym;
			Loaded += new RoutedEventHandler(OutputStreamDeviceAnalogs_Loaded);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetOutputStreamDeviceAnalogListCompleted += new EventHandler<GetOutputStreamDeviceAnalogListCompletedEventArgs>(client_GetOutputStreamDeviceAnalogListCompleted);
			client.SaveOutputStreamDeviceAnalogCompleted += new EventHandler<SaveOutputStreamDeviceAnalogCompletedEventArgs>(client_SaveOutputStreamDeviceAnalogCompleted);
			ListBoxOutputStreamDeviceAnalogList.SelectionChanged += new SelectionChangedEventHandler(ListBoxOutputStreamDeviceAnalogList_SelectionChanged);
		}
		void ListBoxOutputStreamDeviceAnalogList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxOutputStreamDeviceAnalogList.SelectedIndex >= 0)
			{
				OutputStreamDeviceAnalog selectedOutputStreamDeviceAnalog = ListBoxOutputStreamDeviceAnalogList.SelectedItem as OutputStreamDeviceAnalog;
				GridOutputStreamDeviceAnalogDetail.DataContext = selectedOutputStreamDeviceAnalog;
				ComboBoxType.SelectedItem = new KeyValuePair<int, string>(selectedOutputStreamDeviceAnalog.Type, selectedOutputStreamDeviceAnalog.TypeName);
				inEditMode = true;
				outputStreamDeviceAnalogID = selectedOutputStreamDeviceAnalog.ID;
			}
		}
		void client_SaveOutputStreamDeviceAnalogCompleted(object sender, SaveOutputStreamDeviceAnalogCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				ClearForm();
				MessageBox.Show(e.Result);
			}
			else
				MessageBox.Show(e.Error.Message);
			client.GetOutputStreamDeviceAnalogListAsync(sourceOutputStreamDeviceID);
		}
		void client_GetOutputStreamDeviceAnalogListCompleted(object sender, GetOutputStreamDeviceAnalogListCompletedEventArgs e)
		{
			if (e.Error == null)
				ListBoxOutputStreamDeviceAnalogList.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			OutputStreamDeviceAnalog outputStreamDeviceAnalog = new OutputStreamDeviceAnalog();
			App app = (App)Application.Current;

			outputStreamDeviceAnalog.NodeID = app.NodeValue;
			outputStreamDeviceAnalog.OutputStreamDeviceID = sourceOutputStreamDeviceID;
			outputStreamDeviceAnalog.Type = ((KeyValuePair<int, string>)ComboBoxType.SelectedItem).Key;
			outputStreamDeviceAnalog.Label = TextBoxLabel.Text;
			outputStreamDeviceAnalog.LoadOrder = Convert.ToInt32(TextBoxLoadOrder.Text);
			if (inEditMode == true && outputStreamDeviceAnalogID > 0)
			{
				outputStreamDeviceAnalog.ID = outputStreamDeviceAnalogID;
				client.SaveOutputStreamDeviceAnalogAsync(outputStreamDeviceAnalog, false);
			}
			else
				client.SaveOutputStreamDeviceAnalogAsync(outputStreamDeviceAnalog, true);
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearForm();
		}
		void OutputStreamDeviceAnalogs_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetOutputStreamDeviceAnalogListAsync(sourceOutputStreamDeviceID);
			ComboBoxType.Items.Add(new KeyValuePair<int, string>(0, "Single point-on-wave"));
			ComboBoxType.Items.Add(new KeyValuePair<int, string>(1, "RMS of analog input"));
			ComboBoxType.Items.Add(new KeyValuePair<int, string>(1, "Peak of analog input"));
			ComboBoxType.SelectedIndex = 0;
		}
		void ClearForm()
		{
			GridOutputStreamDeviceAnalogDetail.DataContext = new OutputStreamDeviceAnalog();
			ComboBoxType.SelectedIndex = 0;
			inEditMode = false;
			outputStreamDeviceAnalogID = 0;
			ListBoxOutputStreamDeviceAnalogList.SelectedIndex = -1;
		}

	}
}

