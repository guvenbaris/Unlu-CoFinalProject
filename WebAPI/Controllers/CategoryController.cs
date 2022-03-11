using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;

namespace WebAPI.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
    
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CommandCategoryViewModel category)
        {
            _categoryService.Create(category);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CommandCategoryViewModel model,int id)
        {
            _categoryService.Update(model,id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult UpdateIsDeleted(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }

}
