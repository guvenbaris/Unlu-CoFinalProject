using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.Repositories
{
    public interface IOfferRepository : IRepositoryBase<Offer>
    {
        IEnumerable<GetOfferUserViewModel> GetUserOffers(string userId);
        IEnumerable<GetOfferUserViewModel> GetOffersOnUserProducts(string userId);
    }
}