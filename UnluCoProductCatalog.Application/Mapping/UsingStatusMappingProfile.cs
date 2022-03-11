using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class UsingStatusMappingProfile : Profile
    {
        public UsingStatusMappingProfile()
        {
            CreateMap<UsingStatusViewModel, UsingStatus>().ReverseMap();
            CreateMap<CommandUsingStatusViewModel, UsingStatus>().ReverseMap();
        }
    }
}