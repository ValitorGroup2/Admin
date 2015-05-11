using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.DAL
{
	public interface IAccountDal : IDisposable
	{
		AspNetUser GetUserByName(string userName);
	}
}