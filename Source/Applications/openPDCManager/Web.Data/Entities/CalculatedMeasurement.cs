//*******************************************************************************************************
//  CalculatedMeasurement.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace openPDCManager.Web.Data.Entities
{
    public class CalculatedMeasurement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string AssemblyName { get; set; }
        public string ConfigSection { get; set; }
        public string OutputMeasurementsSql { get; set; }
        public string InputMeasurementsSql { get; set; }
        public int MinimumInputMeasurements { get; set; }
        public int ExpectedFrameRate { get; set; }
        public decimal LagTime { get; set; }
        public decimal LeadTime { get; set; }
        public bool Enabled { get; set; }
    }
}
