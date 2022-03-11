using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<BrandViewModel, Brand>().ReverseMap();
            CreateMap<CommandBrandViewModel, Brand>().ReverseMap();
        }
    }
}
