//*******************************************************************************************************
//  StringToSymbolConverter.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Mehul P. Thakkar
//      Office: INFO SVCS APP DEV, CHATTANOOGA - MR BK-C
//       Phone: 423/751-7571
//       Email: mpthakka@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehul P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace openPDCManager.Silverlight.Converters
{
    public class StringToSymbolConverter : IValueConverter
    {        
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //SolidColorBrush scBrush = new SolidColorBrush();            
            RadialGradientBrush scBrush = new RadialGradientBrush();

            string statusColor = value.ToString();
            //if (statusColor == "<img src=HttpHandlers/PersistantImage.ashx?key=Green border=0>") 
            //    scBrush.Color = Color.FromArgb(255, 10, 255, 25);                           
            //else if (statusColor == "<img src=HttpHandlers/PersistantImage.ashx?key=Gray border=0>")
            //    scBrush.Color = Color.FromArgb(255, 125, 125, 125);                
            //else if (statusColor == "<img src=HttpHandlers/PersistantImage.ashx?key=Yellow border=0>")
            //    scBrush.Color = Color.FromArgb(255, 255, 255, 0);            
            //else if (statusColor == "<img src=HttpHandlers/PersistantImage.ashx?key=Red border=0>")            
            //    scBrush.Color = Color.FromArgb(255, 255, 10, 10);

            if (statusColor.Contains("Green"))
                scBrush = Application.Current.Resources["GreenRadialGradientBrush"] as RadialGradientBrush;
            else if (statusColor.Contains("Gray"))
                scBrush = Application.Current.Resources["GrayRadialGradientBrush"] as RadialGradientBrush;
            else if (statusColor.Contains("Yellow"))
                scBrush = Application.Current.Resources["YellowRadialGradientBrush"] as RadialGradientBrush;
            else if (statusColor.Contains("Red"))
                scBrush = Application.Current.Resources["RedRadialGradientBrush"] as RadialGradientBrush;

            return scBrush as Brush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
