using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("productsforoffer")]
        public IActionResult GetProductsForOffer()
        {
            return Ok(_productService.GetProductsForOffer());
        }


        [HttpGet("userproducts")]
        public IActionResult GetUserProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            return Ok(_productService.GetUserProducts(userId));
        }

        [HttpGet("categoryId")]
        public IActionResult GetAllByCategoryId([FromQuery] int id = 0)
        {
            return Ok(_productService.GetProductsByCategoryId(id));
        }

        [HttpPut("retractoffer/{offerId}")]
        public IActionResult RetractTheOffer(int offerId)
        {
            _productService.RetractTheOffer(offerId);
            return Ok();
        }

        [HttpPut("sellproduct")]
        public IActionResult SellProduct(ProductSellViewModel sellproduct)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            _productService.SellProduct(sellproduct, userId);
            return Ok();
        }

        [HttpPut("productisofferable/{id}")]
        public IActionResult UpdateIsOfferable(int id)
        {
            _productService.UpdateIsOfferable(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel product)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            _productService.Create(product,userId);
            return Ok();
        }
    }
}
