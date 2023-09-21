using AkademiPlusMikroService.Catalog.Dtos.ProductDtos;
using AkademiPlusMikroService.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMikroService.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProduct(createProductDto);
            return Ok("Ürün oluşturuldu");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Ürün silme başarılı");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProduct(updateProductDto);
            return Ok("Ürün güncelleme başarılı");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByProductId(string id)
        {
            var values = await _productService.GetByIdProduct(id);

            return Ok(values);
        }
    }
}
