using System.Linq;
using AutoMapper;
using FluentValidation;
using Moq;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Mapping;
using UnluCoProductCatalog.Application.Services;
using UnluCoProductCatalog.Application.Validations.CategoryValidation;
using UnluCoProductCatalog.UnitTests.DataGenerator;
using Xunit;

namespace UnluCoProductCatalog.UnitTests.CategoryTests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        public CategoryServiceTests()
        {
           var categoryRepositoryMock = new Mock<ICategoryRepository>();
           _unitOfWorkMock = new Mock<IUnitOfWork>();
           _categoryRepositoryMock = new Mock<ICategoryRepository>();
           _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CategoryProfile())));
          
        }


        [Fact]
        public void GetAllCategory_Should_GetCategoryViewModelList()
        {
            //Arrange
            _unitOfWorkMock.Setup(u => u.Category).Returns(_categoryRepositoryMock.Object);
            _unitOfWorkMock.Setup(u => u.Category.GetAll()).Returns(DataWareHouse.GetCategoriesData());
            var categoryService = new CategoryService(_unitOfWorkMock.Object,_mapper);

            //Act
            var categories = categoryService.GetAll();

            //Assert
            Assert.NotNull(categories);
            Assert.Equal(3,categories.Count());

        }
        [Fact]
        public void CreateCategory_ShouldReturn_NotSavedException()
        {
            _unitOfWorkMock.Setup(u => u.Category).Returns(_categoryRepositoryMock.Object);
            _unitOfWorkMock.Setup(u => u.Category.Create(DataWareHouse.GetCategoriesData().FirstOrDefault()));

            var validator = new CommandCategoryViewModelValidator();

            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapper);
            var exception =
                Record.Exception(() => validator.ValidateAndThrow(DataWareHouse.GetCommandCategoryViewModel()));


            Assert.Throws<NotSavedExceptions>(() =>
                categoryService.Create(DataWareHouse.GetCommandCategoryViewModel()));

            Assert.Null(exception);
        }

        [Fact]
        public void UpdateCategory_ShouldReturn_NotSavedException()
        {
            //Arrange
            _unitOfWorkMock.Setup(u => u.Category).Returns(_categoryRepositoryMock.Object);

            var category = DataWareHouse.GetCategoriesData().FirstOrDefault();
            var validator = new CommandCategoryViewModelValidator();
            _unitOfWorkMock.Setup(u => u.Category.GetById(category.Id)).Returns(category);

            //Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapper);
            var exception =
                Record.Exception(() => validator.ValidateAndThrow(DataWareHouse.GetCommandCategoryViewModel()));

            //Assert
            Assert.Throws<NotSavedExceptions>(() =>
                categoryService.Update(DataWareHouse.GetCommandCategoryViewModel(), category.Id));
            Assert.Null(exception);
        }

        [Fact]
        public void DeleteCategory_ShouldReturn_NotSavedException()
        {
            //Arrange
            _unitOfWorkMock.Setup(u => u.Category).Returns(_categoryRepositoryMock.Object);
            var category = DataWareHouse.GetCategoriesData().FirstOrDefault();
            var validator = new CommandCategoryViewModelValidator();
            _unitOfWorkMock.Setup(u => u.Category.GetById(category.Id)).Returns(category);


            //Act
            var categoryService = new CategoryService(_unitOfWorkMock.Object, _mapper);
            var exception =
                Record.Exception(() => validator.ValidateAndThrow( DataWareHouse.GetCommandCategoryViewModel()));

            //Assert
            Assert.Throws<NotSavedExceptions>(() =>
                categoryService.Delete(category.Id));

            Assert.Null(exception);
        }
    }
}
