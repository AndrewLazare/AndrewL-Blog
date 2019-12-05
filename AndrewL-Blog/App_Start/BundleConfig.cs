using System.Web;
using System.Web.Optimization;

namespace AndrewL_Blog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       
                       //"~/Scripts/jquery-migrate-3.0.1.min.js",
                       //"~/Scripts/popper.min.js",
                       //"~/Scripts/bootstrap.min.js",
                       //"~/Scripts/jquery.easing.1.3.js",
                       //"~/Scripts/jquery.waypoints.min.js",
                       //"~/Scripts/jquery.stellar.min.js",
                       //"~/Scripts/owl.carousel.min.js",
                       //"~/Scripts/jquery.magnific-popup.min.js",
                       //"~/Scripts/aos.js",
                       //"~/Scripts/jquery.animateNumber.min.js",
                       //"~/Scripts/scrollax.min.js",
                       //"~/Scripts/bootstrap-datepicker.js",
                       //"~/Scripts/jquery.timepicker.min.js",
                       // "~/Scripts/google-map.js",
                       // "~/Scripts/main.js",
                       // "~/Scripts/modernizr-*"
                        ));




           
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

          


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/css/open-iconic-bootstrap.min.css",
                      //"~/Content/css/animate.css",
                      //"~/Content/css/owl.carousel.min.css",
                      //"~/Content/css/owl.theme.default.min.css",
                      //"~/Content/css/magnific-popup.css",
                      //"~/Content/css/aos.css",
                      //"~/Content/css/ionicons.min.css",
                      //"~/Content/css/bootstrap-datepicker.css",
                      //"~/Content/css/jquery.timepicker.css",
                      //"~/Content/css/flaticon.css",
                      //"~/Content/css/icomoon.css",
                      //"~/Content/css/style.css"
                      ));
                     
        }
    }
                      
}











