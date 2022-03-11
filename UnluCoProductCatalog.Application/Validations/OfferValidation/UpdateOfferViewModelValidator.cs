using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Validations.OfferValidation
{
    public class UpdateOfferViewModelValidator : AbstractValidator<UpdateOfferViewModel>
    {
        public UpdateOfferViewModelValidator()
        {
            RuleFor(o => o.ProductId).GreaterThan(0);
            RuleFor(o => o.OfferedPrice).GreaterThan(0);
            RuleFor(o => o.PercentRate).GreaterThan(0);
        }
    }
}
