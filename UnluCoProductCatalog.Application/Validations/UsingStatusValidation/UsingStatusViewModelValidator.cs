using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;

namespace UnluCoProductCatalog.Application.Validations.UsingStatusValidation
{
    public class UsingStatusViewModelValidator : AbstractValidator<CommandUsingStatusViewModel>
    {
        public UsingStatusViewModelValidator()
        {
            RuleFor(c => c.UsingStatusName).NotEmpty().WithMessage("UsingStatusName name is required");
        }
    }
}
