using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;
using UnluCoProductCatalog.Domain.Jwt;

namespace BlazorUI.Common.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegisterViewModel registerViewModel);
        Task<Token> Login(LoginViewModel loginViewModel);
        Task Logout();
    }
}
