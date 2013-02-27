using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using MyTailorAdmin.MVC.Models;
using System.Collections.Generic;

namespace MyTailorAdmin.MVC.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        protected override void LoadBrudCrumbs(PageMode currentPageMode)
        {
            List<CrumbItem> crumbs = new List<CrumbItem>();
            crumbs.Add(new CrumbItem { DisplayText = "My Dashboard", URL = "/" });
            ViewBag.Crumbs = crumbs;
            setBreadCrumbData();
        }
    }
}
