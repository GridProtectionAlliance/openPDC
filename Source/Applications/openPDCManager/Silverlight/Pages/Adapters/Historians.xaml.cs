using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages.Adapters
{
	public partial class Historians : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		public Historians()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetHistorianListCompleted +=new EventHandler<GetHistorianListCompletedEventArgs>(client_GetHistorianListCompleted);
			client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
			Loaded += new RoutedEventHandler(Historians_Loaded);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ListBoxHistorianList.SelectionChanged += new SelectionChangedEventHandler(ListBoxHistorianList_SelectionChanged);
		}

		void client_GetNodesCompleted(object sender, GetNodesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboBoxNode.ItemsSource = e.Result;
			if (ComboBoxNode.Items.Count > 0)
				ComboBoxNode.SelectedIndex = 0;
		}
		void ListBoxHistorianList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Historian selectedHistorian = ListBoxHistorianList.SelectedItem as Historian;
			GridHistorianDetail.DataContext = selectedHistorian;
			ComboBoxNode.SelectedItem = new KeyValuePair<Guid, string>(selectedHistorian.NodeID, selectedHistorian.NodeName);
		}
		void Historians_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetHistorianListAsync();
			client.GetNodesAsync(true);
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearForm();
		}
		void client_GetHistorianListCompleted(object sender, GetHistorianListCompletedEventArgs e)
		{
			if (e.Error == null)
				ListBoxHistorianList.ItemsSource = e.Result;
		}
		void ClearForm()
		{
			TextBoxAcronym.Text = string.Empty;
			TextBoxName.Text = string.Empty;
			TextBoxDescription.Text = string.Empty;
			TextBoxTypeName.Text = string.Empty;
			TextBoxAssemblyName.Text = string.Empty;
			TextBoxConnectionString.Text = string.Empty;
			CheckboxEnabled.IsChecked = false;
			if (ComboBoxNode.Items.Count > 0)
				ComboBoxNode.SelectedIndex = 0;
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
