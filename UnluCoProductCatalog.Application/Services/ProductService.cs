using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations.ProductValidation;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable< GetProductViewModel> GetAll()
        {
            var products = _unitOfWork.Product.GetProducts();

            return _mapper.Map<IEnumerable<GetProductViewModel>>(products);
        }

        public void RetractTheOffer(int offerId)
        {
            var offer = _unitOfWork.Offer.GetById(offerId);

            if (offer is null)
            {
                throw new NotFoundExceptions("Offer", offerId);
            }

            if (offer.IsApproved)
            {
                throw new InvalidOperationException("Offer approved so you can't retract the offer");
            }

            offer.IsDeleted = true;

            _unitOfWork.Offer.Update(offer);

            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Offer");
            }
        }

        public IEnumerable<GetProductViewModel> GetProductsByCategoryId(int id)
        {
            if (id == 0)
            {
                var productsAll = _unitOfWork.Product.GetProducts();
                return productsAll;
            }

            var checkCategoryId = _unitOfWork.Category.GetById(id);
            if (checkCategoryId is null)
            {
                throw new NotFoundExceptions("Category", id);
            }
            var productsFilter = _unitOfWork.Product.GetProductsByCategoryId(id);
            if (productsFilter is null)
            {
                throw new NotFoundExceptions("Product");
            }
            return productsFilter;
        }

        public IEnumerable<GetProductViewModel> GetUserProducts(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new NotFoundExceptions("User");
            }
            return _unitOfWork.Product.GetUserProducts(userId);
        }

        public IEnumerable<ProductOfferViewModel> GetProductsForOffer()
        {
            return _unitOfWork.Product.GetProductsForOffer();
        }

        public void SellProduct(ProductSellViewModel entity, string userId)
        {
            var product = _unitOfWork.Product.GetById(entity.ProductId);

            if (product is null)
            {
                throw new NotFoundExceptions("Product", entity.ProductId);
            }
            
            if (product.Price > entity.Price)
            {
                throw new InvalidOperationException("Price is not enough");
            }

            if (product.IsOfferable)
            {
                throw new InvalidOperationException("Product is not offerable");
            }

            product.IsSold = true;
            product.UserId = userId;
            
            _unitOfWork.Product.Update(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }
        public void Create(CreateProductViewModel entity,string userId)
        {
            var validator = new CreateProductViewModelValidator();

            validator.ValidateAndThrow(entity);

            var product = _mapper.Map<Product>(entity);

            product.IsSold = false;
            product.IsOfferable = false;
            product.UserId = "qwbeasbkdbsakjdbas";

            _unitOfWork.Product.Create(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }

        public void UpdateIsOfferable(int id)
        {
            var product = _unitOfWork.Product.GetById(id);

            if (product is null)
                throw new NotFoundExceptions("Product", id);

            product.IsOfferable = true;
            _unitOfWork.Product.Update(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }
    }
}
