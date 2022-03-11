using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;

namespace UnluCoProductCatalog.Application.Validations.BrandValidation
{
    public class CommandBrandViewModelValidator : AbstractValidator<CommandBrandViewModel>
    {
        public CommandBrandViewModelValidator()
        {
            RuleFor(c=>c.BrandName).NotEmpty().WithMessage("Brand name is required");
        }
    }
}
