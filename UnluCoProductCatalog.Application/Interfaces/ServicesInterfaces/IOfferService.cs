using System.Security.Principal;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IOfferService
    {
        void Create(CreateOfferViewModel entity,string userId);
        void Delete(int offerId);
        void OfferApprove(int offerId);
        void Update(UpdateOfferViewModel entity,string userId,int id);
    }
}
