using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTailorAdmin.MVC.Models;
using System.Collections.Generic;

using MyTailor.BDO.Orders;
using MyTailor.Logic.Orders;

namespace MyTailorAdmin.MVC.Controllers
{
    public class OrdersController : BaseController
    {
        public OrdersController()
            : base()
        {

        }

        public ActionResult Edit()
        {
            LoadBrudCrumbs(PageMode.Edit);
            return View("Create",new OrderHeader() );
        }

        public ActionResult Create()
        {
            LoadBrudCrumbs(PageMode.Create);
            return View(new OrderHeader());
        }

        public ActionResult Index()
        {
            List<OrderListItem> items = OrderLogic.GetOrdersList();
            return View(items);
        }


        #region Protected Members

        protected override void LoadBrudCrumbs(PageMode currentPageMode = PageMode.Listing)
        {
            List<CrumbItem> crumbs = new List<CrumbItem>();
            crumbs.Add(new CrumbItem { URL = "/", DisplayText = "Home" });
            crumbs.Add(new CrumbItem { URL = "/Orders", DisplayText = "Orders" });
            switch (currentPageMode)
            {
                case PageMode.Create:
                    {
                        crumbs.Add(new CrumbItem { URL = "/Orders/Create", DisplayText = "Create Order" });
                        break;
                    }
                case PageMode.Edit:
                    {
                        crumbs.Add(new CrumbItem { URL = "/Orders/Edit", DisplayText = "Edit Order" });
                        break;
                    }
            }
            ViewBag.Crumbs = crumbs;
            setBreadCrumbData();
        }


        #endregion
    }
}
