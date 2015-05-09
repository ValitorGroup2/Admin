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