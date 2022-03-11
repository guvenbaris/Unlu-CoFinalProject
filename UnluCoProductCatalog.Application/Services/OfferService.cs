using System;
using AutoMapper;
using FluentValidation;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations.OfferValidation;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;
using UnluCoProductCatalog.Domain.Entities;


namespace UnluCoProductCatalog.Application.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(CreateOfferViewModel entity,string userId)
        {
            var validator = new CreateOfferViewModelValidator();
            validator.ValidateAndThrow(entity);

            var product =  _unitOfWork.Product.GetById(entity.ProductId);

            if (!product.IsOfferable)
            {
                throw new InvalidOperationException("Product status is not offered");
            }

            var offeredPrice = (product.Price * entity.PercentRate) / 100;

            if (entity.OfferedPrice < offeredPrice)
            {
              throw new InvalidOperationException("Offer is much lower to for price");
            }

            var offer = _mapper.Map<Offer>(entity);
            offer.UserId = userId;

            _unitOfWork.Offer.Create(offer);

            if (!_unitOfWork.SaveChanges())
            {
                throw new InvalidOperationException("Offer can not be created");
            }
        }

        public void Delete(int id)
        {
            var offer = _unitOfWork.Offer.GetById(id);

            if (offer is null)
                throw new NotFoundExceptions("Offer", id);

            offer.IsDeleted = true;

            _unitOfWork.Offer.Update(offer);
            
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Offer");
        }

        public void Update(UpdateOfferViewModel entity,string userId,int id)
        {
            var validator = new UpdateOfferViewModelValidator();
            validator.ValidateAndThrow(entity);

            var offer = _unitOfWork.Offer.GetById(id);

            if (offer is null)
            {
                throw new NotFoundExceptions("Offer", id);
            }
            
            offer.PercentRate = offer.PercentRate != default ? entity.PercentRate : offer.PercentRate;
            offer.ProductId = offer.ProductId != default ? entity.ProductId : offer.ProductId;
            offer.OfferedPrice =offer.OfferedPrice != default ? entity.OfferedPrice : offer.OfferedPrice;

            _unitOfWork.Offer.Update(offer);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Offer");
        }

        public void OfferApprove(int offerId)
        {
            var offer = _unitOfWork.Offer.GetById(offerId);

            if (offer is null)
            {
                throw new NotFoundExceptions("Offer", offerId);
            }


            if (offer.IsApproved)
            {
                offer.IsSold = true;
            }

            offer.IsSold = false;
        }
    }
}
