using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.DAL
{
	public interface IAdminWebDal : IDisposable
	{
		#region Staff functions
		List<Staff> GetAllStaff();
		Staff GetStaffByID(int id);
		void CreateStaff(Staff s);
		void EditStaff(Staff s);
		void DeleteStaff(int id);
		#endregion

		#region Transaction functions
		List<Transaction> GetAllTransactions();
		List<Transaction> GetAllTransactionsForUser(int staffID);
		Transaction GetTransactionByID(int id);
		#endregion

		#region Notification functions
		List<Notification> GetAllNotifications();
		Notification GetNotificationByID(int id);
		#endregion

		#region Company
		Company GetCompanyByCompanyID(int id);
		#endregion
	}
}