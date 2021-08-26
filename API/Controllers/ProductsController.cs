using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
        _repo=repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = _repo.GetProductsAsync();
           return Ok(await products);

        }

  [HttpGet("{id}")]             
   public async Task<ActionResult> Get(int id )
        {
           return Ok( await _repo.GetProductByIdAsync(id));

        }

          [HttpGet("brands")]             
         public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
           return Ok( await _repo.GetProductBrandsAsync());

        }

          [HttpGet("types")]             
         public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
           return Ok( await _repo.GetProductTypesAsync());

        }
    }
}