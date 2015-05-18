using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.Models
{
	public class CompanyDetailsViewModel
	{
		public Company Company { get; set; }
		public AspNetUser User { get; set; }
	}
}