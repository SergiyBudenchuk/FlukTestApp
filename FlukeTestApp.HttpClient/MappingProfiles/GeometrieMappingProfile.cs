using AutoMapper;
using FlukeTestApp.DataProvider.Models;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.DataProvider.MappingProfiles
{
    public class GeometrieMappingProfile : Profile
    {
        public GeometrieMappingProfile()
        {
            CreateMap<OriginalGeometry, Geometrie>()
                .ForMember(s => s.Type, d => d.MapFrom(e => e.type))
                .ForMember(s => s.Date, d => d.MapFrom(e => e.date))
                .ForMember(s => s.Coordinates, d => d.MapFrom(e => e.coordinates));
        }
    }
}