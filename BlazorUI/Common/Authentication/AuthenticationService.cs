using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;
using UnluCoProductCatalog.Domain.Jwt;

namespace BlazorUI.Common.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthStateProvider _authStateProvider;
        private readonly ProtectedLocalStorage _localStorage;

        public AuthenticationService(HttpClient client, AuthStateProvider authStateProvider, ProtectedLocalStorage localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<string> Register(RegisterViewModel registerViewModel)
        {
            var content = JsonSerializer.Serialize(registerViewModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var requestUri = "http://localhost:3000/api/Auths/register";

            var authResult = await _client.PostAsync(requestUri: requestUri, bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            return string.IsNullOrWhiteSpace(authContent) ? "Register İşlem Failed" : authContent;
        }

        public async Task<Token> Login(LoginViewModel loginViewModel)
        {
            var content = JsonSerializer.Serialize(loginViewModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var requestUri = "http://localhost:3000/api/Auths/login";
            var authResult = await _client.PostAsync(requestUri:requestUri, bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Token>(authContent, _options);

            await _localStorage.SetAsync("authToken", result.AccessToken);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(loginViewModel.Email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.AccessToken);
            return result;
        }
        public async Task Logout()
        {
            await _localStorage.DeleteAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
