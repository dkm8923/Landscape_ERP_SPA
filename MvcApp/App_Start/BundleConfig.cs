using System.Web;
using System.Web.Optimization;

namespace MvcApp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/AdminLte/dist/css").Include(
                        "~/AdminLte/dist/css/AdminLTE.css",
                        "~/AdminLte/dist/css/skins/_all-skins.css",
                        "~/AdminLte/Plugins/dataTables/dataTables.bootstrap.css",
                        "~/AdminLte/Plugins/dataTables/jquery.dataTables.css"));

            bundles.Add(new ScriptBundle("~/AdminLte/dist/js").Include(
                        "~/AdminLte/dist/js/app.js", //AdminLTE App
                        //"~/AdminLte/dist/js/pages/dashboard.js", //AdminLTE dashboard demo (This is only for demo purposes)
                        "~/AdminLte/dist/js/demo.js", //AdminLTE for demo purposes
                        "~/AdminLte/Plugins/dataTables/jquery.dataTables.js",
                        "~/AdminLte/Plugins/dataTables/dataTables.bootstrap.js")); 

            //Theme style 
            bundles.Add(new StyleBundle("~/AdminLte/Plugins").Include(
                        "~/AdminLte/Plugins/iCheck/flat/blue.css", //iCheck
                        "~/AdminLte/Plugins/morris/morris.css", //Morris chart
                        "~/AdminLte/Plugins/jvectormap/jquery-jvectormap-1.2.2.css", //jvectormap
                        "~/AdminLte/Plugins/datepicker/datepicker3.css", //Date Picker
                        "~/AdminLte/Plugins/daterangepicker/daterangepicker-bs3.css", //Daterange picker
                        "~/AdminLte/Plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.css")); //bootstrap wysihtml5 - text editor

            //Admin Lte Scripts 
            bundles.Add(new ScriptBundle("~/AdminLte/Plugins/js").Include(
                        "~/AdminLte/Plugins/morris/raphael.js", //Morris.js charts
                        "~/AdminLte/Plugins/morris/morris.js", //Morris.js charts
                        "~/AdminLte/Plugins/sparkline/jquery.sparkline.js", //Sparkline
                        "~/AdminLte/Plugins/jvectormap/jquery-jvectormap-1.2.2.js", //jvectormap
                        "~/AdminLte/Plugins/jvectormap/jquery-jvectormap-world-mill-en.js", //jvectormap
                        "~/AdminLte/Plugins/knob/jquery.knob.js", //jQuery Knob Chart
                        "~/AdminLte/Plugins/daterangepicker/moment_2.11.2.js", //Daterange picker
                        "~/AdminLte/Plugins/daterangepicker/daterangepicker.js", //Daterange picker
                        "~/AdminLte/Plugins/datepicker/bootstrap-datepicker.js", //datepicker
                        "~/AdminLte/Plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.js", //Bootstrap WYSIHTML5
                        "~/AdminLte/Plugins/slimScroll/jquery.slimscroll.js", //Slimscroll
                        "~/AdminLte/Plugins/fastclick/fastclick.js")); //FastClick

            //Misc App Plugins
            bundles.Add(new ScriptBundle("~/Scripts/Plugins/").Include(
                        "~/Scripts/Plugins/handlebars-v4.0.5.js",
                        "~/Scripts/Plugins/jinqJs.js"));
        }
    }
}