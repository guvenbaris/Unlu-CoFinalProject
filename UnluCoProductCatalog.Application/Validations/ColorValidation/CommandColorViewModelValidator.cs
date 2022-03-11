using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;

namespace UnluCoProductCatalog.Application.Validations.ColorValidation
{
    public class CommandColorViewModelValidator : AbstractValidator<CommandColorViewModel>
    {
        public CommandColorViewModelValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty().WithMessage("Color name is required");
        }
    }
}
