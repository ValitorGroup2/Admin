using AdminWeb.DAL;
using AdminWeb.DAL.Connections;
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
			Company company = adminWebDB.GetCompanyByName(User.Identity.Name);

			if (String.IsNullOrEmpty(company.SSN))
			{
				return View("CompanyWizard", company);
			}
			else
			{
				ViewData["SubTitle"] = "I be out! ";
				ViewData["Message"] = "Jeeee body!";
				ViewData["Strengur"] = "Djamm í kvöld...!";

				return View();
			}
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }

    }
}