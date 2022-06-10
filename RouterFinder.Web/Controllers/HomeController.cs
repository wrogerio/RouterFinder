using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RouterFinder.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RouterFinder.Web.Models;

namespace RouterFinder.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // get routes from api
            var routes =  await RouteUtil.getRoutes();

            // get all distincts from routes
            var startPoints = GetFromList(routes);

            ViewBag.StartPoints = new SelectList(startPoints, "Name", "Name");
            return View();
        }

        protected List<RouteItem> GetFromList(List<Route> rotas)
        {
            // get all distincts from routes
            List<RouteItem> fromList = new List<RouteItem>();
            foreach (var item in rotas)
            {
                // prevent duplicated items
                if (!fromList.Any(x => x.Name == item.routeFrom))
                    fromList.Add(new RouteItem { Name = item.routeFrom });
            }

            return fromList;
        }
    }
}
