using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace openPDCManager.Silverlight.Converters
{
	public class BooleanToColorConverter : IValueConverter
	{

		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			SolidColorBrush scBrush = new SolidColorBrush();            
			
			if ((bool) value)
				scBrush.Color = Color.FromArgb(255, 10, 255, 25);
			else
				scBrush.Color = Color.FromArgb(255, 255, 10, 10);

			return scBrush as Brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

		#endregion
	}
}
