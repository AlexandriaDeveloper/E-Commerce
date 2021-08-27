using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;

        private readonly IMapper _mapper;
        public ProductsController(
        IGenericRepository<Product> productRepo,
        IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo,IMapper mapper)
        {
            this.productRepo = productRepo;
            this.productBrandRepo = productBrandRepo;
            this.productTypeRepo = productTypeRepo;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec= new ProductsWithTypesAndBrandsSpecification();
            var products =await productRepo.ListAsync(spec);
          // return Ok(await products);

          return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));

        }

  [HttpGet("{id}")]             
   public async Task<ActionResult<ProductToReturnDto>> Get(int id )
        {

       var spec= new ProductsWithTypesAndBrandsSpecification(id);
       var product = await productRepo.GetEntityWithSpec(spec);
        return _mapper.Map<Product,ProductToReturnDto>(product);
            
            

        }

          [HttpGet("brands")]             
         public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
           return Ok( await productBrandRepo.ListAllAsync());

        }

          [HttpGet("types")]             
         public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
           return Ok( await productTypeRepo.ListAllAsync());

        }
    }
}