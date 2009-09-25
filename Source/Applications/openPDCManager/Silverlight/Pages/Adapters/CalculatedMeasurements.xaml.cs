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
using System.Windows.Navigation;
using System.ServiceModel;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages.Adapters
{
	public partial class CalculatedMeasurements : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		bool inEditMode = false;
		int calculatedMeasurementID = 0;

		public CalculatedMeasurements()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);			
			client.GetCalculatedMeasurementListCompleted += new EventHandler<GetCalculatedMeasurementListCompletedEventArgs>(client_GetCalculatedMeasurementListCompleted);
			client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
			client.SaveCalculatedMeasurementCompleted += new EventHandler<SaveCalculatedMeasurementCompletedEventArgs>(client_SaveCalculatedMeasurementCompleted);
			Loaded += new RoutedEventHandler(CalculatedMeasurements_Loaded);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ListBoxCalculatedMeasurementList.SelectionChanged += new SelectionChangedEventHandler(ListBoxCalculatedMeasurementList_SelectionChanged);
		}
		void client_SaveCalculatedMeasurementCompleted(object sender, SaveCalculatedMeasurementCompletedEventArgs e)
		{
			if (e.Error == null)
				MessageBox.Show(e.Result);
			else
				MessageBox.Show(e.Error.Message);
			client.GetCalculatedMeasurementListAsync();
		}
		void client_GetNodesCompleted(object sender, GetNodesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboBoxNode.ItemsSource = e.Result;
			if (ComboBoxNode.Items.Count > 0)
				ComboBoxNode.SelectedIndex = 0;
		}
		void ListBoxCalculatedMeasurementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxCalculatedMeasurementList.SelectedIndex >= 0)
			{
				openPDCManager.Silverlight.PhasorDataServiceProxy.CalculatedMeasurement selectedCalculatedMeasurement = ListBoxCalculatedMeasurementList.SelectedItem as openPDCManager.Silverlight.PhasorDataServiceProxy.CalculatedMeasurement;
				GridCalculatedMeasurementDetail.DataContext = selectedCalculatedMeasurement;
				ComboBoxNode.SelectedItem = new KeyValuePair<Guid, string>(selectedCalculatedMeasurement.NodeId, selectedCalculatedMeasurement.NodeName);
				calculatedMeasurementID = selectedCalculatedMeasurement.ID;
				inEditMode = true;
			}

		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearForm();
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			openPDCManager.Silverlight.PhasorDataServiceProxy.CalculatedMeasurement calculatedMeasurement = new openPDCManager.Silverlight.PhasorDataServiceProxy.CalculatedMeasurement();
			calculatedMeasurement.NodeId = ((KeyValuePair<Guid, string>)ComboBoxNode.SelectedItem).Key;
			calculatedMeasurement.Acronym = TextBoxAcronym.Text;
			calculatedMeasurement.Name = TextBoxName.Text;
			calculatedMeasurement.AssemblyName = TextBoxAssemblyName.Text;
			calculatedMeasurement.TypeName = TextBoxTypeName.Text;
			calculatedMeasurement.ConnectionString = TextBoxConnectionString.Text;
			calculatedMeasurement.ConfigSection = TextBoxConfigSection.Text;
			calculatedMeasurement.InputMeasurements = TextBoxInputMeasurements.Text;
			calculatedMeasurement.OutputMeasurements = TextBoxOutputMeasurements.Text;
			calculatedMeasurement.MinimumMeasurementsToUse = Convert.ToInt32(TextBoxMinMeasurements.Text);
			calculatedMeasurement.FramesPerSecond = Convert.ToInt32(TextBoxFramesPerSecond.Text);
			calculatedMeasurement.LagTime = Convert.ToDouble(TextBoxLagTime.Text);
			calculatedMeasurement.LeadTime = Convert.ToDouble(TextBoxLeadTime.Text);
			calculatedMeasurement.UseLocalClockAsRealTime = (bool)CheckBoxUseLocalClock.IsChecked;
			calculatedMeasurement.AllowSortsByArrival = (bool)CheckBoxAllowSorts.IsChecked;
			calculatedMeasurement.LoadOrder = Convert.ToInt32(TextBoxLoadOrder.Text);
			calculatedMeasurement.Enabled = (bool)CheckBoxEnabled.IsChecked;

			if (inEditMode == true && calculatedMeasurementID > 0)
			{
				calculatedMeasurement.ID = calculatedMeasurementID;
				client.SaveCalculatedMeasurementAsync(calculatedMeasurement, false);
			}
			else
				client.SaveCalculatedMeasurementAsync(calculatedMeasurement, true);
		}
		void CalculatedMeasurements_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetCalculatedMeasurementListAsync();
			client.GetNodesAsync(true, false);
		}
		void client_GetCalculatedMeasurementListCompleted(object sender, GetCalculatedMeasurementListCompletedEventArgs e)
		{
			if (e.Error == null)
				ListBoxCalculatedMeasurementList.ItemsSource = e.Result;
		}
		void ClearForm()
		{
			GridCalculatedMeasurementDetail.DataContext = new CalculatedMeasurement();
			if (ComboBoxNode.Items.Count > 0)
				ComboBoxNode.SelectedIndex = 0;
			inEditMode = false;
			calculatedMeasurementID = 0;
			ListBoxCalculatedMeasurementList.SelectedIndex = -1;
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
