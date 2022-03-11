using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, GetProductViewModel>().ReverseMap();
            CreateMap<CreateProductViewModel, Product>();
        }
    }
}