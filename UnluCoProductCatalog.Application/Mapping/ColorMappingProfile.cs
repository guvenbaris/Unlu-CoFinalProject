using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class ColorMappingProfile : Profile
    {
        public ColorMappingProfile()
        {
            CreateMap<ColorViewModel, Color>().ReverseMap();
            CreateMap<Color, CommandColorViewModel>().ReverseMap();
        }
    }
}