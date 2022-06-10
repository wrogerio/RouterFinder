using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RouterFinder.Application.DTO;
using RouterFinder.Application.Interfaces;
using RouterFinder.Domain.Entities;
using RouterFinder.Domain.Interfaces.Services;

namespace RouterFinder.Application
{
    public class RouteAppService: IRouteAppService
    {
        // get the instance of the service and auto mapping from dependency injection
        private readonly IMapper _mapper;
        private readonly IRouteService _service;

        public RouteAppService(IRouteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // get by id
        public RouteDTO GetById(Guid id)
        {
            var route = _service.GetById(id);
            return _mapper.Map<RouteDTO>(route);
        }

        // insert
        public void Add(RouteDTO entity)
        {
            var route = _mapper.Map<Route>(entity);
            _service.Add(route);
        }

        // update
        public void Update(RouteDTO entity)
        {
            var route = _mapper.Map<Route>(entity);
            _service.Update(route);
        }

        // delete
        public void Delete(RouteDTO entity)
        {
            var route = _mapper.Map<Route>(entity);
            _service.Delete(route);
        }

        // delete by id
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }

        // get all
        IEnumerable<RouteDTO> IAppServiceBase<RouteDTO>.GetAll()
        {
            var routes = _service.GetAll().ToList();
            var t = _mapper.Map<List<RouteDTO>>(routes);
            return t;
        }
    }
}