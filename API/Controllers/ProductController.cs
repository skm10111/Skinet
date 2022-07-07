using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Product>>> GetProducts()
        {
            return Ok (await _productRepository.GetProductsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyCollection<ProductBrand>>> GetProductsBrands()
        {
            return Ok(await _productRepository.GetProductsBrandsAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyCollection<ProductType>>> GetProductsTypes()
        {
            return Ok(await _productRepository.GetProductsTypesAsync());
        }
    }
}
