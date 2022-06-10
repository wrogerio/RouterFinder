using RouterFinder.Domain.Entities;
using RouterFinder.Domain.Interfaces.Repositories;
using RouterFinder.Infra.Context;

namespace RouterFinder.Infra.Repository
{
    public class RouteRepository : RepositoryBase<Route>, IRouteRepository
    {
        public RouteRepository(RouterFinderContext context) : base(context)
        {
        }
    }
}