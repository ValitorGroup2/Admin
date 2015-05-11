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

		public AccountDal(AccountDataContext accountContext)
		{
			this.accountContext = accountContext;
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