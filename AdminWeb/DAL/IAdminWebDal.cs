using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.DAL
{
	public interface IAdminWebDal : IDisposable
	{
		List<Staff> GetAllStaff();
		Staff GetStaffByID(int id);
		void CreateStaff(Staff s);
		void EditStaff(Staff s);
		void DeleteStaff(int id);
	}
}