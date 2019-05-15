using System.ComponentModel.DataAnnotations;
using GSF.Data.Model;

namespace openPDC.Model
{
    public class AlarmState
    {
        [PrimaryKey(true)]
        public int ID { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Color { get; set; }
        
        [StringLength(50)]
        public string Priority { get; set; }

    }
}
