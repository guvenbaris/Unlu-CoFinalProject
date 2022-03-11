using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        public IActionResult Create(CreateOfferViewModel offer)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            _offerService.Create(offer,userId);
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _offerService.Delete(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateOfferViewModel model,int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            _offerService.Update(model, userId,id);
            return Ok();
        }

        [HttpPatch("offeraprove/{id}")]
        public IActionResult OfferAprove(int id)
        {
            _offerService.OfferApprove(id);
            return Ok();
        }
    }
}

