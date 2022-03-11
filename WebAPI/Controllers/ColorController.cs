using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_colorService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CommandColorViewModel model)
        {
            _colorService.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CommandColorViewModel model, int id)
        {
            _colorService.Update(model,id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _colorService.Delete(id);
            return Ok();
        }
    }
}
