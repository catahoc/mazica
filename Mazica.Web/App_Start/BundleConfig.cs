using System.Web.Optimization;

namespace Mazica.Web
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-1.9.1.js"));


			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap*"));

			bundles.Add(new ScriptBundle("~/bundles/three").Include(
						"~/Scripts/three.*"));

			bundles.Add(new StyleBundle("~/Content/css")
					.Include("~/Content/site.css")  /* не перепутайте порядок */
					.Include("~/Content/bootstrap*"));
		}
	}
}