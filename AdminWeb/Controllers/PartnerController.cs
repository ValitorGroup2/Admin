using AdminWeb.DAL;
using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
	[Authorize(Roles = "Admin, Partner")]
	public class PartnerController : Controller
    {
        private IAdminWebDal adminWebDB;
		private IAccountDal accountDB;

		public PartnerController()
        {
			this.adminWebDB = new AdminWebDal(new AdminWebDalDataContext());
			this.accountDB = new AccountDal(new AccountDataContext(), new AdminWebDalDataContext());
        }
		
		// GET: Partner
        public ActionResult Companies()
        {
			var companies = adminWebDB.GetAllCompanies();
			
			return View(companies);
        }

        // GET: Partner/Details/5
        public ActionResult Company(int id)
        {
			var company = adminWebDB.GetCompanyByCompanyID(id);
			
			return View(company);
        }

    }
}
