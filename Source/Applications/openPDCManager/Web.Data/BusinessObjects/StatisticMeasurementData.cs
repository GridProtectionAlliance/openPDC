//******************************************************************************************************
//  StatisticMeasurementData.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  06/18/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Collections.ObjectModel;

namespace openPDCManager.Data.BusinessObjects
{
    public class StatisticMeasurementData
    {
        public string SourceType { get; set; }
        public bool IsExpanded { get; set; }
        public ObservableCollection<StreamInfo> SourceStreamInfoList { get; set; }        
    }

    public class StreamInfo
    {
        public int ID { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string StatusColor { get; set; }
        public bool IsExpanded { get; set; }
        public ObservableCollection<DeviceStatistic> DeviceStatisticList { get; set; }
        public ObservableCollection<DetailStatisticInfo> StatisticList { get; set; }
    }

    public class DeviceStatistic
    {
        public int ID { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public bool IsExpanded { get; set; }
        public ObservableCollection<DetailStatisticInfo> StatisticList { get; set; }
    }

    public class DetailStatisticInfo
    {
        public int DeviceID { get; set; }
        public int PointID { get; set; }
        public string PointTag { get; set; }
        public string SignalReference { get; set; }
        public bool IsExpanded { get; set; }
        public BasicStatisticInfo Statistics { get; set; }        
    }

    public class BasicStatisticInfo
    {
        public string Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string TimeTag { get; set; }
        public string Quality { get; set; }
        public string DataType { get; set; }
        public string DisplayFormat { get; set; }
        public bool IsConnectedState { get; set; }
        public int LoadOrder { get; set; }
    }
}
