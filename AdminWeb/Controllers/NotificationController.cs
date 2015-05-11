using AdminWeb.DAL;
using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
    public class NotificationController : Controller
    {
        private IAdminWebDal adminWebDB;
		private IAccountDal accountDB;

		public NotificationController()
        {
			this.adminWebDB = new AdminWebDal(new AdminWebDalDataContext());
			this.accountDB = new AccountDal(new AccountDataContext(), new AdminWebDalDataContext());
        }
		
		// GET: Notification
        public ActionResult Index()
        {
			var notifications = adminWebDB.GetAllNotifications();
			
			return View(notifications);
        }

        // GET: Notification/Details/5
        public ActionResult Details(int id)
        {
			var notification = adminWebDB.GetNotificationByID(id);
			
			return View(notification);
        }
    }
}
