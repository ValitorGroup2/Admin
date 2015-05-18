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
		AspNetUser GetUserByID(string id);
		AspNetUser GetUserCompanyID(int id);
		void EditUserInfo(Company company);
		bool IsVerified(int id);
		Company VerifyUserByCompanyID(int id);
	}
}