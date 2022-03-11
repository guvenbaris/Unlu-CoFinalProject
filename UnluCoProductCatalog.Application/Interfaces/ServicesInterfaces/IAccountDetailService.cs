using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IAccountDetailService
    {
        IEnumerable<GetOfferUserViewModel> GetUserOffers(string userId);
        IEnumerable<GetOfferUserViewModel> GetOffersOnUserProducts(string userId);
    }
}

