using System.Web;
using System.Web.Optimization;

namespace GasMeter_MS
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/commonJs").Include(
                      "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                      "~/Content/js/respond.js",
                      "~/Content/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                      "~/Content/js/metronic.js",
                      "~/Content/js/layout.js",
                      "~/Content/js/quick-sidebar.js",
                      "~/Content/js/index.js"));
            bundles.Add(new StyleBundle("~/Content/commonCss").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/css/components-rounded.css",
                     "~/Content/plugins/font-awesome/css/font-awesome.min.css",
                     "~/Content/plugins/simple-line-icons/simple-line-icons.min.css"));
            bundles.Add(new StyleBundle("~/Content/layoutCss").Include(
                     "~/Content/css/layout.css",
                     "~/Content/css/plugins.css",
                     "~/Content/css/theme-default.css",
                     "~/Content/Site.css"));
        }
    }
}
