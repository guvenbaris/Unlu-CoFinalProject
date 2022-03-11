using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations.ColorValidation;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ICollection<ColorViewModel> GetAll()
        {
            return _mapper.Map<ICollection<ColorViewModel>>(_unitOfWork.Color.GetAll());
        }

        public void Update(CommandColorViewModel entity,int id)
        {
            var validator = new CommandColorViewModelValidator();
            validator.ValidateAndThrow(entity);

            var color = _unitOfWork.Color.GetById(id);
            if (color is null)
            {
                throw new NotFoundExceptions("Color", id);
            }

            color.ColorName = color.ColorName != default ? entity.ColorName : color.ColorName;

            _unitOfWork.Color.Update(color);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Color");
        }

        public void Create(CommandColorViewModel entity)
        {
            var validator = new CommandColorViewModelValidator();
            validator.ValidateAndThrow(entity);
            

            var color = _mapper.Map<Color>(entity);
            _unitOfWork.Color.Create(color);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Color");
        }

        public void Delete(int id)
        {
            var color = _unitOfWork.Color.GetById(id);
            if (color is null)
            {
                throw new NotFoundExceptions("Color", id);
            }

            color.IsDeleted = true;
            _unitOfWork.Color.Update(color);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Color");
        }
    }
}