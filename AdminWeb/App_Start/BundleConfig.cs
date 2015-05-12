using System.Web;
using System.Web.Optimization;

namespace AdminWeb
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {



            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.min.js"));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/app/inspinia.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));

            // jQuery plugins
            bundles.Add(new ScriptBundle("~/plugins/metsiMenu").Include(
                      "~/Scripts/plugins/metisMenu/jquery.metisMenu.js"));

            bundles.Add(new ScriptBundle("~/plugins/pace").Include(
                      "~/Scripts/plugins/pace/pace.min.js"));

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/fonts/font-awesome/css/font-awesome.min.css"));

			// iCheck css styles
			bundles.Add(new StyleBundle("~/Content/plugins/iCheck/iCheckStyles").Include(
					  "~/Content/plugins/iCheck/custom.css"));

			// iCheck
			bundles.Add(new ScriptBundle("~/plugins/iCheck").Include(
					  "~/Scripts/plugins/iCheck/icheck.min.js"));

			// wizardSteps styles
			bundles.Add(new StyleBundle("~/plugins/wizardStepsStyles").Include(
					  "~/Content/plugins/steps/jquery.steps.css"));

			// wizardSteps 
			bundles.Add(new ScriptBundle("~/plugins/wizardSteps").Include(
					  "~/Scripts/plugins/staps/jquery.steps.min.js"));

			// validate 
			bundles.Add(new ScriptBundle("~/plugins/validate").Include(
					  "~/Scripts/plugins/validate/jquery.validate.min.js"));

        }
    }
}
