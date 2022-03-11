using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_brandService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CommandBrandViewModel model)
        {
            _brandService.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CommandBrandViewModel model,int id)
        {
            _brandService.Update(model,id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandService.Delete(id);
            return Ok();
        }
    }
}
