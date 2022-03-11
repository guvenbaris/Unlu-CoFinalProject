using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations.CategoryValidation;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;


        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = _unitOfWork.Category.GetAll();
            var result = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return result;
        }

        public void Create(CommandCategoryViewModel entity)
        {
            var validator = new CommandCategoryViewModelValidator();
            validator.Validate(entity);

            var category = _mapper.Map<Category>(entity);

            _unitOfWork.Category.Create(category);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Category");
        }

        public void Update(CommandCategoryViewModel entity, int id)
        {
            var validator = new CommandCategoryViewModelValidator();
            validator.ValidateAndThrow(entity);

            var category = _unitOfWork.Category.GetById(id);

            if (category is null)
                throw new NotFoundExceptions("Category", id);

            category.CategoryName = category.CategoryName != default ? entity.CategoryName : category.CategoryName;

            _unitOfWork.Category.Update(category);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Category");
        }

        public void Delete(int id)
        {


            var category = _unitOfWork.Category.GetById(id);

            if (category is null)
                throw new NotFoundExceptions("Category", id);

            category.IsDeleted = true;

            _unitOfWork.Category.Update(category);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Category");
        }
    }
}

