using GSF.Data.Model;

namespace openPDC.Model
{
    /// <summary>
    /// Will be used to return this view to grafana
    /// </summary>
    public class AlarmDeviceStateView
    {
        [PrimaryKey(true)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Color { get; set; }
        public string DisplayData { get; set; }


    }
}
