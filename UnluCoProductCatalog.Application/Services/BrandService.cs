using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations;
using UnluCoProductCatalog.Application.Validations.BrandValidation;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;
using UnluCoProductCatalog.Domain.Entities;


namespace UnluCoProductCatalog.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ICollection< BrandViewModel> GetAll()
        {
            return _mapper.Map<ICollection<BrandViewModel>>(_unitOfWork.Brand.GetAll());
        }

        public void Update(CommandBrandViewModel entity,int id)
        {
            var validator = new CommandBrandViewModelValidator();
            validator.ValidateAndThrow(entity);

            var brand = _unitOfWork.Brand.GetById(id);
            if (brand is null)
            {
                throw new NotFoundExceptions("Brand", id);
            }

            brand.BrandName = brand.BrandName != default ? entity.BrandName : brand.BrandName;
            _unitOfWork.Brand.Update(brand);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Brand");
        }

        public void Create(CommandBrandViewModel entity)
        {
            var validator = new CommandBrandViewModelValidator();
            validator.ValidateAndThrow(entity);
            

            var brand = _mapper.Map<Brand>(entity);
            _unitOfWork.Brand.Create(brand);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Brand");
        }

        public void Delete(int id)
        {
            var brand =  _unitOfWork.Brand.GetById(id);
            if (brand is null)
                throw new NotFoundExceptions("Brand", id);

            brand.IsDeleted = true;
            _unitOfWork.Brand.Update(brand);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Brand");
        }
    }
}
