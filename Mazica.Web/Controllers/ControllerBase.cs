using Mazica.Domain;
using Mazica.Utility;
using Ninject;
using System.Web.Mvc;
namespace Mazica.Web.Controllers
{
	public class ControllerBase: Controller
	{
		[Inject]
		protected MazicaContext Context { get; set; }

		[Inject]
		protected IMapper Mapper { get; set; }
	}
}