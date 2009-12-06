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
using openPDCManager.Silverlight.Utilities;
using openPDCManager.Silverlight.ModalDialogs;

namespace openPDCManager.Silverlight.UserControls
{
	public partial class SelectNode : UserControl
	{		
		PhasorDataServiceClient client;

		public delegate void OnNodesChanged(object sender, RoutedEventArgs e);
		public event OnNodesChanged NodeCollectionChanged;
		bool raiseNodesCollectionChanged = false;

		public SelectNode()
		{
			InitializeComponent();
			client = Common.GetPhasorDataServiceProxyClient();
			client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
			ComboboxNode.SelectionChanged += new SelectionChangedEventHandler(ComboboxNode_SelectionChanged);
			Loaded += new RoutedEventHandler(SelectNode_Loaded);
		}

		void SelectNode_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetNodesAsync(true, false);
		}

		void ComboboxNode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!raiseNodesCollectionChanged)
			{
				App app = (App)Application.Current;
				app.NodeValue = ((KeyValuePair<string, string>)ComboboxNode.SelectedItem).Key;
				app.NodeName = ((KeyValuePair<string, string>)(ComboboxNode.SelectedItem)).Value;
			}
		}

		void client_GetNodesCompleted(object sender, GetNodesCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				ComboboxNode.ItemsSource = e.Result;
				App app = (App)Application.Current;
				if (ComboboxNode.Items.Count > 0)
				{
					if (!string.IsNullOrEmpty(app.NodeValue))
					{
						foreach (KeyValuePair<string, string> item in ComboboxNode.Items)
						{
							if (item.Key == app.NodeValue)
							{
								ComboboxNode.SelectedItem = item;
								break;
							}

						}
					}
					else
						ComboboxNode.SelectedIndex = 0;
					app.NodeValue = ((KeyValuePair<string, string>)(ComboboxNode.SelectedItem)).Key;
					app.NodeName = ((KeyValuePair<string, string>)(ComboboxNode.SelectedItem)).Value;
				}
				else
					app.NodeValue = string.Empty;
			}
			else
			{
				SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						 ButtonType.OkOnly);
				sm.Show();
			}
			raiseNodesCollectionChanged = false;
		}

		public void RefreshNodeList()
		{				
			client.GetNodesAsync(true, false);			
		}

		public void RaiseNotification()
		{
			raiseNodesCollectionChanged = true;
			if (NodeCollectionChanged != null && raiseNodesCollectionChanged)
				NodeCollectionChanged(this, null);
						
		}
		
	}
}
