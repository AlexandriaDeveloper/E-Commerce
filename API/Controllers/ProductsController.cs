using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helper;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController :BaseApiController
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
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec= new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFilterForCountSpecification(productParams);
            var totalItems = await productRepo.CountAsync(countSpec);
            var products =await productRepo.ListAsync(spec);
          // return Ok(await products);
          var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products);

          return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,productParams.PageSize,totalItems,data));

        }

    [HttpGet("{id}")]     
    [ProducesResponseType(StatusCodes.Status200OK)]     
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]      
   public async Task<ActionResult<ProductToReturnDto>> Get(int id )
        {

       var spec= new ProductsWithTypesAndBrandsSpecification(id);
       var product = await productRepo.GetEntityWithSpec(spec);

       if(product==null)
       {
         return NotFound(new ApiResponse(404));
       }
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