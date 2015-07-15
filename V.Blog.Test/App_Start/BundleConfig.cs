using System.Web;
using System.Web.Optimization;

namespace V.Blog.Test
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            if (@System.Configuration.ConfigurationManager.AppSettings["Cdn"] == "true")
            {
                bundles.UseCdn = true;   //enable CDN support
            }
            else
            {
                bundles.UseCdn = false;   //disable CDN support
            }

            //add link to jquery on the CDN
            var jqueryCdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js";


            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include(
                            "~/Scripts/jquery-{version}.js",
                            "~/js/jquery.dataTables.js",
                            "~/js/jquery.dataTables.custom-filter.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.11.4.min.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jquerybootstrap").Include(
                       "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.multiple.select.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/customJs").Include(
                "~/Scripts/Custom/Custom.js",
                 "~/Scripts/Custom/customerjs.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/css/bootstrap.min.css",
                    "~/css/styles.css",
                      "~/css/plugins/multiple-select.css"

                ));

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

            BundleTable.EnableOptimizations = true;
        }
    }
}