using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace openPDCManager.Data.Entities
{
    public class ErrorLog
    {
        public int ID { get; set; }
        public string Source { get; set; }
        public string Message { get; set;}
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
