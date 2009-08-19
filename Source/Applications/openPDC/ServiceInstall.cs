using System.ComponentModel;
using System.Configuration.Install;


namespace openPDC
{
    [RunInstaller(true)]
    public partial class ServiceInstall : Installer
    {
        public ServiceInstall()
        {
            InitializeComponent();
        }
    }
}
