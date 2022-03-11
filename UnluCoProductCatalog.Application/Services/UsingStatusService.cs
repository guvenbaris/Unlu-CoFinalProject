using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations.UsingStatusValidation;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class UsingStatusService : IUsingStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsingStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ICollection<UsingStatusViewModel> GetAll()
        {
            return _mapper.Map<ICollection<UsingStatusViewModel>>(_unitOfWork.UsingStatus.GetAll());
        }

        public void Update(CommandUsingStatusViewModel entity,int id)
        {
            var validator = new UsingStatusViewModelValidator();
            validator.ValidateAndThrow(entity);

            var usingStatus = _unitOfWork.UsingStatus.GetById(id);
            if (usingStatus is null)
                throw new NotFoundExceptions("UsingStatus", id);

            usingStatus.UsingStatusName = usingStatus.UsingStatusName != default ? entity.UsingStatusName : usingStatus.UsingStatusName;
            _unitOfWork.UsingStatus.Update(usingStatus);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("UsingStatus");
        }

        public void Create(CommandUsingStatusViewModel entity)
        {
            var validator = new UsingStatusViewModelValidator();
            validator.ValidateAndThrow( entity);

            var usingStatus = _mapper.Map<UsingStatus>(entity);

            _unitOfWork.UsingStatus.Create(usingStatus);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("UsingStatus");
        }

        public void Delete(int id)
        {
            var usingStatus = _unitOfWork.UsingStatus.GetById(id);
            if (usingStatus is null)
            {
                throw new NotFoundExceptions("UsingStatus", id);
            }

            usingStatus.IsDeleted = true;
            _unitOfWork.UsingStatus.Update(usingStatus);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("UsingStatus");
        }
    }
}