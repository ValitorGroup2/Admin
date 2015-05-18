using AdminWeb.DAL;
using AdminWeb.DAL.Connections;
using AdminWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
		private IAdminWebDal adminWebDB;
		private IAccountDal accountDB;

		public HomeController()
        {
			this.adminWebDB = new AdminWebDal(new AdminWebDalDataContext());
			this.accountDB = new AccountDal(new AccountDataContext(), new AdminWebDalDataContext());
        }
		
		public ActionResult Index()
        {
			int companyID = accountDB.GetUserByName(User.Identity.Name).CompanyID;

			Company company = adminWebDB.GetCompanyByCompanyID(companyID);

			// Check if user has filled his company info, if not then he's redirected to CompanyWizard to fill inn info.
			if (String.IsNullOrEmpty(company.SSN))
			{
				return View("CompanyWizard", company);
			}
			else
			{
				DashboardViewModel dashboardVM = new DashboardViewModel();

				dashboardVM.Staffs = adminWebDB.GetFirst5Staff();
				dashboardVM.Transactions = adminWebDB.Get5NewestTransactions();
				dashboardVM.Notifications = adminWebDB.Get5NewestNotifications();
				dashboardVM.Companies = adminWebDB.First5Companies();

				return View(dashboardVM);
			}
        }
    }
}