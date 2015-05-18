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

		#region Staff functions
		/// <summary>
		/// Function that returns all Staff accounts
		/// </summary>
		/// <returns>List of Staff accounts</returns>
		public List<Staff> GetAllStaff()
		{
			List<Staff> allStaff = adminWebContext.Staffs.ToList();

			return allStaff;
		}

		/// <summary>
		/// Function that returns 5 newest Staff accounts
		/// </summary>
		/// <returns>List of Sstaff accounts</returns>
		public List<Staff> GetFirst5Staff()
		{
			List<Staff> first5Staff = adminWebContext.Staffs.OrderByDescending(s => s.ID).ToList();

			return first5Staff;
		}

		/// <summary>
		/// Function that takes in id and returns corresponding Staff
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Staff account</returns>
		public Staff GetStaffByID(int id)
		{
			Staff staff = adminWebContext.Staffs.Where(s => s.ID == id).SingleOrDefault();

			return staff;
		}

		/// <summary>
		/// Function that inserts Staff to database
		/// </summary>
		/// <param name="s"></param>
		public void CreateStaff(Staff s)
		{
			adminWebContext.Staffs.InsertOnSubmit(s);
			SaveDB();
		}

		/// <summary>
		/// Function that edits Staff and saves changes in DB
		/// </summary>
		/// <param name="s"></param>
		public void EditStaff(Staff s)
		{
			Staff tempStaff = GetStaffByID(s.ID);

			tempStaff.Age = s.Age;
			tempStaff.CompanyID = s.CompanyID;
			tempStaff.Email = s.Email;
			tempStaff.Name = s.Name;
			tempStaff.Password = s.Password;
			tempStaff.Refund = s.Refund;

			SaveDB();
		}

		/// <summary>
		/// Function that removes Staff from database
		/// </summary>
		/// <param name="id"></param>
		public void DeleteStaff(int id)
		{
			Staff tempStaff = GetStaffByID(id);

			adminWebContext.Staffs.DeleteOnSubmit(tempStaff);
			SaveDB();
		}
		#endregion

		#region Transactions
		/// <summary>
		/// Function that returns a list of all transactions
		/// </summary>
		/// <returns>List<Transaction><returns>
		public List<Transaction> GetAllTransactions()
		{
			List<Transaction> allTransactions = adminWebContext.Transactions.ToList();

			return allTransactions;
		}

		/// <summary>
		/// Function that returns newest 5 transactions
		/// </summary>
		/// <returns>List of 5 newest transactions</returns>
		public List<Transaction> Get5NewestTransactions()
		{
			List<Transaction> getFirst5Transactions = adminWebContext.Transactions.OrderByDescending(t => t.Date).ToList();

			return getFirst5Transactions;
		}

		/// <summary>
		/// Function that returns all transactions for given user
		/// </summary>
		/// <param name="staffID"></param>
		/// <returns> List<Transactions> </returns>
		public List<Transaction> GetAllTransactionsForUser(int staffID)
		{
			List<Transaction> allTransactionsForUser = adminWebContext.Transactions.Where(t => t.ID == staffID).ToList();

			return allTransactionsForUser;
		}

		/// <summary>
		/// Function that returns transaction from specific ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Transaction</returns>
		public Transaction GetTransactionByID(int id)
		{
			Transaction transaction = adminWebContext.Transactions.Where(t => t.ID == id).SingleOrDefault();

			return transaction;
		}
		#endregion

		#region Notifications
		/// <summary>
		/// Function that returns all notifications
		/// </summary>
		/// <returns>List<Notification></returns>
		public List<Notification> GetAllNotifications()
		{
			List<Notification> allNotifications = adminWebContext.Notifications.ToList();

			return allNotifications;
		}

		/// <summary>
		/// Function that returns 5 newest notifications
		/// </summary>
		/// <returns>List of 5 newest notifications</returns>
		public List<Notification> Get5NewestNotifications()
		{
			List<Notification> get5NewestNotifiactions = adminWebContext.Notifications.OrderByDescending(n => n.Date).ToList();

			return get5NewestNotifiactions;
		}
		
		/// <summary>
		/// Function that returns notification by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Notification</returns>
		public Notification GetNotificationByID(int id)
		{
			Notification notification = adminWebContext.Notifications.Where(n => n.ID == id).SingleOrDefault();

			return notification;
		}
		#endregion

		#region Company
		/// <summary>
		/// Function that returns first 5 companies
		/// </summary>
		/// <returns>List of Company</returns>
		public List<Company> First5Companies()
		{
			List<Company> first5Companies = adminWebContext.Companies.OrderByDescending(c => c.ID).Take(5).ToList();

			return first5Companies;
		}

		/// <summary>
		/// Function that returns Company from DB by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Company</returns>
		public Company GetCompanyByCompanyID(int id)
		{
			Company company = adminWebContext.Companies.Where(c => c.ID == id).SingleOrDefault();

			return company;
		}

		/// <summary>
		/// Function that returns company from name
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Company</returns>
		public Company GetCompanyByName(string name)
		{
			Company company = adminWebContext.Companies.Where(c => c.Name == name).SingleOrDefault();

			return company;
		}

		/// <summary>
		/// Function that creates new company in DB
		/// </summary>
		/// <param name="company"></param>
		public void CreateCompany(Company company)
		{
			adminWebContext.Companies.InsertOnSubmit(company);
			SaveDB();
		}

		/// <summary>
		/// Function that returns all companies
		/// </summary>
		/// <returns>List of companies</returns>
		public List<Company> GetAllCompanies()
		{
			List<Company> getAllCompanies = adminWebContext.Companies.ToList();

			return getAllCompanies;
		}
		#endregion

		/// <summary>
		/// Function that saves DB
		/// </summary>
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