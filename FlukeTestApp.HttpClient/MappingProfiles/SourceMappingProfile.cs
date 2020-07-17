using AutoMapper;
using FlukeTestApp.DataProvider.Models;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.DataProvider.MappingProfiles
{
    public class SourceMappingProfile : Profile
    {
        public SourceMappingProfile()
        {
            CreateMap<OriginalSource, Source>()
                .ForMember(s => s.Id, d => d.MapFrom(e => e.id))
                .ForMember(s => s.Url, d => d.MapFrom(e => e.url));
        }
    }
}
