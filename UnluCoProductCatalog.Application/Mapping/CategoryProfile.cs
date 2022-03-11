using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryViewModel>().ReverseMap();
            CreateMap<CommandCategoryViewModel, Category>().ReverseMap();
        }
    }
}
