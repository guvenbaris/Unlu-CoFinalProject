using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Domain.Jwt;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterViewModel registerUserModel);
        Task<Token> Login(LoginViewModel loginUserModel);

    }
}
