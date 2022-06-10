using Microsoft.AspNetCore.Mvc;
using RouterFinder.Web.Models;
using System.Threading.Tasks;

namespace RouterFinder.Web.Controllers
{
    public class RoutesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // get all routes from api
            var routes = await RouteUtil.getRoutes();
            return View(routes);
        }
    }
}
