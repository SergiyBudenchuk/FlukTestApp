using AutoMapper;
using FlukeTestApp.DataProvider.Models;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.DataProvider.MappingProfiles
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<OriginalEvent, Event>()
                .ForMember(s => s.Id, d => d.MapFrom(e => e.id))
                .ForMember(s => s.Description, d => d.MapFrom(e => e.description))
                .ForMember(s => s.Link, d => d.MapFrom(e => e.link))
                .ForMember(s => s.Title, d => d.MapFrom(e => e.title))
                .ForMember(s => s.Categories, d => d.MapFrom(e => e.categories))
                .ForMember(s => s.Geometries, d => d.MapFrom(e => e.geometries))
                .ForMember(s => s.Sources, d => d.MapFrom(e => e.sources));
        }
    }
}