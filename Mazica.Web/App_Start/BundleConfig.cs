using System.Web.Optimization;

namespace Mazica.Web
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-1.*"));


			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap*"));

			bundles.Add(new StyleBundle("~/Content/css")
					.Include("~/Content/site.css")  /* не перепутайте порядок */
					.Include("~/Content/bootstrap*"));
		}
	}
}