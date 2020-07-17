using AutoMapper;
using FlukeTestApp.DataProvider.Models;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.DataProvider.MappingProfiles
{
    public class RootMappingProfile : Profile
    {
        public RootMappingProfile()
        {
            CreateMap<OriginalRoot, Root>()
                .ForMember(s => s.Title, d => d.MapFrom(e => e.title))
                .ForMember(s => s.Description, d => d.MapFrom(e => e.description))
                .ForMember(s => s.Link, d => d.MapFrom(e => e.link))
                .ForMember(s => s.Events, d => d.MapFrom(e => e.events));
        }
    }
}
