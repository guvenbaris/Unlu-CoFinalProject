using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        private readonly ProductCatalogDbContext _context;
        
        public ProductRepository(ProductCatalogDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<GetProductViewModel> GetProductsByCategoryId(int id)
        {
            var query = from p in _context.Products
                join brand in _context.Brands on p.Brand.Id equals brand.Id
                join color in _context.Colors on p.Color.Id equals color.Id
                join status in _context.UsingStatuses on p.UsingStatusId equals status.Id
                join category in _context.Categories on p.CategoryId equals category.Id
                where p.CategoryId == id && p.IsDeleted == false
                select new GetProductViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    IsOfferable = p.IsOfferable,
                    CategoryName = category.CategoryName,
                    ColorName = color.ColorName,
                    BrandName = brand.BrandName,
                    UsingStatus = status.UsingStatusName,
                    Price = p.Price,
                    Image = p.Image
                };

            return query.ToList();
        }

        public IEnumerable<GetProductViewModel> GetProducts()
        {

            var query = from p in _context.Products
                join brand in _context.Brands on p.Brand.Id equals brand.Id
                join color in _context.Colors on p.Color.Id equals color.Id
                join status in _context.UsingStatuses on p.UsingStatusId equals status.Id
                join category in _context.Categories on p.CategoryId equals category.Id
                where p.IsDeleted == false
                select new GetProductViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    IsOfferable = p.IsOfferable,
                    CategoryName = category.CategoryName,
                    ColorName = color.ColorName,
                    BrandName = brand.BrandName,
                    UsingStatus = status.UsingStatusName,
                    Price = p.Price,
                    Image = p.Image
                };
            return query.ToList();
        }

        public IEnumerable<ProductOfferViewModel> GetProductsForOffer()
        {
            var query = from p in _context.Products
                join c in _context.Categories on p.CategoryId equals c.Id
                where p.IsDeleted == false && p.IsOfferable == true
                select new ProductOfferViewModel
                {
                    CategoryName = c.CategoryName,
                    Id = p.Id,
                    Price = p.Price,
                    ProductName = p.ProductName
                };
            return query.ToList();
        }

        public IEnumerable<GetProductViewModel> GetUserProducts(string userId)
        {

            var query = from p in _context.Products
                join brand in _context.Brands on p.Brand.Id equals brand.Id
                join color in _context.Colors on p.Color.Id equals color.Id
                join status in _context.UsingStatuses on p.UsingStatusId equals status.Id
                join category in _context.Categories on p.CategoryId equals category.Id
                where p.IsDeleted == false && p.UserId == userId
                select new GetProductViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    IsOfferable = p.IsOfferable,
                    CategoryName = category.CategoryName,
                    ColorName = color.ColorName,
                    BrandName = brand.BrandName,
                    UsingStatus = status.UsingStatusName,
                    Price = p.Price,
                    Image = p.Image
                };
            return query.ToList();
        }
    }
}
