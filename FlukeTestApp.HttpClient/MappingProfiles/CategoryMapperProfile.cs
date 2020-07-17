using AutoMapper;
using FlukeTestApp.DataProvider.Models;
using FlukeTestApp.DomainModels.Models;

namespace FlukeTestApp.DataProvider.MappingProfiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<OriginalCategory, Category>()
                .ForMember(s => s.Id, d => d.MapFrom(e => e.id))
                .ForMember(s => s.Title, d => d.MapFrom(e => e.title));
        }
    }
}
