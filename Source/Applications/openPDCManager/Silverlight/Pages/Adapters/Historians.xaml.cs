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

		bool inEditMode;
		int historianID;

		public Historians()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetHistorianListCompleted +=new EventHandler<GetHistorianListCompletedEventArgs>(client_GetHistorianListCompleted);
			client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
			client.SaveHistorianCompleted += new EventHandler<SaveHistorianCompletedEventArgs>(client_SaveHistorianCompleted);
			Loaded += new RoutedEventHandler(Historians_Loaded);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ListBoxHistorianList.SelectionChanged += new SelectionChangedEventHandler(ListBoxHistorianList_SelectionChanged);
		}

		void client_SaveHistorianCompleted(object sender, SaveHistorianCompletedEventArgs e)
		{
			if (e.Error == null)
				MessageBox.Show(e.Result);
			else
				MessageBox.Show(e.Error.ToString());
			client.GetHistorianListAsync();
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
			if (ListBoxHistorianList.SelectedIndex >= 0)
			{
				Historian selectedHistorian = ListBoxHistorianList.SelectedItem as Historian;
				GridHistorianDetail.DataContext = selectedHistorian;
				ComboBoxNode.SelectedItem = new KeyValuePair<Guid, string>(selectedHistorian.NodeID, selectedHistorian.NodeName);
				inEditMode = true;
				historianID = selectedHistorian.ID;
			}
		}
		void Historians_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetHistorianListAsync();
			client.GetNodesAsync(true, false);
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			Historian historian = new Historian();
			historian.NodeID = ((KeyValuePair<Guid, string>)ComboBoxNode.SelectedItem).Key;
			historian.Acronym = TextBoxAcronym.Text;
			historian.Name = TextBoxName.Text;
			historian.AssemblyName = TextBoxAssemblyName.Text;
			historian.TypeName = TextBoxTypeName.Text;
			historian.ConnectionString = TextBoxConnectionString.Text;
			historian.IsLocal = (bool)CheckboxIsLocal.IsChecked;
			historian.Description = TextBoxDescription.Text;
			historian.LoadOrder = Convert.ToInt32(TextBoxLoadOrder.Text);
			historian.Enabled = (bool)CheckboxEnabled.IsChecked;

			if (inEditMode == true && historianID > 0)
			{
				historian.ID = historianID;
				client.SaveHistorianAsync(historian, false);
			}
			else
				client.SaveHistorianAsync(historian, true);
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
			GridHistorianDetail.DataContext = new Historian();	// bind an empty historian.
			if (ComboBoxNode.Items.Count > 0)
				ComboBoxNode.SelectedIndex = 0;
			inEditMode = false;
			historianID = 0;
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
