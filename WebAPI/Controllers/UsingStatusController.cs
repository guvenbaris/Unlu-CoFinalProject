using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]es")]
    [ApiController]
    public class UsingStatusController : ControllerBase
    {
        private readonly IUsingStatusService _usingStatusService;

        public UsingStatusController(IUsingStatusService usingStatusService)
        {
            _usingStatusService = usingStatusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usingStatusService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CommandUsingStatusViewModel model)
        {

            _usingStatusService.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CommandUsingStatusViewModel model,int id)
        {
            _usingStatusService.Update(model,id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usingStatusService.Delete(id);
            return Ok();
        }
    }
}
