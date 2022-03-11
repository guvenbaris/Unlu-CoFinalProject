using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.EntegrasyonTests.Common;
using Xunit;

namespace UnluCoProductCatalog.EntegrasyonTests.CategoryController
{
    public class CategoryControllerTests : IClassFixture<ManagerApplicationFactory>
    {
        private readonly WebApplicationFactory<TestStartup> _factory;

        public CategoryControllerTests(ManagerApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Categories()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act 
            var response = await client.GetAsync("api/Categories");
            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(json);

            //Assert
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task Create_Category()
        {
            //Arrange
            var client = _factory.CreateClient();
            CommandCategoryViewModel model = new CommandCategoryViewModel { CategoryName = "Test"};

            //Act
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(model), Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync("api/Categories", content);
            Assert.Equal(HttpStatusCode.Created,response.StatusCode);


            var responseCategories = await client.GetAsync("api/Categories");
            Assert.Equal(HttpStatusCode.OK, responseCategories.StatusCode);

            var json = await responseCategories.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(json);

            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
            Assert.Equal("Test0",categories[0].CategoryName);

            var last = categories.Last();
            var lastCategoryResponse = await client.GetAsync($"api/Categories");


            Assert.Equal(HttpStatusCode.OK,lastCategoryResponse.StatusCode);

            var lastCategoryJson = await lastCategoryResponse.Content.ReadAsStringAsync();
            var lastCategory = JsonConvert.DeserializeObject<List<CategoryViewModel>>(lastCategoryJson)?.AsQueryable();

            var result =  lastCategory?.Any(x => x.CategoryName == last.CategoryName);

            Assert.NotNull(lastCategory);
            Assert.True(result);
        }

        [Fact]
        public async void Delete_Category()
        {
            var client = _factory.CreateClient();

            var fisrtCategoryResponse = await client.GetAsync("api/Categories");
            Assert.Equal(HttpStatusCode.OK, fisrtCategoryResponse.StatusCode);

            var jsonFirst = await fisrtCategoryResponse.Content.ReadAsStringAsync();
            var firtCategories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(jsonFirst)?.AsQueryable();

            var response = await client.DeleteAsync($"api/Categories/{2}");

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);

            var categoryResponse = await client.GetAsync("api/Categories");
            Assert.Equal(HttpStatusCode.OK, categoryResponse.StatusCode);

            var json = await categoryResponse.Content.ReadAsStringAsync();
            var lastCategories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(json)?.AsQueryable();

            var result = lastCategories?.Any(x => x.Id == 2);
            
            Assert.NotSame(lastCategories,firtCategories);
            Assert.False(result);
            Assert.NotNull(lastCategories);
        }


        [Fact]
        public async void Update_Category()
        {

            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Categories");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var json =await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(json);
            var category = categories?[3];

            category.CategoryName = "Test99";
            
            var content = new StringContent(JsonConvert.SerializeObject(category),Encoding.UTF8,"application/json");

            var responseUpdate = await client.PutAsync($"api/Categories/{category.Id}", content);
            Assert.Equal(HttpStatusCode.OK, responseUpdate.StatusCode);

            var responseAfterUpdate = await client.GetAsync("api/Categories");
            var jsonUpdated = await responseAfterUpdate.Content.ReadAsStringAsync();
            var lastCategories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(jsonUpdated)?.AsQueryable();

            var result = lastCategories?.Any(x => x.CategoryName == category.CategoryName);

            Assert.True(result);
            Assert.NotNull(lastCategories);
        }

    }
}
