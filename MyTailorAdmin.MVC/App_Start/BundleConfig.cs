using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MyTailorAdmin.MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));


            //var cssjQueryUI = new StyleBundle("~/Content/themes/base/jquery-ui-bundle");
            //cssjQueryUI.IncludeDirectory("~/Content/themes/base", "*.css"); 

        //    bundles.Add(new ScriptBundle("~/bundles/charisma").Include(
        //"~/Content/charisma/js/jquery-1.7.2.min.js",
        //"~/Content/charisma/js/jquery-ui-1.8.21.custom.min.js",
        //"~/Content/charisma/js/bootstrap-transition.js",
        //"~/Content/charisma/js/bootstrap-alert.js",
        //"~/Content/charisma/js/bootstrap-modal.js",
        //"~/Content/charisma/js/bootstrap-dropdown.js",
        //"~/Content/charisma/js/bootstrap-scrollspy.js",
        //"~/Content/charisma/js/bootstrap-tab.js",
        //"~/Content/charisma/js/bootstrap-tooltip.js",
        //"~/Content/charisma/js/bootstrap-popover.js",
        //"~/Content/charisma/js/bootstrap-button.js",
        //"~/Content/charisma/js/bootstrap-collapse.js",
        //"~/Content/charisma/js/bootstrap-carousel.js",
        //"~/Content/charisma/js/bootstrap-typeahead.js",
        //"~/Content/charisma/js/bootstrap-tour.js",
        //"~/Content/charisma/js/jquery.cookie.js",
        //"~/Content/charisma/js/fullcalendar.min.js",
        //"~/Content/charisma/js/jquery.dataTables.min.js",
        //"~/Content/charisma/js/excanvas.js",
        //"~/Content/charisma/js/jquery.flot.min.js",
        //"~/Content/charisma/js/jquery.flot.pie.min.js",
        //"~/Content/charisma/js/jquery.flot.stack.js",
        //"~/Content/charisma/js/jquery.flot.resize.min.js",
        //"~/Content/charisma/js/jquery.chosen.min.js",
        //"~/Content/charisma/js/jquery.uniform.min.js",
        //"~/Content/charisma/js/jquery.colorbox.min.js",
        //"~/Content/charisma/js/jquery.cleditor.min.js",
        //"~/Content/charisma/js/jquery.noty.js",
        //"~/Content/charisma/js/jquery.elfinder.min.js",
        //"~/Content/charisma/js/jquery.raty.min.js",
        //"~/Content/charisma/js/jquery.iphone.toggle.js",
        //"~/Content/charisma/js/jquery.autogrow-textarea.js",
        //"~/Content/charisma/js/jquery.uploadify-3.1.min.js",
        //"~/Content/charisma/js/jquery.history.js",
        //"~/Content/charisma/js/charisma.js"
        //    ));


            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/themes/charismacss").Include(
            //            "~/Content/charisma/TCStyles.css",
            //            "~/Content/charisma/css/bootstrap-responsive.css",
            //            "~/Content/charisma/css/charisma-app.css",
            //            "~/Content/charisma/css/jquery-ui-1.8.21.custom.css",
            //            "~/Content/charisma/css/fullcalendar.css",
            //            "~/Content/charisma/css/fullcalendar.print.css",
            //            "~/Content/charisma/css/chosen.css",
            //            "~/Content/charisma/css/uniform.default.css",
            //            "~/Content/charisma/css/colorbox.css",
            //            "~/Content/charisma/css/jquery.cleditor.css",
            //            "~/Content/charisma/css/jquery.noty.css",
            //            "~/Content/charisma/css/noty_theme_default.css",
            //            "~/Content/charisma/css/elfinder.min.css",
            //            "~/Content/charisma/css/elfinder.theme.css",
            //            "~/Content/charisma/css/jquery.iphone.toggle.css",
            //            "~/Content/charisma/css/opa-icons.css",
            //            "~/Content/charisma/css/uploadify.css"
            //            ));
        }
    }
}