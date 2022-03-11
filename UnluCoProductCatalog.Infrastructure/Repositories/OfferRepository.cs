using System.Collections.Generic;
using System.Linq;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class OfferRepository : RepositoryBase<Offer>,IOfferRepository
    {
        private readonly ProductCatalogDbContext _context;
        public OfferRepository(ProductCatalogDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<GetOfferUserViewModel> GetUserOffers(string userId)
        {
            var result = from offer in _context.Offers
                join p in _context.Products on offer.Product.Id equals p.Id into of from p in of.DefaultIfEmpty() 
                join c in _context.Categories on p.CategoryId equals  c.Id
                where offer.UserId == userId & offer.IsDeleted == false
                select new GetOfferUserViewModel()
                {
                    Id = offer.Id,
                    OfferedPrice = offer.OfferedPrice,
                    IsApproved = offer.IsApproved,
                    CreatedTime = offer.CreatedDate,
                    PercentRate = offer.PercentRate,
                    Product = new GetProductUserViewModel
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        Description = p.Description,
                        ColorName = p.Color.ColorName,
                        BrandName = p.Brand.BrandName,
                        Price = p.Price,
                        Image = p.Image
                    },

                };
            return result.ToList();
        }

        public IEnumerable<GetOfferUserViewModel> GetOffersOnUserProducts(string userId)
        {
            var result = from u in _context.Users
                join p in _context.Products
                    on u.Id equals p.UserId
                join o in _context.Offers on p.Id equals o.Product.Id
                where u.Id == userId & o.IsDeleted == false & u.IsDeleted == false
                select new GetOfferUserViewModel
                {
                    Id = o.Id,
                    Product = new GetProductUserViewModel
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        Description = p.Description,
                        ColorName = p.Color.ColorName,
                        BrandName = p.Brand.BrandName,
                        Price = p.Price,
                        Image = p.Image
                    },
                    OfferedPrice = o.OfferedPrice,
                    IsApproved = o.IsApproved,
                    CreatedTime = o.CreatedDate,
                    PercentRate = o.PercentRate,
                };
            return result.ToList();
        }
    }
}
