using AutoMapper;
using RouterFinder.Application.DTO;
using RouterFinder.Domain.Entities;

namespace RouterFinder.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Route, RouteDTO>().ReverseMap();
        }
    }
}