using System.Collections.Generic;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Services
{
    public class AccountDetailService :IAccountDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GetOfferUserViewModel> GetUserOffers(string userId)
        {
            return _unitOfWork.Offer.GetUserOffers(userId);
        }

        public IEnumerable<GetOfferUserViewModel> GetOffersOnUserProducts(string userId)
        {
            return _unitOfWork.Offer.GetOffersOnUserProducts(userId);
        }
    }
}
