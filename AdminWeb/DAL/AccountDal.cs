using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.DAL
{
	public class AccountDal : IAccountDal, IDisposable
	{
		#region Initialize
		private AccountDataContext accountContext;
		private AdminWebDalDataContext adminWebContext;

		public AccountDal(AccountDataContext accountContext, AdminWebDalDataContext adminWebContext)
		{
			this.accountContext = accountContext;
			this.adminWebContext = adminWebContext;
		}
		#endregion

		/// <summary>
		/// Function that returns AspNet user by name
		/// </summary>
		/// <param name="userName"></param>
		/// <returns>AspNetUser</returns>
		public AspNetUser GetUserByName(string userName)
		{
			AspNetUser user = accountContext.AspNetUsers.Where(u => u.UserName == userName).SingleOrDefault();

			return user;
		}

		/// <summary>
		/// Function that updates user information
		/// </summary>
		/// <param name="company"></param>
		public void EditUserInfo(Company company)
		{
			Company tempCompany = adminWebContext.Companies.Where(c => c.ID == company.ID).SingleOrDefault();

			tempCompany.Address = company.Address;
			tempCompany.BankAccount = company.BankAccount;
			tempCompany.City = company.City;
			tempCompany.Email = company.Email;
			tempCompany.Name = company.Name;
			tempCompany.Phone = company.Phone;
			tempCompany.SSN = company.SSN;
			tempCompany.ZipCode = company.ZipCode;

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
					accountContext.Dispose();
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