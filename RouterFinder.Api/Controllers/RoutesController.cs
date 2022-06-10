using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using RouterFinder.Application.DTO;
using RouterFinder.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouterFinder.Api.Controllers
{
    [Route("api/routerFinder")]
    [EnableCors("AllowAll", "*", "*")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        // get appService from dependency injection
        private readonly IRouteAppService _routeAppService;
        public RoutesController(IRouteAppService routeAppService)
        {
            _routeAppService = routeAppService;
        }

        // Get All Routes
        [HttpGet]
        public IEnumerable<RouteDTO> Get()
        {
            var routes = _routeAppService.GetAll().ToList();
            return routes;
        }

        // Get Route by Id
        [HttpGet("{id}")]
        public RouteDTO Get(Guid id)
        {
            var route = _routeAppService.GetById(id);
            return route;
        }

        // Get route by from
        [HttpGet("/api/routerFinder/byfrom/{from}")]
        public List<RouteDTO> Get(string from)
        {
            var route = _routeAppService.GetAll().Where(x => x.routeFrom.ToLower() == from.ToLower()).ToList();
            return route;
        }

        // Add Route
        [HttpPost]
        public void Post([FromBody] RouteDTO value)
        {
            if (isValidDTO(value))
            {
                value.routeFrom = value.routeFrom.ToUpper();
                value.routeTo = value.routeTo.ToUpper();
                value.routeDescription = value.routeDescription.ToUpper();
                _routeAppService.Add(value);
            }
        }

        // Verify if RouteDTO is valid
        private bool isValidDTO(RouteDTO value)
        {
            if (string.IsNullOrEmpty(value.routeFrom)) return false;
            if (string.IsNullOrEmpty(value.routeTo)) return false;
            if (value.routeValue <= 0) return false;
            
            return true;
        }

        // Update Route
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] RouteDTO value)
        {
            RouteDTO route = _routeAppService.GetById(id);
            if (route != null)
            {
                route.routeFrom = value.routeFrom;
                route.routeTo = value.routeTo;
                route.routeDescription = value.routeDescription;
                route.routeValue = value.routeValue;
                _routeAppService.Update(route);
            }
        }

        // Delete Route
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            RouteDTO route = _routeAppService.GetById(id);
            if (route != null) _routeAppService.Delete(id);
        }
    }
}
