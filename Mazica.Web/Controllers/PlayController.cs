using System.Web.Mvc;
using Mazica.Domain;
using Ninject;

namespace Mazica.Web.Controllers
{
    public class PlayController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
