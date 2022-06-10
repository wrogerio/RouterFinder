using RouterFinder.Domain.Entities;
using RouterFinder.Domain.Interfaces.Repositories;
using RouterFinder.Domain.Interfaces.Services;

namespace RouterFinder.Domain.Services
{
    public class RouteService : ServiceBase<Route>, IRouteService
    {
        // get the repository from dependency injection
        private readonly IRouteRepository _repository;

        // inject the repository into the service
        public RouteService(IRouteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}