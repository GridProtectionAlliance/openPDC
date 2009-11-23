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
using openPDCManager.Silverlight.Utilities;
using System.Windows.Media.Imaging;


namespace openPDCManager.Silverlight.ModalDialogs
{
	public partial class SystemMessages : ChildWindow
	{
		Message systemMessage = new Message();
		public SystemMessages(Message message, ButtonType buttonType)
		{
			InitializeComponent();
			systemMessage = message;
			Loaded += new RoutedEventHandler(SystemMessages_Loaded);
			ButtonOk.Click += new RoutedEventHandler(ButtonOk_Click);
			if (message.UserMessageType == MessageType.Success)
			{
				this.Title = "openPDCManager: Operation Completed Successfully!";
				TextBlockMessageType.Text = "SUCCESS";
				ImageMessageType.Source = new BitmapImage(new Uri(@"../Images/Success.png", UriKind.Relative));
				BorderMain.Background = Application.Current.Resources["GreenRadialGradientBrush"] as Brush;
			}
			else if (message.UserMessageType == MessageType.Warning)
			{
				this.Title = "openPDCManager: Warning!";
				TextBlockMessageType.Text = "WARNING";
				ImageMessageType.Source = new BitmapImage(new Uri(@"../Images/Warning.png", UriKind.Relative));
				BorderMain.Background = Application.Current.Resources["YellowRadialGradientBrush"] as Brush;
			}
			else if (message.UserMessageType == MessageType.Error)
			{
				this.Title = "openPDCManager: Error Occured!";
				TextBlockMessageType.Text = "ERROR";
				ImageMessageType.Source = new BitmapImage(new Uri(@"../Images/Error.png", UriKind.Relative));
				BorderMain.Background = Application.Current.Resources["RedRadialGradientBrush"] as Brush;
			}
			else //treat as information.
			{
				this.Title = "openPDCManager: Information Only!";
				TextBlockMessageType.Text = "INFORMATION";
				ImageMessageType.Source = new BitmapImage(new Uri(@"../Images/Information.png", UriKind.Relative));
				BorderMain.Background = Application.Current.Resources["BlueRadialGradientBrush"] as Brush;
			}

			if (buttonType == ButtonType.OkOnly)
			{
				ButtonOk.Visibility = Visibility.Visible;
				ButtonCancel.Visibility = Visibility.Collapsed;
				ButtonYes.Visibility = Visibility.Collapsed;
				ButtonNo.Visibility = Visibility.Collapsed;
			}
			else if (buttonType == ButtonType.OkCancel)
			{
				ButtonOk.Visibility = Visibility.Visible;
				ButtonCancel.Visibility = Visibility.Visible;
				ButtonYes.Visibility = Visibility.Collapsed;
				ButtonNo.Visibility = Visibility.Collapsed;
			}
			else if (buttonType == ButtonType.YesNo)
			{
				ButtonOk.Visibility = Visibility.Collapsed;
				ButtonCancel.Visibility = Visibility.Collapsed;
				ButtonYes.Visibility = Visibility.Visible;
				ButtonNo.Visibility = Visibility.Visible;
			}
			else if (buttonType == ButtonType.YesNoCancel)
			{
				ButtonOk.Visibility = Visibility.Collapsed;
				ButtonCancel.Visibility = Visibility.Visible;
				ButtonYes.Visibility = Visibility.Visible;
				ButtonNo.Visibility = Visibility.Visible;
			}

		}

		void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		void SystemMessages_Loaded(object sender, RoutedEventArgs e)
		{
			GridSystemMessageDetail.DataContext = systemMessage;
		}

		private void OKButton_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}
	}
}

