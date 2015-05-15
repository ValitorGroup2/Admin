using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.Models
{
	public class DashboardViewModel
	{
		public IEnumerable<Staff> Staffs{ get; set; }
		public IEnumerable<Transaction> Transactions { get; set; }
		public IEnumerable<Notification> Notifications { get; set; }
	}
}