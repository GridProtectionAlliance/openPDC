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

namespace openPDCManager.Silverlight.ModalDialogs
{
	public partial class ActivityWindow : ChildWindow
	{
		string displayMessage;
		public ActivityWindow(string message)
		{
			InitializeComponent();
			displayMessage = message;
			Loaded += new RoutedEventHandler(ActivityWindow_Loaded);
			Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(ActivityWindow_Closing);
		}

		void ActivityWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			TextBlockMessage.Text = string.Empty;
		}

		void ActivityWindow_Loaded(object sender, RoutedEventArgs e)
		{
			TextBlockMessage.Text = displayMessage;
		}
	}
}

