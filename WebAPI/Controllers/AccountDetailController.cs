using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class AccountDetailController : ControllerBase
    {
        private readonly IAccountDetailService _accountDetailService;

        public AccountDetailController(IAccountDetailService accountDetailService)
        {
            _accountDetailService = accountDetailService;
        }

        [HttpGet("getuseroffers")]
        public IActionResult GetUserOffer()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            return Ok(_accountDetailService.GetUserOffers(userId));
        }

        [HttpGet("getuserproductoffer")]
        public IActionResult GetOffersOnUserProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            return Ok(_accountDetailService.GetOffersOnUserProducts(userId));

        }
    }
}
