﻿using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MyTailorAdmin.MVC.Models;
using System.Collections.Generic;

using MyTailor.BDO.Masters;
using MyTailor.Logic.Masters;

namespace MyTailorAdmin.MVC.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.CrumbData = "";
            LoadBrudCrumbs();
            loadMenuItems();
            loadMasters();
        }

        #region Protected Members

        protected enum PageMode
        {
            Listing = 1,
            Create = 2,
            Edit = 3,
            Delete = 4
        }

        protected virtual void LoadBrudCrumbs(PageMode currentPageMode = PageMode.Listing)
        {
            List<CrumbItem> crumbs = new List<CrumbItem>();
            ViewBag.Crumbs = crumbs;
            setBreadCrumbData();
        }

        protected virtual void loadMenuItems()
        {
            List<MenuItem> menus = new List<MenuItem>();

            menus.Add(new MenuItem { GroupHeader = "Main", DisplayText = "Dashboard", URL = "/", IconURL = "icon-home" });

            menus.Add(new MenuItem { GroupHeader = "Lists", DisplayText = "Customers", URL = "/Customers", IconURL = "icon-tag" });
            menus.Add(new MenuItem { GroupHeader = "Lists", DisplayText = "Orders", URL = "/Orders", IconURL = "icon-barcode" });
            menus.Add(new MenuItem { GroupHeader = "Lists", DisplayText = "Customer Service", URL = "/CustomerService", IconURL = "icon-comment" });
            menus.Add(new MenuItem { GroupHeader = "Lists", DisplayText = "Itinerary", URL = "/Itinerarys", IconURL = "icon-list" });

            menus.Add(new MenuItem { GroupHeader = "Masters", DisplayText = "Tailor", URL = "/Tailors", IconURL = "icon-bookmark" });
            menus.Add(new MenuItem { GroupHeader = "Masters", DisplayText = "Supplier", URL = "/Suppliers", IconURL = "icon-tags" });
            menus.Add(new MenuItem { GroupHeader = "Masters", DisplayText = "Sales Men", URL = "/SalesMen", IconURL = "icon-road" });
            menus.Add(new MenuItem { GroupHeader = "Masters", DisplayText = "Style", URL = "/Styles", IconURL = "icon-star" });

            menus.Add(new MenuItem { GroupHeader = "Security", DisplayText = "Home", URL = "/Security", IconURL = "icon-lock" });
            menus.Add(new MenuItem { GroupHeader = "Security", DisplayText = "User Profiles", URL = "/UserProfiles", IconURL = "icon-user" });
            menus.Add(new MenuItem { GroupHeader = "Security", DisplayText = "Roles", URL = "/Roles", IconURL = "icon-book" });

            ViewBag.Menus = menus;
            setMenuData();
        }

        protected void setMenuData()
        {
            List<MenuItem> menus = ViewBag.Menus;
            StringBuilder sbMenu = new StringBuilder();
            if (menus == null)
            {
                menus = new List<MenuItem>();
            }
            if (menus.Count <= 0)
            {
                menus.Add(new MenuItem { GroupHeader = "Main", DisplayText = "Dashboard", URL = "/Home", IconURL = "icon-home" });
            }
            string grpHeader = "";
            for (int i = 0; i <= menus.Count - 1; i++)
            {
                if (!grpHeader.Equals(menus[i].GroupHeader))
                {
                    grpHeader = menus[i].GroupHeader;
                    sbMenu.AppendLine("<li class='nav-header hidden-tablet'>" + grpHeader.Replace(" ", "&nbsp;") + "</li>");
                }
                sbMenu.Append("<li>");
                sbMenu.Append("<a class='ajax-link' href='" + menus[i].URL + "'>");
                if (!menus[i].IconURL.Trim().Equals(""))
                {
                    sbMenu.Append("<i class='" + menus[i].IconURL + "'></i>");
                }
                sbMenu.Append("<span class='hidden-tablet'>&nbsp;&nbsp;" + menus[i].DisplayText.Replace(" ", "&nbsp;") + "</span>");
                sbMenu.Append("</a>");
                sbMenu.AppendLine("</li>");
            }

            ViewBag.MenuData = sbMenu.ToString();
        }

        protected void setBreadCrumbData()
        {
            List<CrumbItem> crumbs = ViewBag.Crumbs;
            StringBuilder sbCrumb = new StringBuilder();
            if (crumbs == null)
            {
                crumbs = new List<CrumbItem>();
            }
            if (crumbs.Count <= 0)
            {
                crumbs.Add(new CrumbItem { DisplayText = "Dashboard", URL = "/Home" });
            }
            for (int i = 0; i <= crumbs.Count - 1; i++)
            {
                sbCrumb.AppendLine("<li>");
                if (i == crumbs.Count - 1)
                {
                    sbCrumb.AppendLine(crumbs[i].DisplayText);
                }
                else
                {
                    if (crumbs[i].URL.Equals(""))
                    {
                        sbCrumb.AppendLine("<a href=" + Convert.ToChar(34) + "#" + Convert.ToChar(34) + ">" + crumbs[i].DisplayText + "</a>");
                    }
                    else
                    {
                        sbCrumb.AppendLine("<a href=" + Convert.ToChar(34) + crumbs[i].URL + Convert.ToChar(34) + ">" + crumbs[i].DisplayText + "</a>");
                    }
                }
                if (i != crumbs.Count - 1)
                {
                    sbCrumb.AppendLine("&nbsp;<span class=" + Convert.ToChar(34) + "divider" + Convert.ToChar(34) + ">&gt;&gt;</span>&nbsp;");
                }
                sbCrumb.AppendLine("</li>");
            }
            ViewBag.CrumbData = sbCrumb.ToString();
        }

        #endregion

        #region Private Members

        private void loadMasters()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<SalesMan> sms = SalesManLogic.GetSalesMen();
            foreach (SalesMan t in sms)
            {
                SelectListItem s = new SelectListItem();
                s.Text = t.LastName;
                s.Value = t.SalesManID.ToString();
                items.Add(s);
            }
            ViewBag.SalesMen = items;
        }

        #endregion
    }
}