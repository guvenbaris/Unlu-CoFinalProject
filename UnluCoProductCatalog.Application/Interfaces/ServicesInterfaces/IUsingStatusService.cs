using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IUsingStatusService
    {
        ICollection<UsingStatusViewModel> GetAll();
        void Update(CommandUsingStatusViewModel entity,int id);
        void Create(CommandUsingStatusViewModel entity);
        void Delete(int id);
    }
}