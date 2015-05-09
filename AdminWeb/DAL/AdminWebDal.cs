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