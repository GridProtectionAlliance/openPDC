using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA;

namespace DataQualityMonitoring.Services
{
    /// <summary>
    /// A class that loads all of the <see cref="IFlatlineService">flatline services</see>.
    /// </summary>
    public class FlatlineServices : AdapterLoader<IFlatlineService>
    {
    }
}
