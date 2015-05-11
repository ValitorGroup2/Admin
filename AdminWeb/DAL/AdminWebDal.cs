using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.DAL
{
	public class AdminWebDal : IAdminWebDal, IDisposable
	{
		#region Initialize
		private AdminWebDalDataContext adminWebContext;

		public AdminWebDal(AdminWebDalDataContext adminWebContext)
		{
			this.adminWebContext = adminWebContext;
		}
		#endregion

		public List<Staff> GetAllStaff()
		{
			List<Staff> allStaff = adminWebContext.Staffs.ToList();

			return allStaff;
		}

		public Staff GetStaffByID(int id)
		{
			Staff staff = adminWebContext.Staffs.Where(s => s.ID == id).SingleOrDefault();

			return staff;
		}

		public void CreateStaff(Staff s)
		{
			adminWebContext.Staffs.InsertOnSubmit(s);
			SaveDB();
		}

		public void EditStaff(Staff s)
		{
			Staff tempStaff = GetStaffByID(s.ID);

			tempStaff.Age = s.Age;
			tempStaff.CompanyID = s.CompanyID;
			tempStaff.Email = s.Email;
			tempStaff.Name = s.Name;
			tempStaff.Password = s.Password;
			tempStaff.Refund = s.Refund;
			tempStaff.Transactions = s.Transactions;

			SaveDB();
		}

		public void DeleteStaff(int id)
		{
			Staff tempStaff = GetStaffByID(id);

			adminWebContext.Staffs.DeleteOnSubmit(tempStaff);
			SaveDB();
		}

		public void SaveDB()
		{
			adminWebContext.SubmitChanges();
		}


		#region Dispose
		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					adminWebContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}