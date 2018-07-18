using System;
using System.ComponentModel.DataAnnotations;
using GSF.ComponentModel;
using GSF.Data.Model;

namespace openPDC.Model
{
    public class AlarmDevice
    {
        [PrimaryKey(true)]
        public int ID { get; set; }

        public int DeviceID { get; set; }

        public int StateID { get; set; }

        [DefaultValueExpression("DateTime.UtcNow")]
        [UpdateValueExpression("DateTime.UtcNow")]
        public DateTime TimeStamp { get; set; }

        [StringLength(10)]
        public string DisplayData { get; set; }
    }
}
