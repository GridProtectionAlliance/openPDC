using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace openPDCManager.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        public string GetBaseServiceUrl = ConfigurationManager.AppSettings["BaseServiceUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
