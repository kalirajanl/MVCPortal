using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTailorAdmin.MVC.Models
{
    public class MenuItem
    {
        public string GroupHeader { get; set; }
        public string URL { get; set; }
        public string IconURL { get; set; }
        public string DisplayText { get; set; }
    }
}