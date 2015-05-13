using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.Models
{
	public class StaffDetailsViewModel
	{
		public Staff Staff { get; set; }

		public IEnumerable<Transaction> Transactions { get; set; }
	}
}