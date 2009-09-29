using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using openPDCManager.Web.Data.Entities;

namespace openPDCManager.Web.Data.BusinessObjects
{
	public class IaonTree
	{
		public string AdapterType { get; set; }
		public List<Adapter> AdapterList { get; set; }
	}

}
