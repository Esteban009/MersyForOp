using System.Web.Optimization;

namespace Backend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/Scripts/datetimepicker/moment.js",
                          "~/Scripts/bootstrap.js",
                          "~/Scripts/respond.js",
                          "~/Scripts/datetimepicker/bootstrap-datetimepicker.js",
                          "~/Scripts/Ps/js/fileupload.js",
                          "~/Scripts/maskedinput/jquery.maskedinput.min.js",
                         "~/Scripts/Ps/vendor/jQuery-Storage-API/jquery.storageapi.js",
                         "~/Scripts/Ps/vendor/jquery.easing/js/jquery.easing.js",
                         "~/Scripts/Ps/vendor/animo.js/animo.js",
                         "~/Scripts/Ps/vendor/jquery-localize-i18n/dist/jquery.localize.js",
                         "~/Scripts/Ps/js/app.js",
                         "~/Scripts/Ps/js/CascadeDdl.js",
                         "~/Scripts/Ps/js/GenericFx.js"));

            bundles.Add(new ScriptBundle("~/bundles/others").Include(
                "~/Scripts/datetimepicker/moment.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/datetimepicker/bootstrap-datetimepicker.js",
                "~/Scripts/Ps/js/fileupload.js",
                "~/Scripts/maskedinput/jquery.maskedinput.min.js",
                "~/Scripts/Ps/vendor/jQuery-Storage-API/jquery.storageapi.js",
                "~/Scripts/Ps/vendor/jquery.easing/js/jquery.easing.js",
                "~/Scripts/Ps/vendor/animo.js/animo.js",
                "~/Scripts/Ps/vendor/jquery-localize-i18n/dist/jquery.localize.js",
                "~/Scripts/Ps/js/app.js",
                "~/Scripts/Ps/js/CascadeDdl.js",
                "~/Scripts/Ps/js/GenericFx.js"));



            //bundles.Add(new ScriptBundle("~/bundles/table").Include(
            //    "~/Scripts/DataTables/js/jquery.dataTables.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                         "~/Content/bootstrap.css",
                          "~/Content/site.css",
                         "~/Scripts/Ps/vendor/fontawesome/css/font-awesome.min.css",
                         "~/Scripts/Ps/vendor/simple-line-icons/css/simple-line-icons.css",
                         "~/Scripts/Ps/vendor/animate.css/animate.min.css",
                         "~/Scripts/Ps/vendor/whirl/dist/whirl.css",
                          "~/Scripts/datetimepicker/bootstrap-datetimepicker.css"));
             
           
            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //"~/Scripts/DataTables/css/jquery.dataTables.min.css"));
        }
    }
}
