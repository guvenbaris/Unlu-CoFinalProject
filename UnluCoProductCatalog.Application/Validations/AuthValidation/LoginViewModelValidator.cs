using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;

namespace UnluCoProductCatalog.Application.Validations.AuthValidation
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email address is required");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(c => c.Password).MinimumLength(8).MaximumLength(20).NotEmpty();
        }
    }
}
