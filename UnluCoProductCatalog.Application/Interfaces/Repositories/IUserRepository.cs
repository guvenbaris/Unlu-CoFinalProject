using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        bool Update(User user);
    }
}
