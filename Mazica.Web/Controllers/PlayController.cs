using System.Web.Mvc;
using MazeGen;
using Mazica.Domain;
using Mazica.WebObjects;
using Newtonsoft.Json;
using Ninject;

namespace Mazica.Web.Controllers
{
    public class PlayController : ControllerBase
    {
        public ActionResult Index()
        {
	        var gen = new RecursiveMazeGenerator(5, 5, 5);
	        var maze = gen.Generate();
            return View(maze);
        }

        public JsonResult GetMaze()
        {
	        var gen = new RecursiveMazeGenerator(5, 5, 5);
	        var maze = gen.Generate();
	        return Json(new JsonMaze(maze), JsonRequestBehavior.AllowGet);
        }

    }
}
