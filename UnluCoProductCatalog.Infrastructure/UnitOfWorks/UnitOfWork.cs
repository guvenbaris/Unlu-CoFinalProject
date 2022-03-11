using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;
using UnluCoProductCatalog.Infrastructure.Repositories;

namespace UnluCoProductCatalog.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductCatalogDbContext _context;


        public IColorRepository Color { get; }
        public IOfferRepository Offer { get; }
        public IProductRepository Product { get; }
        public ICategoryRepository Category { get; }
        public IBrandRepository Brand { get; }
        public IUsingStatusRepository UsingStatus { get; }
        public IAccountDetailRepository AccountDetail { get; }


        public UnitOfWork(IColorRepository color, IOfferRepository offer, IProductRepository product,
             IBrandRepository brand, IUsingStatusRepository usingStatus,
            IAccountDetailRepository accountDetail, ProductCatalogDbContext context, ICategoryRepository category)
        {
            _context = context;
            Category = category;
            Color = color;
            Offer = offer;
            Product = product;
            Brand = brand;
            UsingStatus = usingStatus;
            AccountDetail = accountDetail;
        }


        public bool SaveChanges() => _context.SaveChanges() > 0;
    }
}

